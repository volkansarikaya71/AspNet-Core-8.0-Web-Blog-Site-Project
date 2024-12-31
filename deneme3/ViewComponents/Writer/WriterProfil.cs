using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace deneme3.ViewComponents.Writer
{
    public class WriterProfil : ViewComponent
    {
        Context c=new Context();
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
