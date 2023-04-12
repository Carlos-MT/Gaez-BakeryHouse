using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaez.BakeryHouse.Domain.Models
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
