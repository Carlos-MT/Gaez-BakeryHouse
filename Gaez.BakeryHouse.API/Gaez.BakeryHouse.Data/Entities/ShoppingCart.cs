using System;
using System.Collections.Generic;

namespace Gaez.BakeryHouse.Data.Entities
{
    public partial class ShoppingCart
    {
        public ShoppingCart()
        {
            ShoppingCartBelongsToClients = new HashSet<ShoppingCartBelongsToClient>();
        }

        public int ShoppingCartId { get; set; }
        public int TotalProducts { get; set; }
        public decimal Subtotal { get; set; }

        public virtual ICollection<ShoppingCartBelongsToClient> ShoppingCartBelongsToClients { get; set; }
    }
}
