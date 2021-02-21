using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using DataLayer.DTO;
using DataLayer.Interfaces;
using DataLayer.Models;
using Dev.Configuration;
using Dev.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Dev.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private readonly ICustomerRepository _customerRepository;

        public IConfiguration Configuration { get; }
        


        public CheckoutController(IConfiguration configuration,ICartService cartService,IOrderService orderService,ICustomerRepository customerRepository)
        {
            _cartService = cartService;
            _orderService = orderService;
            _customerRepository = customerRepository;
            Configuration = configuration;
        }
        // GET
        public IActionResult Index()
        {
            return View();
        }

        //GET
        public IActionResult Payment()
        {
            return View();
        }

        public async Task<IActionResult> Complete([FromQuery] EpayResponse response )
        {
            if (
                !string.IsNullOrEmpty(response.orderid) ||
                !string.IsNullOrEmpty(response.hash) ||
                !string.IsNullOrEmpty(response.txnid)
            )
            {
                CompleteDTO dto = new CompleteDTO();
                dto.NewCart = await _cartService.CreateCustomer();
                dto.OrderCustomer = await _orderService.GetCustomerCart(int.Parse(response.orderid));
                dto.CartLines = await _cartService.GetCartLines(dto.OrderCustomer.Id);
                HttpClient client = new HttpClient();
                 var httpResponse = await client.PostAsync($"{Configuration.GetSection("API:BaseUrl").Value}/cms/umbraco/surface/Order/CreateOrder?tnxid={response.txnid}&orderid={response.orderid}&custId={dto.OrderCustomer.Id}&amount={response.amount}&currency={response.currency}&date={response.date}time={response.time}&hash={response.hash}",null);
                dto.Response = await httpResponse.Content.ReadAsStringAsync();
                dto.ResponseCode = httpResponse.StatusCode;
                return View(dto);
            }
            return BadRequest();
        }
        
        [Route("checkout/paymentwindow/{customerId}")]
        public async Task<IActionResult> GetPaymentWindow(Guid customerId)
        {
            var total = int.Parse((await _cartService.GetTotal(customerId)*100).ToString("0", CultureInfo.InvariantCulture));
            int orderId = await _orderService.CreateCustomerCart(new CustomerCart { Customer = (await _customerRepository.GetCustomerById(customerId)) });
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(
                "<form action=\"https://ssl.ditonlinebetalingssystem.dk/integration/ewindow/Default.aspx\" method=\"post\">");
            sb.AppendLine($"<input type=\"hidden\" name=\"merchantnumber\" value=\"{Configuration.GetSection("EpaySettings:MerchantId").Value}\">");
            sb.AppendLine($"<input type=\"hidden\" name=\"amount\" value=\"{total}\">");
            sb.AppendLine($"<input type=\"hidden\" name=\"currency\" value=\"DKK\">");
            sb.AppendLine($"<input type=\"hidden\" name=\"windowstate\" value=\"3\">");
            sb.AppendLine($"<input type=\"hidden\" name=\"accepturl\" value=\"{Configuration.GetSection("EpaySettings:AcceptUrl").Value}\">");
            sb.AppendLine($"<input type=\"hidden\" name=\"cancelurl\" value=\"{Configuration.GetSection("EpaySettings:CancelUrl").Value}\">");
            sb.AppendLine($"<input type=\"hidden\" name=\"ownrecipe\" value=\"{Configuration.GetSection("EpaySettings:OwnRecipe").Value}\">");
            sb.AppendLine($"<input type=\"hidden\" name=\"orderid\" value=\""+orderId+"\">");           
            string[] paramsList = new string[] { 
                $"{Configuration.GetSection("EpaySettings:MerchantId").Value}", 
                $"{total}",
                $"DKK",
                $"3",
                $"{Configuration.GetSection("EpaySettings:AcceptUrl").Value}",
                $"{Configuration.GetSection("EpaySettings:CancelUrl").Value}",
                $"{Configuration.GetSection("EpaySettings:OwnRecipe").Value}",
                $"{orderId}"            
            };      




            sb.AppendLine($"<input type=\"hidden\" name=\"hash\" value=\"" + MD5Helper.CalculateMd5Hash(paramsList, Configuration.GetSection("EpaySettings:Secret").Value) + "\">");

            sb.AppendLine($"<input type=\"submit\" class=\"btn v-btn theme--light\" value=\"Betal nu\">");
            sb.AppendLine($"</form>");
            return Ok(new { PaymentWindow = sb.ToString()});
        }
    }
}