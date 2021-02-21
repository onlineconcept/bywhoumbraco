using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Picture { get; set; }
        public bool Published { get; set; }
        public string SeName { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        public bool NoFollow { get; set; }

    }
}
