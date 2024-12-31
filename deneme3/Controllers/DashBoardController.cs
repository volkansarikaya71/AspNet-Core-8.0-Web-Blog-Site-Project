using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace deneme3.Controllers
{
    public class DashBoardController : Controller
    {
        
        public IActionResult Index()
        {
            Context c=new Context();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int parsedUserId = int.Parse(userId);
            ViewBag.TotalBlog = c.Blogs.Count(x =>x.BlogStatus == true);
            ViewBag.WriterTotalBlog = c.Blogs.Where(x=>x.WriterId == parsedUserId && x.BlogStatus == true).Count();
            ViewBag.TotalCategory = c.Categories.Count(x => x.CategoryStatus == true);
            return View();


        }
    }
}
