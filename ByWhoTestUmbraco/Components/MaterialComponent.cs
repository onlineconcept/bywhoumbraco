using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Core.Services.Implement;

namespace ByWhoTestUmbraco.Components
{
    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    public class MaterialPublishedComposer : ComponentComposer<MaterialComponent>
    {
        // nothing needed to be done here!
    }
    public class MaterialComponent : IComponent
    {
        public void Initialize()
        {
            ContentService.Published += ContentService_Published; ;
            ContentService.Unpublished += ContentService_Unpublished;
        }

        private void ContentService_Published(IContentService sender, ContentPublishedEventArgs e)
        {
            foreach (var item in e.PublishedEntities)
            {
                if (item.ContentType.Alias == "materiale")
                {

                    try
                    {
                        using (bywhoEntities db = new bywhoEntities())
                        {
                            Materials mat = null;
                            var id = item.GetValue<string>("materialeId");
                            mat = db.Materials.FirstOrDefault(x => x.Id.ToString() == id);
                            if (mat == null)
                            {
                                mat = new Materials();
                                PopulateModel(item, mat, true);
                                db.Materials.Add(mat);
                                db.SaveChanges();
                                item.SetValue("materialeId", mat.Id.ToString());
                                sender.SaveAndPublish(item,raiseEvents:false);
                            }else
                            {
                                PopulateModel(item, mat, true);
                                db.SaveChanges();
                            }
                            
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }

        private static void PopulateModel(IContent item, Materials mat, bool published)
        {
            mat.Title = item.GetValue<string>("title");
            mat.Text = item.GetValue<string>("bodyTekst");
            mat.Picture = item.GetValue<string>("picture");
            mat.SeoTitle = item.GetValue<string>("seoTitle");
            mat.SeoDescription = item.GetValue<string>("seoDescription");
            mat.SeoKeywords = item.GetValue<string>("seoKeywords");
            mat.NoFollow = item.GetValue<bool>("noFollow");
            mat.SeName = item.GetValue<string>("seName");
            mat.Published = published;
        }

        private void ContentService_Unpublished(IContentService sender, PublishEventArgs<Umbraco.Core.Models.IContent> e)
        {
            foreach (var item in e.PublishedEntities)
            {
                if (item.ContentType.Alias == "materiale")
                {

                    try
                    {
                        try
                        {
                            using (bywhoEntities db = new bywhoEntities())
                            {
                                Materials mat = null;
                                var id = item.GetValue<string>("materialeId");
                                mat = db.Materials.FirstOrDefault(x => x.Id.ToString() == id);
                                if (mat != null)
                                {
                                    mat.Published = false;
                                    db.SaveChanges();
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                    catch
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