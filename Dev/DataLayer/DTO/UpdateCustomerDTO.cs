using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DTO
{
    public class UpdateDTO
    {
        public string CustomerId { get; set; }
        public CustomerDTO Customer { get; set; }

    }
    public class CustomerDTO
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
