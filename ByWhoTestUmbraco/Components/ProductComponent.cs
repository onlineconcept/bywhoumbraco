using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Core.Events;
using Umbraco.Core.Services;
using Umbraco.Core.Services.Implement;

namespace ByWhoTestUmbraco.Components
{
    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    public class ProductPublishedComposer : ComponentComposer<ProductComponent>
    {
        // nothing needed to be done here!
    }
    public class ProductComponent : IComponent
    {
        public void Initialize()
        {
            ContentService.Published += ContentService_Published;
        }

        private void ContentService_Published(IContentService sender, ContentPublishedEventArgs e)
        {
            foreach (var item in e.PublishedEntities)
            {
                if (item.ContentType.Alias == "product")
                {
                    try
                    {
                        bywhoEntities db = new bywhoEntities();
                        Guid pguid = Guid.Parse(item.GetValue<string>("productId"));
                        var style = db.Styles.FirstOrDefault(x => x.Id == pguid);
                        var baseURL = "/cms";
                        if(style != null)
                        {
                            style.Name = item.GetValue<string>("productName");
                            style.Description = item.GetValue<string>("description");
                            style.Price = item.GetValue<decimal>("price");
                            style.OldPrice = item.GetValue<decimal>("oldPrice");
                            style.Picture = baseURL + item.GetValue<string>("picture");
                            style.Poster = baseURL + item.GetValue<string>("poster");
                            style.AmountOfPictures = (int)item.GetValue<decimal>("amountOfPictures");
                            style.Published = item.GetValue<bool>("published");
                            style.HasText = item.GetValue<bool>("hasTextInStyle");
                            style.SeoTitle = item.GetValue<string>("seoTitle");
                            style.SeoDescription = item.GetValue<string>("seoDescription");
                            style.SeoKeywords = item.GetValue<string>("seoKeywords");
                            style.NoFollow = item.GetValue<bool>("noFollow");
                            db.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
                
            }
        }

        public void Terminate()
        {
            throw new NotImplementedException();
        }
    }
}