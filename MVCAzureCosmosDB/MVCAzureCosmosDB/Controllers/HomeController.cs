﻿using System.Web.Mvc;

namespace MVCAzureCosmosDB.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}