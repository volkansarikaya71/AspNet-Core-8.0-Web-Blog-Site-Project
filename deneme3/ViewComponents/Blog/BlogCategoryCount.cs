using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace deneme3.ViewComponents.Blog
{
	public class BlogCategoryCount : ViewComponent
	{

		public IViewComponentResult Invoke(int id)
		{
			Context c = new Context();
			var CategoryCounts = c.Blogs.Count(x => x.CategoryId == id);
			ViewBag.CategoryCounts = CategoryCounts;
			return View();
		}
	}
}
