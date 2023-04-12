using System;
using System.Collections.Generic;
using System.Text;

namespace Gaez.BakeryHouse.API.Models
{
    public class CommentModel
    {
        public int CommentId { get; set; }
        public DateTime CommentDate { get; set; }
        public int Valoration { get; set; }
        public string Description { get; set; }
        public string FirstName { get; set; }
        public string FatherLastName { get; set; }
        public string MotherLastName { get; set; }

    }
}
