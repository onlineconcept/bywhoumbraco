using ByWhoTestUmbraco.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Umbraco.Core;
using Umbraco.Core.Services;
using Umbraco.Web.Mvc;

namespace ByWhoTestUmbraco.Controllers
{
    public class DesignRequestController : SurfaceController
    {
        private IContentService _contentService;
        private IMediaService _mediaService;

        public DesignRequestController(IContentService contentService, IMediaService mediaService)
        {
            _contentService = contentService;
            _mediaService = mediaService;
        }
        [HttpPost]
        public async Task<object> CreateDesignRequest([FromBody] RequestDesignDTO dto)
        {
            var req = Request.Files;
            var designRequest = _contentService.Create(dto.Email, 1456, "designRequest");
            designRequest.SetValue("email", dto.Email);
            designRequest.SetValue("phone", dto.Phone);
            designRequest.SetValue("size", dto.Size);
            designRequest.SetValue("product", dto.Product);
            designRequest.SetValue("stilart", dto.Style);
            designRequest.SetValue("stilTekst", dto.Text);
            designRequest.SetValue("kommentar", dto.Comments);
            _contentService.SaveAndPublish(designRequest);
            int i = 1;
            foreach (var key in req.AllKeys)
            {
                var imageContent = _contentService.Create("image-" + i, designRequest.Id, "designRequestImage");
                var fileName = req[key].FileName;
                imageContent.SetValue("type", key);
                imageContent.SetValue(Services.ContentTypeBaseServices, "image", fileName, req[key].InputStream);
            
                _contentService.SaveAndPublish(imageContent);
                i++;
            }

            return new { complete = true };
        }
    }
}
