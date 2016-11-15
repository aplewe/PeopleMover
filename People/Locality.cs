using System;

using PeopleManager.Enums;

namespace PeopleManager
{
    public class Locality
    {
        public int LocalityId { get; set; }

        public TerritoryType LocalityType { get; set; }

        public string LocalityName { get; set; }
    }
}
