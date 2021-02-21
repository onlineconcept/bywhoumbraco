using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomers();
        Task<Customer> GetCustomerById(Guid id);
        Task<Customer> GetCustomerByEmail(string email);
        Task<Customer> CreateCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
    }
}