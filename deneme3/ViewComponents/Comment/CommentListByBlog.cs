using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace deneme3.ViewComponents.Comment
{
	public class CommentListByBlog: ViewComponent
	{
		CommentManager cm = new CommentManager(new EfCommentRepository());

		public IViewComponentResult Invoke(int id)
		{
			var values = cm.Getlist(id);
			return View(values);
		}
	}
}
