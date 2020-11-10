using Microsoft.AspNetCore.Mvc;
using PlacesYouBeen.Models;
using System.Collections.Generic;

namespace PlacesYouBeen.Controllers
{
    public class PlacesController : Controller
    {
        [HttpGet("/places")]
        public ActionResult Index()
        {
            List<Place> allPlaces = Place.GetAll();
            return View(allPlaces);
        }

        [HttpGet("/places/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/places")]
        public ActionResult Create(string cityName, string duration, string group, string journalEntry)
        {
            Place myPlace = new Place(cityName, duration, group, journalEntry);
            myPlace.Save();
            return RedirectToAction("Index");
        }

        [HttpPost("/places/delete")]
        public ActionResult DeleteAll()
        {
            Place.ClearAll();
            return View();
        }

        [HttpGet("/places/{id}")]
        public ActionResult Show(int id)
        {
            Place foundPlace = Place.Find(id);
            return View(foundPlace);
        }
    }
}