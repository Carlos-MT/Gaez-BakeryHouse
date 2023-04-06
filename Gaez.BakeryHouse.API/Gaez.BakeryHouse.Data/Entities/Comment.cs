using System;
using System.Collections.Generic;

namespace Gaez.BakeryHouse.Data.Entities
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public DateTime CommentDate { get; set; }
        public int Valoration { get; set; }
        public string Description { get; set; } = null!;

        public virtual ClientMakesComment? ClientMakesComment { get; set; }
        public virtual ProductHasComment? ProductHasComment { get; set; }
    }
}
