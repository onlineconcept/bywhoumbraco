using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Data;
using DataLayer.Interfaces;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using NotImplementedException = System.NotImplementedException;

namespace DataLayer.Repositories
{
    public class SizeRepository:BaseContext,ISizeRepository
    {
        public SizeRepository(ShopContext ctx) : base(ctx)
        {
        }

        public async Task<List<Size>> GetSizes()
        {
            try
            {
                var list = await ctx.Sizes.ToListAsync();
                
                return list;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Size> GetSizeById(int id)
        {
            return await ctx.Sizes.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}