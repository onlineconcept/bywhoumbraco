using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using Dev.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dev.Controllers
{
    [Route("stilarter")]
    public class StyleController : Controller
    {
        public readonly IStyleService styleService;
        public StyleController(IStyleService styleService)
        {
            this.styleService = styleService;
        }
        public async Task<IActionResult> Index()
        {
            var model = new StyleViewModel();
            model.Styles = await styleService.GetStyles();
            return View(model);
        }
        [Route("{name}")]
        public async Task<IActionResult> Index(string name)
        {
            var model = new StyleViewModel();
            model.Style = await styleService.GetStyleByName(name.ToLower());
            return View("Style",model);
        }

        [Route("stilarter/fetchstyles")]
        [HttpPost]
        public async Task<IActionResult> GetStyles()
        {
           var styles = await styleService.GetStyles();
           return Ok(styles);
        }
    }
}