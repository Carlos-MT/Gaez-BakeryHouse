using System;
using System.Collections.Generic;

namespace Gaez.BakeryHouse.Data.Entities
{
    public partial class ShoppingCart
    {
        public ShoppingCart()
        {
            ShoppingCartBelongsToClients = new HashSet<ShoppingCartBelongsToClient>();
            ProductCodes = new HashSet<Product>();
        }

        public int ShoppingCartId { get; set; }
        public int TotalProducts { get; set; }
        public decimal Subtotal { get; set; }

        public virtual ICollection<ShoppingCartBelongsToClient> ShoppingCartBelongsToClients { get; set; }

        public virtual ICollection<Product> ProductCodes { get; set; }
    }
}
