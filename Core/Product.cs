using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "Product Name"),Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public int ddvId { get; set; }
        public DDV DDV { get; set; }
        public int TaxPayerId { get; set; }
        public TaxPayer TaxPayer { get; set; }
    }
}
