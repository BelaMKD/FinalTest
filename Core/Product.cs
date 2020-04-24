using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int ddvId { get; set; }
        public DDV DDV { get; set; }
    }
}
