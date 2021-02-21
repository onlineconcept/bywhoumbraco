using DataLayer.Data;
using DataLayer.Interfaces;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class ResourceRepository : BaseContext,IResourceRepository
    {
        public ResourceRepository(ShopContext ctx) : base(ctx)
        {

        }
        public async Task<List<Resource>> GetAllResource()
        {
            return await ctx.Resources.ToListAsync();
        }
    }
}
