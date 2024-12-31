using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using deneme3.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using X.PagedList.Extensions;


namespace deneme3.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public static int BlogIdTutucu;

		[AllowAnonymous]
        public IActionResult Index(int categoryid, int page = 1)
        {
            if(categoryid == 0)
            {
				var values = bm.GetBlogListWithCategory().ToPagedList(page, 6); 
				return View(values);
			}
            else
            {
                Context context = new Context();
                var values = bm.GetListWithCategoryid(categoryid).ToPagedList(page, 6);
                var categoryname =context.Categories.Where(x=>x.CategoryId== categoryid).Select(x => x.CategoryName).FirstOrDefault();
                ViewBag.CategoryName = categoryname;
                ViewBag.categoryid = categoryid;
                return View(values);
			}
			
		}

		[AllowAnonymous]
		public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            BlogIdTutucu = id;
            var values = bm.GetBlogById(id);
            return View(values);
        }

		public IActionResult BlogListByWriter()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int parsedUserId = int.Parse(userId);
            Context c = new Context();
            var values = bm.GetListWithCategoryByWriterBm(parsedUserId);
            return View(values);
        }

		[HttpGet]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> categoryvalues = (from x in cm.Getlist()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.CategoryName,
                                                           Value = x.CategoryId.ToString()
                                                       }).ToList();
                ViewBag.cv = categoryvalues;
            return View();
        }

		[HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            Context c = new Context();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int parsedUserId = int.Parse(userId);
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(p);
            if (results.IsValid)
            {
                if (p.BlogImageLocation != null)
                {
                    var allowedExtensions = new[] { ".png", ".jpg", ".jpeg" }; // İzin verilen uzantılar
                    var extension = Path.GetExtension(p.BlogImageLocation.FileName).ToLower();
                    if (!allowedExtensions.Contains(extension))
                    {
                        ModelState.AddModelError("BlogImageLocation", "Yalnızca PNG veya JPG dosyaları yükleyebilirsiniz.");
                        // Alternatif: return View(p); ile hata ile birlikte formu tekrar gösterebilirsiniz.
                    }
                    else
                    {
                        var newimagename = Guid.NewGuid() + extension;
                        var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image/BlogImage/", newimagename);
                        var stream = new FileStream(location, FileMode.Create);
                        p.BlogImageLocation.CopyTo(stream);
                        p.BlogImage = Path.Combine("/Image", "BlogImage", newimagename).Replace("\\", "/");
                    }
                }
                else
                {
                    p.BlogImage = "/deneme3Tema/images/6.jpg";
                }
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterId = parsedUserId;
                p.BlogThumbnailImage = "null";
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            List<SelectListItem> categoryvalues = (from x in cm.Getlist()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View();
        }
		public IActionResult DeleteBlog(int id)
		{
			var blogvalues = bm.TGetById(id);
            blogvalues.BlogStatus = false;
            bm.TUpdate(blogvalues);
            //bm.TDelete(blogvalues);
            return RedirectToAction("BlogListByWriter");
		}


        [HttpGet]
		public IActionResult EditBlog(int id)
		{
            List<SelectListItem> categoryvalues = (from x in cm.Getlist()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            var blogvalues=bm.TGetById(id);
            ViewBag.BlogImage = blogvalues.BlogImage;
            return View(blogvalues);
		}
        [HttpPost]
		public IActionResult EditBlog(Blog p)
		{

            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(p);
            if (results.IsValid)
            {
                if (p.BlogImageLocation != null)
                {
                    var allowedExtensions = new[] { ".png", ".jpg", ".jpeg" }; // İzin verilen uzantılar
                    var extension = Path.GetExtension(p.BlogImageLocation.FileName).ToLower();
                    if (!allowedExtensions.Contains(extension))
                    {
                        ModelState.AddModelError("BlogImageLocation", "Yalnızca PNG veya JPG dosyaları yükleyebilirsiniz.");
                        // Alternatif: return View(p); ile hata ile birlikte formu tekrar gösterebilirsiniz.
                    }
                    else
                    {
                        var newimagename = Guid.NewGuid() + extension;
                        var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image/BlogImage/", newimagename);
                        var stream = new FileStream(location, FileMode.Create);
                        p.BlogImageLocation.CopyTo(stream);
                        p.BlogImage = Path.Combine("/Image", "BlogImage", newimagename).Replace("\\", "/");
                    }
                }
                bm.TUpdate(p);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            List<SelectListItem> categoryvalues = (from x in cm.Getlist()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            ViewBag.BlogImage = p.BlogImage;
            return View();
		}

	}
}
