using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    public class Picture
    {
        [Key]
        public Guid Id { get; set; }
        public string Path { get; set; }
    }
}
