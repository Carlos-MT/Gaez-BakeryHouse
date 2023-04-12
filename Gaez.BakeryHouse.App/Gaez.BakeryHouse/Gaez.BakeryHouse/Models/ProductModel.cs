using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Gaez.BakeryHouse.API.Models
{
    public class ProductModel
    {
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public DateTime ExpirityDate { get; set; }
        public decimal RegularPrice { get; set; }
        public int Valuation { get; set; }
        public string Description { get; set; }
        public string Application { get; set; }
        public int Stock { get; set; }
        public byte[] ProductImage { get; set; }
    }
}
