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

            var results = pda.SearchPeople("a");

            Assert.IsTrue(results.PersonList.Count > 0);
        }
    }
}
