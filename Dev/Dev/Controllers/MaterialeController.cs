using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Interfaces;
using Dev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;

namespace Dev.Controllers
{
    [Route("produkter")]
    public class MaterialeController : Controller
    {
        private readonly IMaterialRepository _materialRepository;

        public MaterialeController(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public async Task<IActionResult> Index()
        {
            
            var model = new MaterialeModel();
            model.Materials = await _materialRepository.GetAllMaterials();
            return View(model);
        }
        
        
        [Route("{sename}")]
        public async Task<IActionResult> Materiale(string sename)
        {

            var model = new MaterialeModel();
            model.Material = await _materialRepository.GetMaterialById(sename);
            return View("Product",model);
        }
    }
}
