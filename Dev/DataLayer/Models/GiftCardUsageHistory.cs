using DataLayer.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    public class GiftcardUsageHistory
    {
        [Key]
        public long Id { get; set; }
        [DecimalPrecision(18, 2)]
        public decimal UsedValue { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public virtual Giftcard Giftcard { get; set; }
        public virtual Order UsedWithOrder { get; set; }
    }
}
