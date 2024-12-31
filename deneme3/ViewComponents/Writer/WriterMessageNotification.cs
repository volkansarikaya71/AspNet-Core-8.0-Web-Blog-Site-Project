using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Spreadsheet;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace deneme3.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());

        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            int parsedUserId = int.Parse(userId);
            var messagenotreadcount = c.Message2s.Count(x => x.ReceiverId == parsedUserId && x.Reading == false && x.ReceiverDeleteStatus == false);
            ViewBag.messagenotreadcount = messagenotreadcount;
            var values=mm.GetInBoxListByWriter(parsedUserId);
            return View(values);
        }
    }
}
