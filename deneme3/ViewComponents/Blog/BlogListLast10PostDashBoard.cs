using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace deneme3.ViewComponents.Blog
{
    public class BlogListLast10PostDashBoard : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());

        public IViewComponentResult Invoke()
        { 
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            int parsedUserId = int.Parse(userId);
            var values = bm.GetLast10Blog(parsedUserId);
            return View(values);
        }
    }
}
