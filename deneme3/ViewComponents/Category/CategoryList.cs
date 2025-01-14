﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace deneme3.ViewComponents.Category
{
	public class CategoryList:ViewComponent
	{
		CategoryManager cm = new CategoryManager(new EfCategoryRepository());

		public IViewComponentResult Invoke()
		{
			var values = cm.Getlist();
			return View(values);
		}
	}
}
