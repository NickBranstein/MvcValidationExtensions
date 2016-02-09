using System.Web.Mvc;

namespace WebTest.Controllers
{
    public class TestController : Controller
    {
        [HttpGet]
        public ActionResult RequiredIfEmpty()
        {
            return View();
        }
    }
}