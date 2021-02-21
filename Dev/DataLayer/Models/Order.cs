using DataLayer.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;
using System.Text;

namespace DataLayer.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OrderId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string HusNo { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [DecimalPrecision(18, 2)]
        public decimal OrderTotalTaxINCL { get; set; }
        [DecimalPrecision(18, 2)]
        public decimal OrderTotalTaxEXCL { get; set; }
        [DecimalPrecision(18, 2)]
        public decimal OrderSubTotalTaxINCL { get; set; }
        [DecimalPrecision(18, 2)]
        public decimal OrderSubTotalTaxEXCL { get; set; }
        [DecimalPrecision(18, 2)]
        public decimal Shipping { get; set; }
        [DecimalPrecision(18, 2)]
        public decimal DiscountAmount { get; set; }
        [DecimalPrecision(18, 2)]
        public decimal GiftAmount { get; set; }
        public string Comment { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
    }
}
