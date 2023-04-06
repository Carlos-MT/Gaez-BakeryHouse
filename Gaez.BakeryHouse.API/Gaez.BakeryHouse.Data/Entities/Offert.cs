using System;
using System.Collections.Generic;

namespace Gaez.BakeryHouse.Data.Entities
{
    public partial class Offert
    {
        public int OffertId { get; set; }
        public decimal Discount { get; set; }
        public DateTime InitDate { get; set; }
        public DateTime FinishDate { get; set; }

        public virtual ProductOffert? ProductOffert { get; set; }
    }
}
