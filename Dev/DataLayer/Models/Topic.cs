using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    public class Topic
    {
        [Key]
        public int Id { get; set; }
        public string SystemName { get; set; }
        public string Title { get; set; }
        public string BodyTekst { get; set; }
        public bool IsPage { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        public bool NoFollow { get; set; }
        public virtual Topic Subpage { get; set; }
    }
}
