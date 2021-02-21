using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IStyleService
    {
        Task<Style> GetStyleById(Guid guid);
        Task<Style> GetStyleByName(string name);
        Task<ICollection<Style>> GetStyles();
        Task<Style> CreateStyle(Style style);
    }
}
