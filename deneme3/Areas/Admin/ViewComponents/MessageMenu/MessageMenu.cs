using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace deneme3.Areas.Admin.ViewComponents.MessageMenu
{
    public class MessageMenu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var username = User.Identity.Name;
            var userid = c.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var messagenotreadcount = c.Message2s.Count(x => x.ReceiverId == userid && x.Reading == false && x.ReceiverDeleteStatus == false);
            var messagesendcount = c.Message2s.Count(x => x.SenderId == userid && x.SenderDeleteStatus == false);
            var draftcount = c.UserDrafts.Count(x => x.UserId == userid && x.DraftStatus == true);
            var messagedeletecount= c.Message2s.Count(x => 
            (x.ReceiverId == userid && x.ReceiverDeleteStatus == true)
            || (x.SenderId == userid && x.SenderDeleteStatus == true));
            ViewBag.messagesendcount = messagesendcount;
            ViewBag.messagenotreadcount = messagenotreadcount;
            ViewBag.messagedeletecount = messagedeletecount;
            ViewBag.draftcount = draftcount;
            return View();
        }
    }
}
