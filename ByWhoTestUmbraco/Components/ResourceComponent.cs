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
    public class ResourcePublishedComposer : ComponentComposer<ResourceComponent>
    {
        // nothing needed to be done here!
    }
    public class ResourceComponent : IComponent
    {
        public void Initialize()
        {
            ContentService.Published += ContentService_Published;
        }

        private void ContentService_Published(IContentService sender, ContentPublishedEventArgs e)
        {
            foreach (var item in e.PublishedEntities)
            {
                if (item.ContentType.Alias == "resource")
                {
                    try
                    {
                        bywhoEntities db = new bywhoEntities();
                        string systemName = item.Name;
                        var resource = db.Resources.FirstOrDefault(x => x.Name == systemName);

                        if (resource != null)
                        {
                            resource.Value = item.GetValue<string>("text");
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