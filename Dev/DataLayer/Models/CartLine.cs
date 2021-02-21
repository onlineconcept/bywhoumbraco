using DataLayer.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class CartLine
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public virtual  Customer Customer { get; set; }
        [DecimalPrecision(18, 2)]
        public decimal Price { get; set; }
        public string Text { get; set; }
        public string Comments { get; set; }
        public List<Picture> Pictures { get; set; } = new List<Picture>();
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public virtual Style Style { get; set; }
        public virtual Size Size { get; set; }
        public int Quantity { get; set; } = 1;
    }
}