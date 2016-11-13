using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using PeopleManager;
using PeopleManager.Enums;

using TestStack.Dossier;

namespace PeopleData
{
    public class DataAccess : DbContext
    {
        public DbSet<Person> DbPeople { get; set; }


        public People SearchPeople(string name)
        {
            PeopleManager.People foundPeople = new PeopleManager.People();

            //entity framework search, because we're not doing fancy with NoSQL:
            foundPeople.PersonList = (from Person p in DbPeople where p.Name.Contains(name) select p).ToList();

            return foundPeople;
        }

        public bool AddPerson(Person p)
        {
            bool success = true;

            try
            {
                //save the person:
                DbPeople.Add(p);
                SaveChanges();
            }
            catch
            {
                success = false;
            }

            return success;
        }

        public void UpdatePerson(Person p)
        {
            //update the person:
        }

        public void DeletePerson(Person p)
        {
            //Remove the person, but not really (set isactive flag = false):
            
        }

        public void MocPeople(int peopleCount)
        {
            var fakePeople = Builder<Person>.CreateListOfSize(peopleCount).BuildList();

            foreach (Person p in fakePeople)
            {
                p.HomeAddress = Builder<Address>.CreateNew();
                p.HomeAddress.Localities = new List<Locality>();
                p.HomeAddress.Localities.Add(Builder<Locality>.CreateNew());
                p.HomeAddress.Localities.Add(Builder<Locality>.CreateNew());
                p.Interests = new List<string>();
                p.Interests.Add(Guid.NewGuid().ToString());
                p.Interests.Add(Guid.NewGuid().ToString());

                AddPerson(p);
            }
        }
    }
}
