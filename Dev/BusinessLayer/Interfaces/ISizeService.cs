using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface ISizeService
    {
        Task<List<Size>> GetSizes();
    }
}