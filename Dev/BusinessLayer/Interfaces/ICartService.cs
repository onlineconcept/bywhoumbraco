using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.DTO;
using DataLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface ICartService
    {
        void AddToCart(AddToCartDTO dto);
        void RemoveFromCart(Guid id, Guid customerId);
        Task<Customer> GetCustomer(Guid id);
        Task<Customer> CreateCustomer();
        Task<List<CartLine>> GetCartLines(Guid customerId);
        Task<decimal> GetTotal(Guid customerid);
        
        Task Increment(Guid id);
        Task Decrement(Guid id);
    }
}