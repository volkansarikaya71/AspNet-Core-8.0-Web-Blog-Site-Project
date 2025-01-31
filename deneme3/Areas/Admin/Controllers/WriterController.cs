﻿using deneme3.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace deneme3.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterListStatic()
        {
            var jsonWriters=JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }
        public IActionResult GetWriterById(int WriterId)
        {
            var findWriter = writers.FirstOrDefault(x => x.Id == WriterId);
            var jsonWriters = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriters);
        }
        [HttpPost]
        public IActionResult AddWriterStatic(WriterClass w)
        {
            writers.Add(w);
            var jsonWriters = JsonConvert.SerializeObject(w);
            return Json(jsonWriters);
        }
        public IActionResult DeleteWriterStatic(int id)
        {
            var writer=writers.FirstOrDefault(x => x.Id == id);
            writers.Remove(writer);
            return Json(writer);
        }
        public IActionResult UpdateWriterStatic(WriterClass w)
        {
            var writer = writers.FirstOrDefault(x => x.Id == w.Id);
            writer.Name = w.Name;
            var jsonWriters = JsonConvert.SerializeObject(w);
            return Json(jsonWriters);
        }

        public static List<WriterClass> writers = new List<WriterClass>()
        {
            new WriterClass
            {
                Id = 1,
                Name="Ayşe"
            },
            new WriterClass
            {
                Id = 2,
                Name="Fatma"
            },
            new WriterClass
            {
                Id = 3,
                Name="Hayriye"
            }
        };
    }
}
