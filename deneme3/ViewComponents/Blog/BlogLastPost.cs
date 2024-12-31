using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace deneme3.ViewComponents.Blog
{
    public class BlogLastPost : ViewComponent
    {
            BlogManager bm = new BlogManager(new EfBlogRepository());

            public IViewComponentResult Invoke()
            {
                var values = bm.GetLastBlog();
                return View(values);
            }
        }
}
