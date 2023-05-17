using System;
using System.Collections.Generic;

namespace Gaez.BakeryHouse.Data.Entities
{
    public partial class Client
    {
        public Client()
        {
            ClientMakesComments = new HashSet<ClientMakesComment>();
        }

        public int ClientId { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string FatherLastName { get; set; } = null!;
        public string MotherLastName { get; set; } = null!;

        public virtual ShoppingCartBelongsToClient? ShoppingCartBelongsToClient { get; set; }
        public virtual ICollection<ClientMakesComment> ClientMakesComments { get; set; }
    }
}
