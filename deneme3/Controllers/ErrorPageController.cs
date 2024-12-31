using Microsoft.AspNetCore.Mvc;

namespace deneme3.Controllers
{
	public class ErrorPageController:Controller
	{
        public IActionResult Error1(int code)
		{
			return View();
		}
    }
}
