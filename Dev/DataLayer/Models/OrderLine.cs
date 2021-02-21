using DataLayer.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class OrderLine
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [DecimalPrecision(18, 2)]
        public decimal Price { get; set; }
        public string Text { get; set; }
        public string Comments { get; set; }
        public List<Picture> Pictures { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public virtual Guid Style { get; set; }
    }
}