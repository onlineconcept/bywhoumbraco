using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dev.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dev.Controllers
{
    
    public class ResourceController : Controller
    {
        private readonly ResourceHelper _resourceHelper;

        public ResourceController(ResourceHelper resourceHelper)
        {
            _resourceHelper = resourceHelper;
        }

        [Route("resources")]
        public async Task<IActionResult> All()
        {
            return Ok(await _resourceHelper.GetAllResources());
        }
    }
}
