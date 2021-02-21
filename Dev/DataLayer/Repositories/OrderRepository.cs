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
    public class OrderRepository:BaseContext,IOrderRepository
    {
        public OrderRepository(ShopContext ctx) : base(ctx)
        {
        }
        
        public async Task<List<Order>> GetOrders()
        {
            return await ctx.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderById(Guid id)
        {
            return await ctx.Orders.FirstAsync(x => x.Id == id);
        }

        public async Task UpdateOrder(Order order)
        {
            //var o = await ctx.Orders.FirstAsync(x => x.OrderId == order.OrderId);
            //missing workload
        }

        public async Task<int> CreateCustomerCart(CustomerCart customer)
        {
             ctx.Customercarts.Add(customer);
            await SaveAsync();

            return customer.Id;
        }

        public async  Task<Customer> GetCustomerCart(int id)
        {
            var customer = await ctx.Customercarts.Include(x=> x.Customer).FirstOrDefaultAsync(x => x.Id == id);
            return customer.Customer;
            
        }
    }
}