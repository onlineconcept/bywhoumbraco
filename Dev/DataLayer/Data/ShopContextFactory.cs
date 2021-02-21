using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using NotImplementedException = System.NotImplementedException;

namespace DataLayer.Data
{
    public class ShopContextFactory:IDesignTimeDbContextFactory<ShopContext>
    {
        public ShopContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ShopContext>();
            optionsBuilder.UseSqlServer("Data Source=skyvision.dk;Initial Catalog=bywho;User ID=bywho;Password=Klaus4bso!");

            return new ShopContext(optionsBuilder.Options);
        }
    }
}