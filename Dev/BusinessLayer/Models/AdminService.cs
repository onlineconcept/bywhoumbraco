using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using DataLayer.Interfaces;
using DataLayer.Models;

namespace BusinessLayer.Models
{
    public class AdminService:IAdminService
    {
        private readonly IStyleRepository _styleRepo;
        private readonly IOrderService _orderService;

        public AdminService(IStyleRepository styleRepo,IOrderService orderService)
        {
            _styleRepo = styleRepo;
            _orderService = orderService;
        }
        
        public async Task<List<Style>> GetStyles()
        {
            var styles = await _styleRepo.GetStyles();
            return styles.ToList();
        }

        public async Task CreateStyle(Style style)
        {
            await _styleRepo.CreateStyle(style);
        }

        public async Task UpdateStyle(Style style)
        {
            await _styleRepo.UpdateStyle(style);
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _orderService.GetOrders();
        }

        public async Task UpdateOrder(Order order)
        {
            await _orderService.UpdateOrder(order);
        }

        public async Task<List<Customer>> GetCustomers()
        {
            throw new System.NotImplementedException();
        }
    }
}