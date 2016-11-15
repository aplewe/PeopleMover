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

        public People SearchActivePeople(string name)
        {
            People foundPeople = new People();

            //entity framework search, because we're not doing fancy with NoSQL:
            foundPeople.PersonList = (from Person p in DbPeople where p.Name.Contains(name) && p.IsActive == true select p).ToList();

            return foundPeople;
        }

        public void AddPerson(Person p)
        {
            //save the person:
            DbPeople.Add(p);
            SaveChanges();
        }

        public void UpdatePerson(Person p)
        {
            //update the person:
            Entry(p).State = EntityState.Modified;
            SaveChanges();
        }

        public void DeletePerson(Person p)
        {
            //Remove the person, but not really (set isactive flag = false):
            p.IsActive = false;
            Entry(p).State = EntityState.Modified;
            SaveChanges();
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
                p.Interests = new List<Interest>();
                p.Interests.Add(Builder<Interest>.CreateNew());
                p.Interests.Add(Builder<Interest>.CreateNew());
                p.ProfileImageLink = "default.png";

                p.IsActive = true;

                AddPerson(p);
            }
        }
    }
}
