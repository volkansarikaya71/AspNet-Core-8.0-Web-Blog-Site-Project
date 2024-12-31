using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace deneme3.Areas.Admin.ViewComponents.Statistic1
{
    public class Statistic1:ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context c=new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.BlogCount = bm.Getlist().Count();
            ViewBag.ContactsCount=c.Contacts.Count();
            ViewBag.CommentsCount = c.Comments.Count();
            string api = "1a6c920b7b0f712d350ccce499fd5475";
            string city = "Ankara";
            string country = "tr";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q="+city+"&mode=xml&lang="+ country + "&units=metric&appid="+api;
            XDocument document = XDocument.Load(connection);
            ViewBag.Template = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.City = city + " Hava Durumu";
            return View();
        }
    }
}
