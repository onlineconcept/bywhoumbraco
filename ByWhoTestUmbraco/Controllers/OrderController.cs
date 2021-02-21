using ClientDependency.Core;
using DataLayer;
using NPoco.Expressions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using Umbraco.Core;
using Umbraco.Core.Migrations.Expressions.Create.Table;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web.Mvc;
using Constants = Umbraco.Core.Constants;

namespace ByWhoTestUmbraco.Controllers
{
    public class OrderController : SurfaceController
    {
        private readonly IContentService _contentService;
        private readonly IMediaService _mediaService;
        private bool debug = false;

        private const int ORDER_CONFIRMATION_TEMPLATE = 1236;

        public OrderController(IContentService contentService, IMediaService mediaService)
        {
            _contentService = contentService;
            _mediaService = mediaService;
        }
        [System.Web.Mvc.HttpPost]
        public async Task<string> CreateOrder(long tnxid, string orderid, string custId, int amount, int currency, string date, string time, string hash)
        {
            try
            {
                using (bywhoEntities db = new bywhoEntities())
                {
                    long orderId = await GetOrderId(db);
                    Guid customerId = Guid.Parse(custId);
                    var customer = await db.Customers.FirstOrDefaultAsync(x=> x.Id == customerId);
                    //TOTO FETCH  CART 
                    var order = _contentService.Create("ORDER-" + orderId, 1221, "order");
                    order.SetValue("orderId", orderId.ToString());
                    order.SetValue("navn", customer.Name);
                    order.SetValue("addresse", customer.Address);
                    order.SetValue("postnr", customer.Zipcode);
                    order.SetValue("by", customer.City);
                    order.SetValue("telefonnummer", customer.Phone);
                    order.SetValue("email", customer.Email);
                    order.SetValue("cartid", orderid);
                    order.SetValue("transaktionsid", tnxid.ToString());
                    _contentService.SaveAndPublish(order);
                    var orderLines = db.CartLines.Where(x => x.CustomerId == customerId).ToList();
                    int i = 1;
                    foreach(var item in orderLines)
                    {
                        var orderline = _contentService.Create("OrderLine-"+i,order.Id,"orderline");
                        orderline.SetValue("product", item.Styles.Name);
                        orderline.SetValue("quantity", item.Quantity);
                        orderline.SetValue("price", item.Price);
                        orderline.SetValue("text", item.Text);
                        orderline.SetValue("comments", item.Comments);
                        orderline.SetValue("size", db.Sizes.Find(item.SizeId).Name);
                        _contentService.SaveAndPublish(orderline);
                        var images = db.Picture.Where(x => x.CartLineId == item.Id);
                        int j = 1;
                        
                        foreach (var pic in images)
                        {
                            var imageContent = _contentService.Create("image-"+j, orderline.Id, "uploadedImage");
                            var fileName = Guid.NewGuid().ToString() + "." + pic.Path.Split('.')[1];
                            var file = System.IO.File.Open(pic.Path,System.IO.FileMode.Open);
                            //var media = Services.MediaService.CreateMedia(fileName, 1240, Constants.Conventions.MediaTypes.File);
                            //media.SetValue(Services.ContentTypeBaseServices, Constants.Conventions.Media.File, fileName,file);
                            //Services.MediaService.Save(media);
                            //imageContent.SetValue("image", file);
                            int lastIndex = pic.Path.LastIndexOf("\\") + 1;
                            string filename = pic.Path.Substring(lastIndex, pic.Path.Length - lastIndex);
                            imageContent.SetValue(Services.ContentTypeBaseServices, "image", filename, file);

                           _contentService.SaveAndPublish(imageContent);
                            j++;
                        }
                        i++;
                    }
                    var body = SendConfirmationMail(customer, orderLines,order);
                    order.SetValue("mail", body);
                    _contentService.SaveAndPublish(order);

                    return body;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string SendConfirmationMail(Customers customer, List<CartLines> orderLines, IContent order)
        {
            var body = BuildOrder(customer, orderLines, order); 
            try
            {

                SmtpClient client = new SmtpClient("smtp.unoeuro.com");
                MailMessage msg = new MailMessage("no-reply@bywho.dk", "klaus.pedersen@onlineconcept.dk");
                msg.Bcc.Add("klaus.pedersen@onlineconcept.dk");
                //msg.Bcc.Add("rasmus@verkauf.dk");
                msg.Subject = "Bestillingsseddel";
                msg.Body = body;
                msg.IsBodyHtml = true;
                if (!debug)
                    client.Send(msg);
                return body;
            }
            catch (Exception ex)
            {
                return body;
            }
        }

        private string BuildOrder(Customers customer, List<CartLines> orderLines,IContent order)
        {
           
        


            //[NAVN],[ADDRESSE],[POSTNR],[BYNAVN],[TELEFON],[EMAIL],[ORDERID],[DATE],[ORDRELINJER]
            var bodyHtml = _contentService.GetById(ORDER_CONFIRMATION_TEMPLATE).GetValue<string>("bodyTekst");
            bodyHtml = bodyHtml.Replace("[NAVN]", customer.Name);
            bodyHtml = bodyHtml.Replace("[ADDRESSE]", customer.Address);
            bodyHtml = bodyHtml.Replace("[POSTNR]", customer.Zipcode);
            bodyHtml = bodyHtml.Replace("[BYNAVN]", customer.City);
            bodyHtml = bodyHtml.Replace("[TELEFON]", customer.Phone);
            bodyHtml = bodyHtml.Replace("[EMAIL]", customer.Email);
            bodyHtml = bodyHtml.Replace("[ORDERID]", order.GetValue<string>("orderId"));
            bodyHtml = bodyHtml.Replace("[DATE]",order.CreateDate.ToString("dd-MM-yyyy"));
            bodyHtml = bodyHtml.Replace("[ORDRELINJER]", TableBuilder(orderLines));

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<html>");
            sb.AppendLine("<head>");
            sb.AppendLine("<link href='//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css' rel='stylesheet' id ='bootstrap-css'>");
            sb.AppendLine("<link href='//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css' rel='stylesheet' id ='bootstrap-css'>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");
            sb.AppendLine("<div class='container'>");
            sb.AppendLine("<div class='row'>");
            sb.AppendLine("<div class='col-12'>");
            sb.AppendLine("<div class='card'>");
            sb.AppendLine(bodyHtml);
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            return sb.ToString();;
        }

        private string TableBuilder(List<CartLines> orderLines)
        {
            string[] headers = new string[] { "Produkt,left", "Antal,center", "Pris Pr stk.,center", "Total,right" };
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table style='width:100%;'>");
            sb.AppendLine("<thead>");
            CreateHeader(sb, headers);
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");
            CreateRow(sb, orderLines);
            sb.AppendLine("</tbody>");
            sb.AppendLine("</table>");

            return sb.ToString();
        }

        private static void CreateRow(StringBuilder sb, List<CartLines> orderLines)
        {
            foreach (var item in orderLines)
            {
                sb.AppendLine("<tr>");
                    sb.AppendLine("<td align='left'>");
                    sb.AppendLine(item.Styles.Name);
                    sb.AppendLine("</td>");
                    sb.AppendLine("<td align='center'>");
                    sb.AppendLine(item.Quantity.ToString());
                    sb.AppendLine("</td>");
                    sb.AppendLine("<td align='center'>");
                    sb.AppendLine(item.Price.ToString("0.00") + " DKK");
                    sb.AppendLine("</td>");
                    sb.AppendLine("<td align='right'>");
                    sb.AppendLine((item.Quantity * item.Price).ToString("0.00") + " DKK");
                    sb.AppendLine("</td>");
                sb.AppendLine("</tr>");
            }
            sb.AppendLine("<tr><td colspan='4'><hr/></td></tr>");
            sb.AppendLine("<tr>");           
            sb.AppendLine("<td align='right' colspan='3'>");
            sb.AppendLine("Subtotal");
            sb.AppendLine("</td>");
            sb.AppendLine("<td align='right' style='font-weight:bold;'>");
            sb.AppendLine(Subtotal(orderLines) + " DKK");
            sb.AppendLine("</td>");
            sb.AppendLine("</tr>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<td align='right' colspan='3'>");
            sb.AppendLine("Her af Moms");
            sb.AppendLine("</td>");
            sb.AppendLine("<td align='right' style='font-weight:bold;'>");
            sb.AppendLine(Tax(orderLines) + " DKK");
            sb.AppendLine("</td>");
            sb.AppendLine("</tr>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<td align='right' colspan='3'>");
            sb.AppendLine("Total");
            sb.AppendLine("</td>");
            sb.AppendLine("<td align='right' style='font-weight:bold;'>");
            sb.AppendLine(Subtotal(orderLines) + " DKK");
            sb.AppendLine("</td>");
            sb.AppendLine("</tr>");
        }

        private static string Tax(List<CartLines> orderLines)
        {
            var sum = orderLines.Sum(x => x.Quantity * x.Price);
            return (sum-(sum/1.25m)).ToString("0.00");
        }

        private static string Subtotal(List<CartLines> orderLines)
        {
            return orderLines.Sum(x => x.Quantity * x.Price).ToString("0.00");
        }

        private static void CreateHeader(StringBuilder sb, string[] values)
        {
            sb.AppendLine("<tr>");
            foreach (var item in values)
            {
                string[] split = item.Split(',');
                sb.AppendLine($"<th style='text-align:{split[1]};'>");
                sb.AppendLine(split[0]);
                sb.AppendLine("</th>");
            }
            sb.AppendLine("</tr>");
        }

        private async Task<long> GetOrderId(bywhoEntities db)
        {
            using(var cmd = db.Database.Connection.CreateCommand())
            {
                cmd.CommandText = "spOrderId";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                await db.Database.Connection.OpenAsync();
                long orderId = (long)(await cmd.ExecuteScalarAsync());
                db.Database.Connection.Close();
                return orderId;
            }
        }
    }
}
