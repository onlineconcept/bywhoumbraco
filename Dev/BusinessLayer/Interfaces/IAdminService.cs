using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IAdminService
    {
        Task<List<Style>> GetStyles();
        Task CreateStyle(Style style);
        Task UpdateStyle(Style style);
        Task<List<Order>> GetOrders();
        Task UpdateOrder(Order order);
        Task<List<Customer>> GetCustomers();
    }
}