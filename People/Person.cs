using System;
using System.Collections.Generic;

namespace People
{
    public class Person
    {
        public string Name { get; set; }
        public UInt64 Id { get; set; }
        public int Age { get; set; }
        public Address HomeAddress { get; set; }

        //use a CDN:
        public string ProfileImageLink { get; set; }

        public List<string> Interests { get; set; }

        public Person()
        {
            HomeAddress = new Address();
            Interests = new List<string>();
        }
    }
}
