using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.InkML;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace deneme3.Controllers
{

    public class Message2Controller : Controller
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        private readonly UserManager<AppUser> _userManager;

        public Message2Controller(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult InBox()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int parsedUserId = int.Parse(userId);
            var values = mm.GetInBoxListByWriter(parsedUserId);
            return View(values);
        }

        public IActionResult MesajDetails(int id)
        {
            var values = mm.TGetById(id);
            values.Reading = true;
            mm.TUpdate(values);
            return View(values);
        }

        public IActionResult SendBox()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int parsedUserId = int.Parse(userId);
            var values = mm.GetSendBoxListByWriter(parsedUserId);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> SendMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(Message2 p)
        {
            Context c = new Context();
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


    }
}
