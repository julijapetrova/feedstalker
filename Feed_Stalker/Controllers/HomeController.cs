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
            WebHookController webHookController = new WebHookController();
            ViewBag.Posts = webHookController.getWebHooks();
            //model: webHookController.getWebHooks()

            ViewBag.Feed = atomFeedService.GetFeed();
            //model: atomFeedService.GetFeed()

            return View(model: webHookController.getWebHooks());
        }

        [HttpPost]
        public void RegisterNewFeed(string url)
        {
            atomFeedService.RegisterFeed(url);
        }
    }
}