using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Dev.Controllers
{
    [Route("wallart")]
    public class WallArtController:Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}