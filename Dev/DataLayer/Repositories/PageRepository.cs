using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Data;
using DataLayer.Interfaces;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using NotImplementedException = System.NotImplementedException;

namespace DataLayer.Repositories
{
    public class PageRepository: BaseContext,IPageRepository
    {
        public PageRepository(ShopContext ctx) : base(ctx)
        {
        }

        public async Task<Topic> GetPageByName(string name)
        {
            return await ctx.Topic.FirstOrDefaultAsync(x => x.SystemName.ToLower() == name.ToLower());
        }

        public async Task<List<Topic>> GetSubpagesById(int id)
        {
            var item = ctx.Topic.Where(x => x.Id == id).Include(x=> x.Subpage).First();
            var subId = item.Subpage?.Id ?? -1;
            
            return await ctx.Topic.Where(x => x.Subpage.Id == id || x.Subpage.Id == subId ).ToListAsync();
        }
    }
}