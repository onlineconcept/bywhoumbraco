using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using DataLayer.Interfaces;
using DataLayer.Models;

namespace BusinessLayer.Models
{
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<List<Order>> GetOrders()
        {
            return await _orderRepository.GetOrders();
        }

        public async Task<Order> GetOrderById(Guid id)
        {
            return await _orderRepository.GetOrderById(id);
        }

        public async Task UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CreateCustomerCart(CustomerCart customer)
        {
            return await _orderRepository.CreateCustomerCart(customer);
        }

        public async Task<Customer> GetCustomerCart(int id)
        {
            return await _orderRepository.GetCustomerCart(id);
        }
    }
}