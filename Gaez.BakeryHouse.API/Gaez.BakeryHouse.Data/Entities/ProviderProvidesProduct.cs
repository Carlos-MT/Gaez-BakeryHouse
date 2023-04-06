using System;
using System.Collections.Generic;

namespace Gaez.BakeryHouse.Data.Entities
{
    public partial class ProviderProvidesProduct
    {
        public int ProviderId { get; set; }
        public int ProductCode { get; set; }

        public virtual Product ProductCodeNavigation { get; set; } = null!;
        public virtual Provider Provider { get; set; } = null!;
    }
}
