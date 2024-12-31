using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using deneme3.Areas.Admin.Models;
using DocumentFormat.OpenXml.Wordprocessing;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace deneme3.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ChartController : Controller
    {
        ChartManager cm = new ChartManager(new EfChartRepository());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategoryChartStatic()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass
            {
                categoryname = "Teknoloji",
                categorycount = 10
            });
            list.Add(new CategoryClass
            {
                categoryname = "Yazılım",
                categorycount = 14
            });
            list.Add(new CategoryClass
            {
                categoryname = "Spor",
                categorycount = 8
            });
            list.Add(new CategoryClass
            {
                categoryname = "Sinema",
                categorycount = 2
            });
            return Json(new { jsonlist = list });
        }
        [HttpGet]
        public IActionResult CategoryChartDnamic(int id)
        {
            ViewBag.id = id;
            if (id != 0)
            {
                var values = cm.TGetById(id);
                ViewBag.ChartName = values.ChartName;
                ViewBag.Count = values.ChartCount;
                return View(values);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult CategoryChartDnamic(Chart p, int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int parsedUserId = int.Parse(userId);

            ChartValidator cv = new ChartValidator();
            ValidationResult results = cv.Validate(p);
            if (results.IsValid)
            {
                p.UserId = parsedUserId;
                p.ChartStatus = true;
                if (id == 0)
                {
                    cm.TAdd(p);
                    return RedirectToAction("CategoryChartDnamic", new { id = 0 });
                }
                else
                {
                    var values = cm.TGetById(id);
                    values.ChartName = p.ChartName;
                    values.ChartCount = p.ChartCount;
                    cm.TUpdate(values);
                    return RedirectToAction("CategoryChartDnamic", new { id = 0 });
                }

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

        [HttpPost]
        public IActionResult DeleteCategoryChartDnamic(int id)
        {
            var values = cm.TGetById(id);
            cm.TDelete(values);
            return RedirectToAction("CategoryChartDnamic");

        }

        public IActionResult CancelCategoryChartDnamic()
        {
            return RedirectToAction("CategoryChartDnamic", new { id = 0 });
        }

        public IActionResult ChartDynamic()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int parsedUserId = int.Parse(userId);
            List<ChartModelDynamic> chartlist = new List<ChartModelDynamic>();
            using (var c = new DataAccessLayer.Concrete.Context())
            {
                chartlist = c.charts
                    .Where(x => x.UserId == parsedUserId)
                    .Select(x => new ChartModelDynamic
                    {
                        Id = x.ChartId,
                        chartname = x.ChartName,
                        chartcount = x.ChartCount
                    }).ToList();
            }
            return Json(new { jsonlist = chartlist });
        }

    }
}
