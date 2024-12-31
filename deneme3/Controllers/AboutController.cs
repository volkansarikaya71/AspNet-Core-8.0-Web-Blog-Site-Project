using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace deneme3.Controllers
{
	public class AboutController : Controller
	{
		AboutManager abm = new AboutManager(new EfAboutRepository());

		public IActionResult Index()
		{
            var values = abm.Getlist();
            return View(values);
		}
		public PartialViewResult SocialMediaAbout()
		{

			return PartialView();
		}
	}
}
