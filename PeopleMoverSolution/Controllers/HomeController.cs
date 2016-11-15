using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PeopleManager;
using PeopleData;

namespace PeopleMoverSolution.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SearchPeople(string name)
        {
            DataAccess da = new DataAccess();

            var people = da.SearchActivePeople(name);

            foreach (Person p in people.PersonList)
            {
                if (p.ProfileImageLink == "default.png")
                {
                    p.ProfileImageLink = "Content/default.png";
                }
            }

            return PartialView("_PeopleResult", people.PersonList);
        }

        [HttpPost]
        public void MockPeople(int count)
        {
            DataAccess da = new DataAccess();

            da.MocPeople(count);
        }
    }
}