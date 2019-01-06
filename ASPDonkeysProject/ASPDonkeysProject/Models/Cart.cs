using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPDonkeysProject.Models
{
    public class Cart
    {
        public Cart(int id, int ownerId, List<Donkey> donkeys)
        {
            Id = id;
            OwnerId = ownerId;
            UserDonkeys = donkeys;
        }
        // Cart for everyone will generate based on database, connection between user and cart needs to be added as soon as możemy xD
        public int Id { get; set; }

        public int OwnerId { get; set; }

        public List<Donkey> UserDonkeys { get; set; }
    }
}
