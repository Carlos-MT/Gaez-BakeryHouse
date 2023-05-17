using System;
using System.Collections.Generic;

namespace Gaez.BakeryHouse.Data.Entities
{
    public partial class Product
    {
        public Product()
        {
            ProductHasComments = new HashSet<ProductHasComment>();
            ProductOfferts = new HashSet<ProductOffert>();
        }

        public int ProductCode { get; set; }
        public string ProductName { get; set; } = null!;
        public string Application { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime ExpirityDate { get; set; }
        public int Stock { get; set; }
        public decimal RegularPrice { get; set; }
        public int Valuation { get; set; }
        public byte[]? ProductImage { get; set; }

        public virtual ProductBelongsToCategory? ProductBelongsToCategory { get; set; }
        public virtual ProviderProvidesProduct? ProviderProvidesProduct { get; set; }
        public virtual ICollection<ProductHasComment> ProductHasComments { get; set; }
        public virtual ICollection<ProductOffert> ProductOfferts { get; set; }
    }
}
