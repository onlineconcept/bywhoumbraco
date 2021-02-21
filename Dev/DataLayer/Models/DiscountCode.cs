using DataLayer.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    public class DiscountCode
    {
        [Key]
        public int Id { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        [DecimalPrecision(18, 2)]
        public decimal Amount { get; set; }
        public bool IsPercentage { get; set; }
        public bool Active { get; set; }
    }
}
