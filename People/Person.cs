using System;
using System.Collections.Generic;

namespace PeopleManager
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Address HomeAddress { get; set; }

        //use a CDN:
        public string ProfileImageLink { get; set; }

        public List<string> Interests { get; set; }

        public bool IsActive { get; set; }

        public Person()
        {
            HomeAddress = new Address();
            Interests = new List<string>();
            IsActive = true;
        }
    }
}
