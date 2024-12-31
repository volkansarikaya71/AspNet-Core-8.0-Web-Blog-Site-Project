using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace deneme3.ViewComponents.Writer
{
    public class WriterProfil2:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            var userimage = c.Users.Where(x => x.UserName == username).Select(y => y.ImageUrl).FirstOrDefault();
            var NameSurname = c.Users.Where(x => x.UserName == username).Select(y => y.NameSurname).FirstOrDefault();
            ViewBag.NameSurname = NameSurname;
            ViewBag.userimage = userimage;
            return View();
        }
    }
}
