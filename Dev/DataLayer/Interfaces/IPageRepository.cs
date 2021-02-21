using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.Interfaces
{
    public interface IPageRepository
    {
        Task<Topic> GetPageByName(string name);
        Task<List<Topic>> GetSubpagesById(int id);
    }
}