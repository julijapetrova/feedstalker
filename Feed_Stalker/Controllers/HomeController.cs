using Feed_Stalker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;

namespace Feed_Stalker.Controllers
{
    public class HomeController : Controller
    {
        AtomFeedService atomFeedService = new AtomFeedService();

        // GET: Home
        public ActionResult Index()
        {
            DBConnectionService db = new DBConnectionService();
            List<string> s = db.getAllFromDB();
            ViewBag.stringarray = s;
            
            return View();
        }
        [HttpPost]
        public ActionResult CreateAtomFeed()
        {
            string title = Request.Form["Title"];
            string uri = Request.Form["BaseUri"];
            string description = Request.Form["Description"];

            string secretKey = atomFeedService.createAtomFeed(title, description, uri);
            TempData["SecretKey"] = secretKey;
            return RedirectToAction("Index"); 
        }
    }
}