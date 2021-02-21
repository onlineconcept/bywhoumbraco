using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IStyleRepository
    {
        Task<Style> GetStyleById(Guid guid);
        Task<Style> GetStyleByName(string name);
        Task<ICollection<Style>> GetStyles();
        Task<Style> CreateStyle(Style style);
        Task UpdateStyle(Style style);
    }
}
