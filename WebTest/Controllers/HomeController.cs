using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTest.Models;

namespace WebTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        [HttpGet]
        public ActionResult Test()
        {
            return View(new TestModel()
            {
                RequiredIntControl = "require Some int",
                SomeIntThatMightBeRequired = 100,
                SomeValue = 60,
                RequiredInt = 61,
                SomeOtherDate = DateTime.Today,
                SomeDate = DateTime.Today.AddDays(-1.0),
                HiddentInt = 55,
                HiddenDateTime = DateTime.Today,
                KendoDateOther = DateTime.Today,
                KendoDate = DateTime.Today
            });
        }

        [HttpPost]
        public ActionResult Test(TestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return View(model);
        }
    }
}