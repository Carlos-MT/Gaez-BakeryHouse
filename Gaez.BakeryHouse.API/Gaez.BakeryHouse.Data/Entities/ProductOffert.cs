using System;
using System.Collections.Generic;

namespace Gaez.BakeryHouse.Data.Entities
{
    public partial class ProductOffert
    {
        public int ProductCode { get; set; }
        public int OffertId { get; set; }

        public virtual Offert Offert { get; set; } = null!;
        public virtual Product ProductCodeNavigation { get; set; } = null!;
    }
}
