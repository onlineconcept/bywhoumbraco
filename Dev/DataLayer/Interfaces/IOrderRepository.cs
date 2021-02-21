using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrders();
        Task<Order> GetOrderById(Guid id);
        Task UpdateOrder(Order order);
        Task<int> CreateCustomerCart(CustomerCart customer);
        Task<Customer> GetCustomerCart(int id);
    }
}