using System;
using System.Collections.Generic;

namespace Gaez.BakeryHouse.Data.Entities
{
    public partial class ShoppingCartBelongsToClient
    {
        public int ShoppingCartId { get; set; }
        public int ClientId { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual ShoppingCart ShoppingCart { get; set; } = null!;
    }
}
