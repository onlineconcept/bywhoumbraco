using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Data;
using DataLayer.Interfaces;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class CartRepository:BaseContext,ICartRepository
    {
        public CartRepository(ShopContext ctx) : base(ctx)
        {
        }
        
        public async Task AddToCart(CartLine line)
        {
            try
            {
                ctx.CartLines.Add(line);
                await SaveAsync();
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task RemoveFromCart(Guid id, Guid customerId)
        {
            try
            {
               
                var line = await ctx.CartLines.FirstOrDefaultAsync(x=> x.Id == id && x.Customer.Id == customerId);
                if (line != null)
                {
                    ctx.CartLines.Remove(line);
                    await SaveAsync();
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Customer> GetCustomer(Guid id)
        {
            try
            {
               
                var customer = await ctx.Customers.FirstOrDefaultAsync(x=> x.Id == id);
                return customer;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Customer> CreateCustomer()
        {
            try
            {
                var customer = new Customer
                {
                    Id = Guid.NewGuid()
                };
                await ctx.Customers.AddAsync(customer);
                await SaveAsync();
                return customer;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<CartLine>> GetCartLines(Guid customerId)
        {
            try
            {
                var lines = await ctx.CartLines.Include("Size").Include("Style").Where(x =>  x.Customer.Id == customerId).ToListAsync();
                return lines;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public Task Increment(Guid id)
        {
            try
            {
                var line = ctx.CartLines.First(x => x.Id == id);
                line.Quantity += 1;

                ctx.SaveChanges();
                return Task.CompletedTask;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public Task Decrement(Guid id)
        {
            try
            {
                var line = ctx.CartLines.First(x => x.Id == id);
                if (line.Quantity > 1)
                {
                    line.Quantity -= 1;
                    ctx.SaveChanges();
                }

                return Task.CompletedTask;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}