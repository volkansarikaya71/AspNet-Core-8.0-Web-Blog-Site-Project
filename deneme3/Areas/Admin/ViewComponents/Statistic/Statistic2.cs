using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace deneme3.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.LastBlog = c.Blogs.OrderByDescending(x => x.BlogId).Select(x => x.BlogTitle).Take(1).FirstOrDefault();
            //ViewBag.LastBlogImage = c.Blogs.OrderByDescending(x => x.BlogId).Select(x => x.BlogImage).Take(1).FirstOrDefault();

            return View();
        }
    }
}
