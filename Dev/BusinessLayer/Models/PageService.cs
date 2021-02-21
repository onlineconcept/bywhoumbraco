using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using DataLayer.Interfaces;
using DataLayer.Models;

namespace BusinessLayer.Models
{
    public class PageService: IPageService
    {
        private readonly IPageRepository _pageRepository;

        public PageService(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }
        public async Task<Topic> GetTopicByName(string name)
        {
            
            return await _pageRepository.GetPageByName(name);
        }
        public async Task<List<Topic>> GetSubpagesById(int id)
        {
            
            return await _pageRepository.GetSubpagesById(id);
        }

    }
}