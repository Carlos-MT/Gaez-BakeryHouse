using System;
using System.Collections.Generic;
using System.Text;

namespace Gaez.BakeryHouse.Models
{
    public class CommentModel
    {
        public int CommentId { get; set; }
        public DateTime CommentDate { get; set; }
        public int Valoration { get; set; }
        public string Description { get; set; }
    }
}
