using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dev.Controllers
{
    public class FrontendController:Controller
    {
        public readonly IStyleService styleService;
        public FrontendController(IStyleService styleService)
        {
            this.styleService = styleService;
        }
        [Route("/frontend/styles")]
        [HttpGet]
        public async Task<IActionResult> GetStyles()
        {
            return Ok(await styleService.GetStyles());
        }
    }
}