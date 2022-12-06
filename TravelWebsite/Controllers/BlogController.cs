using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelWebsite.Models.Classes;

namespace TravelWebsite.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c = new Context();
        BlogComment bc = new BlogComment();

        public ActionResult Index()
        {
            bc.Deger1 = c.Blogs.ToList();
            bc.Deger3 = c.Blogs.OrderByDescending(y => y.ID).Take(3).ToList();
            return View(bc);
        }
        public ActionResult BlogDescription(int id)
        {
            bc.Deger1 = c.Blogs.Where(x => x.ID == id).ToList();
            bc.Deger2 = c.Comments.Where(x => x.BlogId == id).ToList();
            //var findBlog = c.Blogs.Where(x => x.ID == id).ToList();
            return View(bc);
        }
        [HttpGet]
        public PartialViewResult MakeComment(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult MakeComment(Comment bc)
        {
            c.Comments.Add(bc);
            c.SaveChanges();
            return PartialView();
        }
    }
}