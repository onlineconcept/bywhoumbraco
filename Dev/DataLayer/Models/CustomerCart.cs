using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class CustomerCart
    {
        public int Id { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
