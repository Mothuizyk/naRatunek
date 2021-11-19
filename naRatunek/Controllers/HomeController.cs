using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace naRatunek.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string city="", string optradio = "")
        {
            return View();
        } 
        
        public ActionResult GetNearMyLocation(string currentlat, string currentLng)
        {
            using (var context = new Data.naRatunekContext())
            {
                var currentLocation = DbGeography.FromText("POINT("+ currentlat +"" +currentLng+")");
               // var places = (from  u in context.Hospitals orderby u.ge)
            }
            return View();
        }

        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}