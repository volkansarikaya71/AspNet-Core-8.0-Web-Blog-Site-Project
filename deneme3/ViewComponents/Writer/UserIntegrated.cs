using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace deneme3.ViewComponents.Writer
{
    public class UserIntegrated : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var username = User.Identity.Name;
            var userid = c.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
			var namesurname = c.Users.Where(x => x.Id == userid).Select(y => y.NameSurname).FirstOrDefault();
			ViewBag.Username = username;
			ViewBag.namesurname = namesurname;
			return View();
        }
    }
}
