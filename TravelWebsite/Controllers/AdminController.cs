using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelWebsite.Models.Classes;

namespace TravelWebsite.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult NewBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteBlog(int id)
        {
            var blog = c.Blogs.Find(id);
            c.Blogs.Remove(blog);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ReturnBlog(int id)
        {
            var bl = c.Blogs.Find(id);
            return View("ReturnBlog", bl);
        }

        public ActionResult UpdateBlog(Blog b)
        {
            var blg = c.Blogs.Find(b.ID);
            blg.Title = b.Title;
            blg.Description = b.Description;
            blg.BlogImage = b.BlogImage;
            blg.Date = b.Date;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Comment()
        {
            var degerler = c.Comments.ToList();
            return View(degerler);
        }

        public ActionResult DeleteComment(int id)
        {
            var comment = c.Comments.Find(id);
            c.Comments.Remove(comment);
            c.SaveChanges();
            return RedirectToAction("Comment");
        }

        public ActionResult ReturnComment(int id)
        {
            var cmt = c.Comments.Find(id);
            return View("ReturnComment", cmt);
        }
        
        public ActionResult UpdateComment(Comment cmnt)
        {
            var cmt = c.Comments.Find(cmnt.ID);
            cmt.UserName = cmnt.UserName;
            cmt.Email = cmnt.Email;
            cmt.Blog.Title = cmnt.Blog.Title;
            cmt.CommentDetailed = cmnt.CommentDetailed;
            c.SaveChanges();
            return RedirectToAction("Comment");
        }
    }
}