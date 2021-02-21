using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using DataLayer.Interfaces;
using DataLayer.Models;

namespace BusinessLayer.Models
{
    public class SizeService:ISizeService
    {
        private readonly ISizeRepository _sizeRepo;

        public SizeService(ISizeRepository sizeRepo)
        {
            _sizeRepo = sizeRepo;
        }
        public async Task<List<Size>> GetSizes()
        {
            return await _sizeRepo.GetSizes();
        }
    }
}