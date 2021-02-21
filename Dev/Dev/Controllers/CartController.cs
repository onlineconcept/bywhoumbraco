using System;
using System.IO;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using DataLayer.DTO;
using DataLayer.Interfaces;
using DataLayer.Models;
using Dev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.JSInterop.Infrastructure;

namespace Dev.Controllers
{
    public class CartController: Controller
    {
        private readonly ICartService _cartService;
        private readonly ICustomerRepository _customerRepository;

        public CartController(ICartService cartService, ICustomerRepository customerRepository)
        {
            _cartService = cartService;
            _customerRepository = customerRepository;
        }
        public async Task<IActionResult> Index()
        {
            
            
            return View();
        }
        
        
        [Route("cart/cartlines")]
        public async Task<IActionResult> GetCartLines(Guid customerId)
        {
            return Ok(await _cartService.GetCartLines(customerId));
        }

        [Route("cart/createcart")]
        public async Task<IActionResult> CreateCart()
        {
            var customer = await _cartService.CreateCustomer();
            return Ok(customer.Id);
        }
        
        [Route("cart/addtocart")]
        public IActionResult AddToCart([FromBody] AddToCartDTO dto)
        {
            try
            {
                foreach (var pic in dto.Pictures)
                {
                    string filePath = Directory.GetCurrentDirectory() + "/wwwroot/images/" + Guid.NewGuid() + "." + pic.Split(';')[0].Split('/')[1];
                    var baseStr = pic.Split(',')[1];
                    System.IO.File.WriteAllBytes(filePath, Convert.FromBase64String(baseStr));
                }

                _cartService.AddToCart(dto);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                return BadRequest(new {Error = ex.Message});
            }

        }
        [Route("cart/updatecustomer")]
        [HttpPost]
        public async  Task<IActionResult> UpdateCustomer([FromBody] UpdateDTO dto)
        {
            var customer = await _customerRepository.GetCustomerById(Guid.Parse(dto.CustomerId));
            customer.Address = dto.Customer.Address;
            customer.City = dto.Customer.City;
            customer.Email = dto.Customer.Email;
            customer.Name = dto.Customer.Firstname + " " + dto.Customer.Lastname;
            customer.Phone = dto.Customer.Phone;
            customer.Zipcode = dto.Customer.Zipcode;
            await _customerRepository.UpdateCustomer(customer);
            return Ok();

        }
        [Route("cart/product/increment/{id}")]
        public IActionResult Increment(Guid id)
        {
            try
            {
                _cartService.Increment(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new {Error = ex.Message});
            }

        }
        [Route("cart/product/decrement/{id}")]
        public IActionResult Decrement(Guid id)
        {
            try
            {
                _cartService.Decrement(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new {Error = ex.Message});
            }

        }
        
    }
}