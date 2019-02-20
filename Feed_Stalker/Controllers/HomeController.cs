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
            //DBConnectionService db = new DBConnectionService();
            //Dictionary<string, SyndicationFeed> feeds = db.getAllFromDB();


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
        [HttpPost]
        public ActionResult Feeds()
        {
            string secretKeyInput = Request.Form["secret_key_input"];
            
            DBConnectionService db = new DBConnectionService();
            SyndicationFeed feed = db.GetFeed(secretKeyInput);

            TempData["SecretKey"] = secretKeyInput;

            return View(model: feed);
        }
    }
}