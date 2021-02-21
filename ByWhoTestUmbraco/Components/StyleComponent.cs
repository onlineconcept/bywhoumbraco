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
using Umbraco.Web.Templates;

namespace ByWhoTestUmbraco.Components
{
    
    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    public class StylePublishedComposer : ComponentComposer<StyleComponent>
    {
        // nothing needed to be done here!
    }
    public class StyleComponent : IComponent
    {
        public void Initialize()
        {
            ContentService.Published += ContentService_Published;
        }

        private void ContentService_Published(IContentService sender, ContentPublishedEventArgs e)
        {
            foreach (var item in e.PublishedEntities)
            {
                if (item.ContentType.Alias == "page")
                {
                    try
                    {
                        bywhoEntities db = new bywhoEntities();
                        int pguid = item.GetValue<int>("pageId");
                        var topic = db.Topic.FirstOrDefault(x => x.Id == pguid);
                        var baseURL = "/cms";
                        if (topic != null)
                        {
                            topic.Title = item.GetValue<string>("title");
                            topic.SystemName = item.GetValue<string>("systemName");
                            topic.BodyTekst = TemplateUtilities.ResolveMediaFromTextString(item.GetValue<string>("bodyText"));
                            topic.IsPage = item.GetValue<bool>("isPage");
                            topic.SeoTitle = item.GetValue<string>("seoTitle");
                            topic.SeoDescription = item.GetValue<string>("seoDescription");
                            topic.SeoKeywords = item.GetValue<string>("seoKeywords");
                            topic.NoFollow = item.GetValue<bool>("noFollow");                            
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