using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.Interfaces
{
    public interface ISizeRepository
    {
        Task<List<Size>> GetSizes();
        Task<Size> GetSizeById(int id);
    }
}