using BusinessLayer.Interfaces;
using DataLayer.Interfaces;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class StyleService : IStyleService
    {
        private readonly IStyleRepository styleRepo;
        public StyleService(IStyleRepository styleRepo)
        {
            this.styleRepo = styleRepo;
        }
        public async Task<Style> CreateStyle(Style style)
        {
            return await styleRepo.CreateStyle(style);
        }

        public async Task<Style> GetStyleById(Guid guid)
        {
            return await styleRepo.GetStyleById(guid);
        }

        public async Task<Style> GetStyleByName(string name)
        {
            return await styleRepo.GetStyleByName(name);
        }

        public async Task<ICollection<Style>> GetStyles()
        {
            return await styleRepo.GetStyles();
        }
      
    }
}
