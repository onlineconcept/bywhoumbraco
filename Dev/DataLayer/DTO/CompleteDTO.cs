using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DataLayer.DTO
{
    public class CompleteDTO
    {
        public Customer OrderCustomer { get; set; }
        public Customer NewCart { get; set; }
        public List<CartLine> CartLines { get; set; }
        public string Response { get; set; }
        public HttpStatusCode ResponseCode { get; set; }
    }
}
