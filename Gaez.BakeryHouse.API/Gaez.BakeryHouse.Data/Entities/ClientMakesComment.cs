using System;
using System.Collections.Generic;

namespace Gaez.BakeryHouse.Data.Entities
{
    public partial class ClientMakesComment
    {
        public int ClientId { get; set; }
        public int CommentId { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual Comment Comment { get; set; } = null!;
    }
}
