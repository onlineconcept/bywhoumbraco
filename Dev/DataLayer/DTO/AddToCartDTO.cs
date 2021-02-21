using System;
using System.Collections.Generic;

namespace DataLayer.DTO
{
    public class AddToCartDTO
    {
        public List<string> Pictures { get; set; }
        public int SizeId { get; set; }
        public Guid StyleId { get; set; }
        public string Text { get; set; }
        public string StyleComments { get; set; }
        public Guid CustomerId { get; set; }
    }
}