using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace deneme3.ViewComponents.MessageCount
{
    public class MessageCount : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var username = User.Identity.Name;
            var userid = c.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var messagecount = c.Message2s.Count(x => x.ReceiverId == userid && x.ReceiverDeleteStatus == false);
            var messagenreadcount = c.Message2s.Count(x => x.ReceiverId == userid && x.Reading == true && x.ReceiverDeleteStatus == false);
            var messagenotreadcount = c.Message2s.Count(x => x.ReceiverId == userid && x.Reading == false && x.ReceiverDeleteStatus == false);
            var messagesendcount = c.Message2s.Count(x => x.SenderId == userid && x.SenderDeleteStatus == false);
            ViewBag.messagesendcount = messagesendcount;
            ViewBag.messagenreadcount = messagenreadcount;
            ViewBag.messagecount = messagecount;
            ViewBag.messagenotreadcount = messagenotreadcount;
            return View();
        }
    }
}
