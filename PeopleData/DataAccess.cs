using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using PeopleManager;
using PeopleManager.Enums;

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

        public bool UpdatePerson(Person p)
        {
            bool success = true;

            //update the person:

            return success;
        }

        public bool DeletePerson(Person p)
        {
            bool success = true;

            //Remove the person, but not really (set isactive flag = false):
            

            return success;
        }
    }
}
