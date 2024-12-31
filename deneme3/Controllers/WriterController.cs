using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using deneme3.Models;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;


namespace deneme3.Controllers
{

    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        UserManager um = new UserManager(new EfUserRepository());
        private readonly UserManager<AppUser> _userManager;

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            Context c = new Context();
            var usermail = User.Identity.Name;
            ViewBag.Usermail = usermail;
            var writername = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.WriterName = writername;

            return View();
        }
        public IActionResult WriterProfil()
        {
            return View();
        }
        public IActionResult WriterMail()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public async Task<IActionResult> WriterEditProfil()
        {

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.namesurname = values.NameSurname;
            model.username = values.UserName;
            model.email = values.Email;
            model.passwordhash = values.PasswordHash;
            model.phonenumber = values.PhoneNumber;
            model.userabout = values.UserAbout;
            model.ımageurl = values.ImageUrl;
            model.normalizedusername = values.NormalizedUserName;
            model.normalizedemail = values.NormalizedEmail;
            model.changePasswordCheckbox = false;

            return View(model);


            //writer tablosu varken geçerliydi 
            //         Context c = new Context();

            //         var username = User.Identity.Name;
            //var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            //ViewBag.Usermail = usermail;
            //         var WriterId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();

            //         var values = wm.TGetById(WriterId);
            //         ViewBag.WriterPassword =values.WriterPassword;
            //         ViewBag.WriterImage = values.WriterImage;
            //         return PartialView(values);
        }
        [HttpPost]
        public async Task<IActionResult> WriterEditProfil(UserUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return View(model);
            }
            else
            {
                var values = await _userManager.FindByNameAsync(User.Identity.Name);
                if (model.UserImageLocation != null)
                {
                    var allowedExtensions = new[] { ".png", ".jpg", ".jpeg" }; // İzin verilen uzantılar
                    var extension = Path.GetExtension(model.UserImageLocation.FileName).ToLower();
                    if (!allowedExtensions.Contains(extension))
                    {
                        ModelState.AddModelError("UserImageLocation", "Yalnızca PNG veya JPG dosyaları yükleyebilirsiniz.");
                        // Alternatif: return View(p); ile hata ile birlikte formu tekrar gösterebilirsiniz.
                    }
                    else
                    {
                        var newimagename = Guid.NewGuid() + extension;
                        var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image/WriterImage/", newimagename);
                        var stream = new FileStream(location, FileMode.Create);
                        model.UserImageLocation.CopyTo(stream);
                        model.ımageurl = Path.Combine("/Image", "WriterImage", newimagename).Replace("\\", "/");
                        values.ImageUrl = model.ımageurl;
                    }
                }
                if(model.changePasswordCheckbox)
                {
                    values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.passwordhash);
                }

                values.NameSurname = model.namesurname;
                values.Email = model.email;
                values.NormalizedEmail = model.email.ToUpper();
                values.PhoneNumber = model.phonenumber;
                values.UserAbout = model.userabout;
                values.NormalizedUserName = model.username.ToUpper();
                var result = await _userManager.UpdateAsync(values);
                return RedirectToAction("Index", "Dashboard");
            }


        }



        //identy öncesi 
        //var pas1 = Request.Form["pass1"];
        //var pas2 = Request.Form["pass2"];
        //if (pas1 == pas2)
        //{
        //    p.WriterPassword = pas2;
        //    WriterValidator validationRules = new WriterValidator();
        //    ValidationResult result = validationRules.Validate(p);
        //    if (result.IsValid)
        //    {
        //        wm.TUpdate(p);
        //        return RedirectToAction("Index", "Dashboard");
        //    }
        //    else
        //    {
        //        foreach (var item in result.Errors)
        //        {
        //            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        //        }
        //    }
        //}
        //else
        //{
        //    ViewBag.hata = "Girdiğiniz Parolalar Uyuşmuyor!";
        //}
        //return View();


    }
}
