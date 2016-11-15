using System.Collections.Generic;
using PeopleManager.Enums;

namespace PeopleManager
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string PostalCode { get; set; }

        public List<Locality> Localities { get; set; }

        public string Country { get; set; }

        public Address()
        {
            Localities = new List<Locality>();
        }
    }
}
