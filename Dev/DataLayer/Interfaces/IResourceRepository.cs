using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IResourceRepository
    {
        Task<List<Resource>> GetAllResource();
    }
}
