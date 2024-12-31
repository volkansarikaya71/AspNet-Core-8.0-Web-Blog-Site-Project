using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using X.PagedList;
using X.PagedList.Extensions;
namespace deneme3.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

        public IActionResult Index(int page=1)
        {
            var values = cm.GetlistAll().ToPagedList(page,5);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult results = cv.Validate(p);
            if (results.IsValid)
            {
                p.CategoryStatus = true;
                cm.TAdd(p);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult CategoryDelete(int id)
        {
            var values = cm.TGetById(id);
            cm.TDelete(values);
            return RedirectToAction("Index");
        }
        public IActionResult ActivePassiveCategory(int id,string name)
        {
            var values = cm.TGetById(id);
            if (name == "Active")
            {
                values.CategoryStatus = true;
                cm.TUpdate(values);
            }
            else
            {
                values.CategoryStatus = false;
                cm.TUpdate(values);
            }
            
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            
            var values = cm.TGetById(id);
            ViewBag.Categoryname = values.CategoryName;
            ViewBag.CategoryDescription = values.CategoryDescription;
            return View(values);
        }
        [HttpPost]
        public IActionResult EditCategory(Category p,int id)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult results = cv.Validate(p);
            if (results.IsValid)
            {
                var values = cm.TGetById(id);
                values.CategoryName = p.CategoryName;
                values.CategoryDescription = p.CategoryDescription;
                cm.TUpdate(values);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
    }
}
