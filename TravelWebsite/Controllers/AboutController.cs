using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelWebsite.Models.Classes;
namespace TravelWebsite.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Abouts.ToList();
            return View(degerler);
        }
    }
}