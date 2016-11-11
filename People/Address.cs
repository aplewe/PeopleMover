using System.Collections.Generic;
using People.Enums;

namespace People
{
    public class Address
    {
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public List<Locality> Localities { get; set; }

        public string Country { get; set; }

        public Address()
        {
            Localities = new List<Locality>();
        }
    }
}
