using DataLayer.Data;
using DataLayer.Interfaces;
using DataLayer.Migrations;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class MaterialRepository : BaseContext, IMaterialRepository
    {
        public MaterialRepository(ShopContext ctx) : base(ctx)
        {
        }

        public async Task<List<Material>> GetAllMaterials()
        {
            return await ctx.Materials.Where(x => x.Published).ToListAsync();
        }

        public async Task<Material> GetMaterialById(string sename)
        {
            return await ctx.Materials.FirstAsync(x=> x.SeName.ToLower() == sename.ToLower() && x.Published);
        }
    }
}
