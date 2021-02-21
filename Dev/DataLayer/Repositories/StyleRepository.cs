using DataLayer.Data;
using DataLayer.Interfaces;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class StyleRepository : BaseContext, IStyleRepository
    {
        public StyleRepository(ShopContext ctx) : base(ctx)
        {
        }

        public async Task<Style> CreateStyle(Style style)
        {
            try
            {
                await ctx.Styles.AddAsync(style);
                await SaveAsync();
                return style;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateStyle(Style style)
        {
            try
            {
                var s = await ctx.Styles.FirstAsync(x => x.Id == style.Id);
                s.Name = style.Name;
                s.Description = style.Description;
                s.Price = style.Price;
                s.Picture = style.Picture;
                s.NoFollow = style.NoFollow;
                s.HasText = style.HasText;
                s.OldPrice = style.OldPrice;
                s.Published = style.Published;
                s.SeoDescription = style.SeoDescription;
                s.SeoKeywords = style.SeoKeywords;
                s.SeoTitle = style.SeoTitle;
                s.SeName = style.SeName;
                s.SortOrder = style.SortOrder;
                s.AmountOfPictures = s.AmountOfPictures;
                s.B2BPrice = s.B2BPrice;
                await SaveAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Style> GetStyleById(Guid guid)
        {
            try
            {
                return await ctx.Styles.FindAsync(guid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Style> GetStyleByName(string name)
        {
            try
            {
                return await ctx.Styles.FirstOrDefaultAsync(x=> x.SeName == name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ICollection<Style>> GetStyles()
        {
            return await ctx.Styles.OrderBy(x=> x.SortOrder).ToListAsync();
        }
    }
}
