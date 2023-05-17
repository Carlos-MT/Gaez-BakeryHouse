using System;
using System.Collections.Generic;

namespace Gaez.BakeryHouse.Data.Entities
{
    public partial class ClientSaveProduct
    {
        public int ClientId { get; set; }
        public int ProductCode { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual Product ProductCodeNavigation { get; set; } = null!;
    }
}
