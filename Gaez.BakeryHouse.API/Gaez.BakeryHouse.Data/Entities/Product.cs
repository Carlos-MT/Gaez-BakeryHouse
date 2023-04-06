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
            Clients = new HashSet<Client>();
            ClientsNavigation = new HashSet<Client>();
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        public int ProductCode { get; set; }
        public string ProductName { get; set; } = null!;
        public DateTime ExpirityDate { get; set; }
        public decimal RegularPrice { get; set; }
        public int Valuation { get; set; }
        public string Description { get; set; } = null!;
        public string Application { get; set; } = null!;
        public int Stock { get; set; }
        public byte[]? ProductImage { get; set; }

        public virtual ProductBelongsToCategory? ProductBelongsToCategory { get; set; }
        public virtual ProviderProvidesProduct? ProviderProvidesProduct { get; set; }
        public virtual ICollection<ProductHasComment> ProductHasComments { get; set; }
        public virtual ICollection<ProductOffert> ProductOfferts { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Client> ClientsNavigation { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
