using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IPageService
    {
        Task<Topic> GetTopicByName(string name);
        Task<List<Topic>> GetSubpagesById(int id);

    }
}