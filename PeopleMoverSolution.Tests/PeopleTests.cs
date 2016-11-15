using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using PeopleManager;
using PeopleManager.Enums;

namespace PeopleMoverSolution.Tests
{
    [TestClass]
    public class PeopleTests
    {
        [TestMethod]
        public void CreateLocality()
        {
            Locality l = new Locality();

            l.LocalityName = "British Columbia";
            l.LocalityType = TerritoryType.Province;

            Assert.IsNotNull(l);
        }

        [TestMethod]
        public void CreateAddress()
        {
            Address aTest = new Address();

            aTest.Address1 = "blah";
            aTest.Address2 = "blah2";
            aTest.Country = "United States";
            aTest.PostalCode = "84101";

            Locality addressCity = new Locality();
            addressCity.LocalityName = "Salt Lake City";
            addressCity.LocalityType = TerritoryType.City;

            Locality addressState = new Locality();

            addressState.LocalityName = "Utah";
            addressState.LocalityType = TerritoryType.State;

            aTest.Localities.Add(addressState);

            Assert.IsNotNull(aTest);
            Assert.IsTrue(aTest.Localities.Count > 0);
        }

        [TestMethod]
        public void CreatePerson()
        {
            Person pTest = new Person();

            pTest.Age = 44;
            pTest.PersonId = 1;

            Assert.IsNotNull(pTest);
            Assert.IsNotNull(pTest.HomeAddress);
        }
    }
}
