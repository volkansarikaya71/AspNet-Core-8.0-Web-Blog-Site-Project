using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace deneme3.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")]
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());

        public IActionResult Index()
        {
            var values = cm.GetCommentWithBlog();
            return View(values);
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
