using System;
using System.Collections.Generic;
using System.Text;

namespace Gaez.BakeryHouse.API.Models
{
    public class ProductModel
    {
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Application { get; set; }
        public string Valuation { get; set; }
        public string RegularPrice { get; set; }
        public byte[] ProductImage { get; set; }
        public DateTime ExpirityDate { get; set; }
        public int Stock { get; set; }
    }
}
