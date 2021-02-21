using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using DataLayer.Data;
using DataLayer.Interfaces;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class CustomerRepository: BaseContext,ICustomerRepository
    {
        public CustomerRepository(ShopContext ctx) : base(ctx)
        {
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await ctx.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerById(Guid id)
        {
            return await ctx.Customers.FindAsync(id);
        }

        public async Task<Customer> GetCustomerByEmail(string email)
        {
            return await ctx.Customers.FirstOrDefaultAsync(c=> c.Email == email);
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            await ctx.Customers.AddAsync(customer);
            await ctx.SaveChangesAsync();
            return customer;
        }

        public async Task UpdateCustomer(Customer customer)
        {
            ctx.Update(customer).State = EntityState.Modified;
            await SaveAsync();

        }
    }
}