using System;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dev.Controllers
{
    public class SizeController:Controller
    {
        private readonly ISizeService _service;

        public SizeController(ISizeService service)
        {
            _service = service;
        }

        [Route("sizes/all")]
        public async Task<IActionResult> GetSizes()
        {
            try
            {
                return Ok(await _service.GetSizes());
            }
            catch(Exception ex)
            {
                return BadRequest(new {Error = ex.Message});
            }
        }
        
    }
}