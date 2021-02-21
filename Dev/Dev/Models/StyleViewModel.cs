using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dev.Models
{
    public class StyleViewModel
    {
        public Style Style { get; set; }
        public ICollection<Style> Styles { get; internal set; }
    }
}
