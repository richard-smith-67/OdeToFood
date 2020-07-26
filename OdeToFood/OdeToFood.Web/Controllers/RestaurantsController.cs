﻿using OdeToFood.Data.Services;
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
        
        // GET: Reaturants
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
    }
}