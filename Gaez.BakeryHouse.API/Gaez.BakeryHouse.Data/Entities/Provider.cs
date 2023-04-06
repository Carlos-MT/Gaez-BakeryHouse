using System;
using System.Collections.Generic;

namespace Gaez.BakeryHouse.Data.Entities
{
    public partial class Provider
    {
        public Provider()
        {
            ProviderProvidesProducts = new HashSet<ProviderProvidesProduct>();
        }

        public int ProviderId { get; set; }
        public string ProviderName { get; set; } = null!;

        public virtual ICollection<ProviderProvidesProduct> ProviderProvidesProducts { get; set; }
    }
}
