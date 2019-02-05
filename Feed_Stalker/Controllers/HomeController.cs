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
           
            ViewBag.Feed = atomFeedService.GetFeed();


            return View(model: atomFeedService.GetFeed());
        }

        [HttpPost]
        public void RegisterNewFeed(string url)
        {
            atomFeedService.RegisterFeed(url);
        }
    }
}