using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace deneme3.ViewComponents.Blog
{
    public class BlogCommentCount : ViewComponent
    {
        

        public IViewComponentResult Invoke(int id)
        {
            Context c = new Context();
            var CommentCounts = c.Comments.Count(x => x.BlogId == id);
            ViewBag.CommentCounts = CommentCounts;
            return View();
        }

    }
}
