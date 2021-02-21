using System.Collections.Generic;
using DataLayer.Models;

namespace Dev.Models
{
    public class PageViewModel
    {
        public Topic Page { get; set; }
        public List<Topic> SubPages { get; set; }
    }
}