using System;
using System.Collections.Generic;

namespace Gaez.BakeryHouse.Data.Entities
{
    public partial class ProductBelongsToCategory
    {
        public int CategoryId { get; set; }
        public int ProductCode { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual Product ProductCodeNavigation { get; set; } = null!;
    }
}
