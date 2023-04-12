using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaez.BakeryHouse.Domain.Models
{
    public class ClientModel
    {
        public int ClientId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FatherLastName { get; set; }
        public string MotherLastName { get; set; }
    }
}
