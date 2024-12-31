using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using deneme3.Areas.Admin.Models;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Spreadsheet;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Linq;
using System.Security.Claims;

namespace deneme3.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")]
    public class MessageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public MessageController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        Context c = new Context();
        UserDraftManager um = new UserDraftManager(new EfUserDraftRepository());
        public IActionResult InBox()
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int parsedUserId = int.Parse(userId);
            var messagenotreadcount = c.Message2s.Count(x => x.ReceiverId == parsedUserId && x.ReceiverDeleteStatus == false);
            ViewBag.messagenotreadcount = messagenotreadcount;
            var values = mm.GetInBoxListByWriter(parsedUserId);
            return View(values);
        }
        public IActionResult SendBox()
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int parsedUserId = int.Parse(userId);
            var messagesenderreadcount = c.Message2s.Count(x => x.SenderId == parsedUserId && x.SenderDeleteStatus == false);
            ViewBag.messagesenderreadcount = messagesenderreadcount;
            var values = mm.GetSendBoxListByWriter(parsedUserId);
            return View(values);
        }
        public IActionResult DeleteBox()
        {


            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int parsedUserId = int.Parse(userId);
            var messagedeletecount = c.Message2s.Count(x =>
            (x.ReceiverId == parsedUserId && x.ReceiverDeleteStatus == true)
            || (x.SenderId == parsedUserId && x.SenderDeleteStatus == true));
            var messagedelete = c.Message2s.Where(x =>
(x.ReceiverId == parsedUserId && x.ReceiverDeleteStatus == true)
|| (x.SenderId == parsedUserId && x.SenderDeleteStatus == true)).ToList();
            ViewBag.messagedeletecount = messagedeletecount;
            return View(messagedelete);

        }

        public PartialViewResult MessageContentArea()
        {

            var username = User.Identity.Name;
            var userid = c.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var messagecount = c.Message2s.Count(x => x.ReceiverId == userid);
            ViewBag.messagecount = messagecount;
            return PartialView();
        }

        [HttpGet]
        public IActionResult SendMessage(string SayfaAdi, int id)
        {
            
            if(SayfaAdi== "DrafSend")
            {
                var values = um.TGetById(id);
                ViewBag.SayfaAdi = SayfaAdi;
                ViewBag.DraftSubject = values.DraftSubject;
                ViewBag.DraftMessageDetails = values.DraftMessageDetails;
                ViewBag.id = id;
            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(Message2 p)
        {

            string ReceiverEmail = HttpContext.Request.Form["ReceiverEmail"];
            var Receiver = await _userManager.FindByEmailAsync(ReceiverEmail);
            if (Receiver == null)
            {
                ModelState.AddModelError("", "Bu e-posta adresine sahip bir kullanıcı bulunamadı.");
                return View(p);
            }
            else
            {

                    MessageValidator bv = new MessageValidator();
                    ValidationResult results = bv.Validate(p);
                    if (results.IsValid)
                    {
                        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                        int parsedUserId = int.Parse(userId);
                        p.SenderId = parsedUserId;
                        p.ReceiverId = Receiver.Id;
                        p.MessageStatus = true;
                        p.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        p.Reading = false;
                        p.SenderDeleteStatus = false;
                        p.ReceiverDeleteStatus = false;
                        mm.TAdd(p);
                        return RedirectToAction("InBox");
                    }
                    else
                    {
                        foreach (var item in results.Errors)
                        {
                            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                        }
                    }
                

            }
            return View();

        }
        public IActionResult OpenMessageBox(MessageViewModel p, int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int parsedUserId = int.Parse(userId);

                var values = mm.TGetById(id);
                var sendermail = c.Users.Where(x => x.Id == values.SenderId).Select(t => t.Email).FirstOrDefault();
                var receivermail = c.Users.Where(x => x.Id == values.ReceiverId).Select(t => t.Email).FirstOrDefault();
                var sendername = c.Users.Where(x => x.Id == values.SenderId).Select(t => t.NameSurname).FirstOrDefault();
                ViewBag.sendermail = sendermail;
                ViewBag.userid = parsedUserId;
                ViewBag.receivermail = receivermail;
                ViewBag.sendername = sendername;
                p.userid = parsedUserId;
                p.subject = values.Subject;
                p.details = values.MessageDetails;
                p.Date = values.MessageDate;
                p.status = values.MessageStatus;
                p.SenderDeleteStatus = values.SenderDeleteStatus;
                p.ReceiverDeleteStatus = values.ReceiverDeleteStatus;
                p.ReceiverId = values.ReceiverId ?? -1;
                p.SenderId = values.SenderId ?? -1;

                if (values != null)
                {
                    values.Reading = true;
                    mm.TUpdate(values);
                }
                return View(p);

            
        }
        [HttpPost]
        public IActionResult DeleteMessage(int id)
        {
            var values = mm.TGetById(id);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int parsedUserId = int.Parse(userId);
            if (values.SenderId == parsedUserId)
            {
                if (values != null)
                {
                    values.SenderDeleteStatus = true;
                    mm.TUpdate(values);
                }
                return RedirectToAction("SendBox");
            }
            else
            {
                if (values != null)
                {
                    values.ReceiverDeleteStatus = true;
                    mm.TUpdate(values);
                }
                return RedirectToAction("Inbox");
            }
        }

        [HttpPost]
        public IActionResult RestoreMessage(int id)
        {
            var values = mm.TGetById(id);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int parsedUserId = int.Parse(userId);
            if (values.SenderId == parsedUserId)
            {
                if (values != null)
                {
                    values.SenderDeleteStatus = false;
                    values.Reading = false;
                    mm.TUpdate(values);
                }
                return RedirectToAction("DeleteBox");
            }
            else
            {
                if (values != null)
                {
                    values.ReceiverDeleteStatus = false;
                    values.Reading = false;
                    mm.TUpdate(values);
                }
                return RedirectToAction("DeleteBox");
            }

        }

        public IActionResult DraftInbox()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int parsedUserId = int.Parse(userId);
            var draftcount = c.UserDrafts.Count(x => x.UserId == parsedUserId);
            ViewBag.draftcount = draftcount;
            var values = um.GetUserDraftByUserId(parsedUserId);
            return View(values);
        }

        [HttpPost]
        public IActionResult DraftAdd(Message2 p)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int parsedUserId = int.Parse(userId);
            UserDraft userdraft = new UserDraft();
            userdraft.DraftStatus = true;
            userdraft.DraftDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            userdraft.UserId = parsedUserId;
            userdraft.DraftSubject = p.Subject;
            userdraft.DraftMessageDetails = p.MessageDetails;
            um.TAdd(userdraft);
            return RedirectToAction("InBox");
        }

        [HttpPost]
        public IActionResult DraftDelete(int id)
        {
            var values=um.TGetById(id);
            um.TDelete(values);
            return RedirectToAction("DraftInbox");
        }

    }



}
