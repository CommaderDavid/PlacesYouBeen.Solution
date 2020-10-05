using Microsoft.AspNetCore.Mvc;

namespace PlacesYouBeen.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }

    }
}