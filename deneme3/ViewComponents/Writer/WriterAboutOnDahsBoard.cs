using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;

namespace deneme3.ViewComponents.Writer
{
    public class WriterAboutOnDahsBoard:ViewComponent
    {
        //WriterManager wm = new WriterManager(new EfWriterRepository());
        //UserManager um=new UserManager(new EfUserRepository());
		Context c = new Context();
		public IViewComponentResult Invoke()
        {
           
            var username = User.Identity.Name;
            var userabout=c.Users.Where(x=>x.UserName==username).Select(y=>y.UserAbout).FirstOrDefault();
            var userimage = c.Users.Where(x => x.UserName == username).Select(y => y.ImageUrl).FirstOrDefault();
            var NameSurname = c.Users.Where(x => x.UserName == username).Select(y => y.NameSurname).FirstOrDefault();
            ViewBag.NameSurname = NameSurname;
            ViewBag.userabout = userabout;
            ViewBag.userimage = userimage;
            //var WriterId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            //var values = wm.GetWriterById(userid);
            return View(/*values*/);
        }
    }
}
