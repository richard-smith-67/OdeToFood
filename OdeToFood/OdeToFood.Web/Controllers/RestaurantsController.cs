using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        IRestaurantData db;
        
        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;
        }
        
        // GET: Restaurants
        public ActionResult Index()
        {
            return View(db.GetAll());
        }

        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            
            if(model == null)
            {
                return View("NotFound");
            }

            return View(model);
        }

        [HttpGet] //not necessary but nice to express explicitly
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if(ModelState.IsValid)
            {
                db.Add(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id });
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);

            if(model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if(ModelState.IsValid)
            {
                db.Edit(restaurant);
                TempData["Message"] = "Restaurant saved";
                return RedirectToAction("Details", new { id = restaurant.Id });
            }

            return View(restaurant);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        //Just adding FormCollection param as a way to avoid signature clash with above method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.Delete(id);
            return RedirectToAction("Index");

        }
    }
}