using System;
using System.Collections.Generic;

namespace Gaez.BakeryHouse.Data.Entities
{
    public partial class ProductHasComment
    {
        public int ProductCode { get; set; }
        public int CommentId { get; set; }

        public virtual Comment Comment { get; set; } = null!;
        public virtual Product ProductCodeNavigation { get; set; } = null!;
    }
}
