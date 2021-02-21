using DataLayer.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Data
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
        }

        public DbSet<CartLine> CartLines { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DiscountCode> DiscountCodes { get; set; }
        public DbSet<Giftcard> Giftcards { get; set; }
        public DbSet<GiftcardUsageHistory> GiftCardUsageHistories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<Topic> Topic { get; set; }
        public DbSet<User> Users { get; set; }
<<<<<<< HEAD
        public DbSet<CustomerCart> Customercarts {get;set;}
        public DbSet<Material> Materials {get;set;}
=======
>>>>>>> 8de6f2e2c83ad2cca316a4f5f82c84b059351f82
        public DbSet<Resource> Resources { get; set; }
    }
}
