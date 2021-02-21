using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.Interfaces
{
    public interface ICartRepository
    {
        Task AddToCart(CartLine line);
        Task RemoveFromCart(Guid id, Guid customerId);
        
        Task<Customer> GetCustomer(Guid id);
        
        Task<Customer> CreateCustomer();
        Task<List<CartLine>> GetCartLines(Guid customerId);
        Task Increment(Guid id);
        Task Decrement(Guid id);
        
    }
}