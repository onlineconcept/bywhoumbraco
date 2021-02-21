using DataLayer.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    public class Style
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        [DecimalPrecision(18,2)]
        public decimal Price { get; set; }
        [DecimalPrecision(18, 2)]
        public decimal OldPrice { get; set; }
        [DecimalPrecision(18, 2)]
        public decimal B2BPrice { get; set; }
        public string Picture { get; set; }
        public string Poster { get; set; }
        public int AmountOfPictures { get; set; }
        public bool Published { get; set; }       
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public int SortOrder { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        public bool NoFollow { get; set; }
        public string SeName { get; set; }
        public bool HasText { get; set; }
    }
}

