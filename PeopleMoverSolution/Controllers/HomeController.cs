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
            DataAccess da = new DataAccess();

            var people = da.SearchActivePeople("a");

            foreach (Person p in people.PersonList)
            {
                if (p.ProfileImageLink == "default.png")
                {
                    p.ProfileImageLink = "Content/default.png";
                }
            }

            return View(people);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}