using System;
using System.Collections.Generic;

namespace Gaez.BakeryHouse.Data.Entities
{
    public partial class Client
    {
        public Client()
        {
            ClientMakesComments = new HashSet<ClientMakesComment>();
            ProductCodes = new HashSet<Product>();
            ProductCodesNavigation = new HashSet<Product>();
        }

        public int ClientId { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FirstName { get; set; }
        public string FatherLastName { get; set; }
        public string MotherLastName { get; set; }

        public virtual ShoppingCartBelongsToClient? ShoppingCartBelongsToClient { get; set; }
        public virtual ICollection<ClientMakesComment> ClientMakesComments { get; set; }

        public virtual ICollection<Product> ProductCodes { get; set; }
        public virtual ICollection<Product> ProductCodesNavigation { get; set; }
    }
}
