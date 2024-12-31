using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace deneme3.ViewComponents.Blog
{
	public class WriterLastBlog:ViewComponent
	{
		BlogManager bm=new BlogManager(new EfBlogRepository());

		public IViewComponentResult Invoke(int id)
		{
			ViewBag.i = id;
			var values = bm.GetBlogListByWriter(id);
			return View(values);
		}
	}
}
