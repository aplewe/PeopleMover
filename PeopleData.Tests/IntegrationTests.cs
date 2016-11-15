using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PeopleData.Tests
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public void Add10FakePeople()
        {
            DataAccess pda = new DataAccess();

            pda.MocPeople(10);

            //do a search:

            var results = pda.SearchActivePeople("a");

            Assert.IsTrue(results.PersonList.Count > 0);
        }

        //TODO: the search works because of the mocking framework being used. Devise a better test that is framework independent
        [TestMethod]
        public void ModifyAPerson()
        {
            DataAccess pda = new DataAccess();

            var results = pda.SearchActivePeople("a");

            if (results.PersonList.Count > 0)
            {
                string newName = Guid.NewGuid().ToString();

                results.PersonList[0].Name = newName;

                pda.UpdatePerson(results.PersonList[0]);

                var newNameResults = pda.SearchActivePeople(newName);

                Assert.IsTrue(newNameResults.PersonList.Count == 1);
            }
            else
            {
                pda.MocPeople(2);

                results = pda.SearchActivePeople("a");

                string newName = Guid.NewGuid().ToString();

                results.PersonList[0].Name = newName;

                pda.UpdatePerson(results.PersonList[0]);

                var newNameResults = pda.SearchActivePeople(newName);

                Assert.IsTrue(newNameResults.PersonList.Count == 1);
            }
        }
    }
}
