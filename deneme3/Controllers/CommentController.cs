using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace deneme3.Controllers
{
    
    public class CommentController : Controller
    {
		CommentManager cm = new CommentManager(new EfCommentRepository());
        
		public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int parsedUserId = int.Parse(userId);
            var values = cm.GetCommentWithBlogByWriter(parsedUserId);
            return View(values);
        }
        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
			
			return PartialView();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult PartialAddComment(Comment p)
        {
            p.CommenDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.CommentStatus = true;
            p.BlogId = BlogController.BlogIdTutucu;
            cm.CommentAdd(p);
			return PartialView();
		}
        [AllowAnonymous]
        public PartialViewResult CommentListByBlog(int id)
        {
			var values = cm.Getlist(id);
            return PartialView(values);
        }

        [HttpPost]
        public IActionResult DeleteComment(int id)
        {
            var values = cm.GetById(id);
            cm.CommentDelete(values);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CommentContents(int id)
        {
            var values = cm.GetById(id);
            return View(values);
        }

    }
}
