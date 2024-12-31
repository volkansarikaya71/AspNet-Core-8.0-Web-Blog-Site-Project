using DataAccessLayer.Concrete;
using deneme3.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace deneme3.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;

		public LoginController(SignInManager<AppUser> signInManager)
		{
			_signInManager = signInManager;
		}

		[HttpGet]

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]

		public async Task<IActionResult> Index(UserSignInViewModel p)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(p.UserName, p.Password, false, true);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "DashBoard");
				}
				else
				{
					return RedirectToAction("Index", "Login");
				}
			}
			return View(p);
		}
        public async Task<IActionResult> LogOut() 
        {
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index","Login");
        }
        public IActionResult AccesDenied()
        {
            return View();
        }

        //public async Task<IActionResult> Index(Writer w)
        //{
        //    Context c = new Context();
        //    var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail == w.WriterMail && x.WriterPassword==w.WriterPassword);
        //    if (datavalue != null)
        //    {
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name,w.WriterMail)
        //        };
        //        var useridentity=new ClaimsIdentity(claims,"a");
        //        ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
        //        await HttpContext.SignInAsync(principal);
        //        return RedirectToAction("Index","DashBoard");
        //    }
        //    else
        //    {
        //        return View();
        //    }

        //}
    }
}
