using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using Dev.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dev.Controllers
{
    [Route("sider")]
    public class PageController : Controller
    {
        private readonly IPageService _pageService;

        public PageController(IPageService pageService)
        {
            _pageService = pageService;
        }
        
        [Route("{name}")]
        public async Task<IActionResult> Index(string name)
        {
            var model = new PageViewModel();
            model.Page = await _pageService.GetTopicByName(name.ToLower());
            model.SubPages = await _pageService.GetSubpagesById(model.Page.Id);
            return View("Page",model);
        }
    }
}