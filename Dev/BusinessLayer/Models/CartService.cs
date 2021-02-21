using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using DataLayer.DTO;
using DataLayer.Interfaces;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace BusinessLayer.Models
{
    public class CartService:ICartService
    {
        private readonly ICartRepository _cartRepo;
        private readonly IStyleRepository _styleRepo;
        private readonly ISizeRepository _sizeRepo;

        public CartService(ICartRepository  cartRepo, IStyleRepository styleRepo,ISizeRepository sizeRepo)
        {
            _cartRepo = cartRepo;
            _styleRepo = styleRepo;
            _sizeRepo = sizeRepo;
        }
        
        public async Task<List<CartLine>> GetCartLines(Guid customerId)
        {
            return await _cartRepo.GetCartLines(customerId);
        }

        public async Task<decimal> GetTotal(Guid customerid)
        {
            var lines = await GetCartLines(customerid);
            var total = lines.Sum(x => x.Price * x.Quantity);
            return total;
        }

        public Task Increment(Guid id)
        {
            return _cartRepo.Increment(id);
        }

        public Task Decrement(Guid id)
        {
            return _cartRepo.Decrement(id);
        }


        public void AddToCart(AddToCartDTO dto)
        {
            try
            {
                var extra = 0;
                if (dto.Pictures.Count > 5)
                {
                    var extraPictures = dto.Pictures.Count - 5;
                    extra += 100 * extraPictures;
                }
                var line = new CartLine();
                line.Id = Guid.NewGuid();
                line.Customer = GetCustomer(dto.CustomerId).Result;
                line.Style = _styleRepo.GetStyleById(dto.StyleId).Result;
                line.Size = _sizeRepo.GetSizeById(dto.SizeId).Result;
                line.Price = line.Style.Price + extra;
                line.Text = dto.Text;
                line.Comments = dto.StyleComments; 
                line.Quantity = 1;
                foreach (var pic in dto.Pictures)
                {
                    string filePath = Directory.GetCurrentDirectory() + "/wwwroot/images/" + Guid.NewGuid() + "." + pic.Split(';')[0].Split('/')[1];
                    var baseStr = pic.Split(',')[1];
                    System.IO.File.WriteAllBytes(filePath, Convert.FromBase64String(baseStr));
                    line.Pictures.Add(new Picture
                    {
                        Id = Guid.NewGuid(),
                        Path = filePath

                    });
                }

                _cartRepo.AddToCart(line);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoveFromCart(Guid id, Guid customerId)
        {
            _cartRepo.RemoveFromCart(id,customerId);
        }

        public async Task<Customer> GetCustomer(Guid id)
        {
            return await _cartRepo.GetCustomer(id);
        }

        public async Task<Customer> CreateCustomer()
        {
            return await _cartRepo.CreateCustomer();
        }
    }
}