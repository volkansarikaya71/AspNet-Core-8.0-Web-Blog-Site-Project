
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace deneme3.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4:ViewComponent
    {
        Context c=new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.AdminName=c.Admins.Where(x=>x.AdminId==1).Select(x=>x.Name).FirstOrDefault();
            ViewBag.AdminImage = c.Admins.Where(x => x.AdminId == 1).Select(x => x.ImageUrl).FirstOrDefault();
            ViewBag.AdminShortDescription = c.Admins.Where(x => x.AdminId == 1).Select(x => x.ShortDescription).FirstOrDefault();
            return View();
        }
    }
}
