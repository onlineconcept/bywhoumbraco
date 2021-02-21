using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    public abstract class BaseContext: IDisposable
    {
        protected ShopContext ctx;
        public BaseContext(ShopContext ctx)
        {
            this.ctx = ctx;
        }

       

        public void Save()
        {
            this.ctx.SaveChanges();
        }
        public async Task SaveAsync()
        {
            await this.ctx.SaveChangesAsync();
        }
        public void Dispose()
        {
            this.ctx = null;
        }
    }
}
