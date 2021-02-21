using DataLayer.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    public class Giftcard
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [DecimalPrecision(18, 2)]
        public decimal Amount { get; set; }
        public string GiftCardCode { get; set; }
        public virtual Order PuchasedWithOrder { get; set; }
        public bool Active { get; set; }
        public DateTime ValidTo { get; set; } = DateTime.UtcNow.AddYears(5);
    }
}
