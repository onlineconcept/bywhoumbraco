using DataLayer.System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Size
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [DecimalPrecision(18, 2)]
        public decimal Price { get; set; } = 0;
        [DecimalPrecision(18, 2)]
        public decimal Height { get; set; }
        [DecimalPrecision(18, 2)]
        public decimal Width { get; set; }
        public SizeType SizeType { get; set; }       
    }

    public enum SizeType
    {
        poster
    }
}