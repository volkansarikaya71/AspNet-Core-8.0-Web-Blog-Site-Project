using deneme3.Areas.Admin.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace deneme3.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")]
    public class RolController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RolController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult RolAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RolAdd(RolViewModel model)
        {
            if (ModelState.IsValid)
            {
                var Rolnamecontrol = await _roleManager.FindByNameAsync(model.rolname);
                if (Rolnamecontrol != null)
                {
                    ModelState.AddModelError("", "Bu İsimde Bir Rol Zaten Bulunmaktadır.");
                    return View(model);
                }
                else
                {
                    AppRole role = new AppRole
                    {
                        Name = model.rolname,
                       NormalizedName = model.rolname.ToUpper()
                    };
                    var result = await _roleManager.CreateAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }


            return View(model);
        }

        [HttpGet]
        public IActionResult RolEdit(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            RolViewModel model = new RolViewModel
            {
                rolid = values.Id,
                rolname = values.Name
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> RolEdit(RolViewModel model)
        {
            if (ModelState.IsValid)
            {
                var Rolnamecontrol = await _roleManager.FindByNameAsync(model.rolname);
                if (Rolnamecontrol != null)
                {
                    ModelState.AddModelError("", "Bu İsimde Bir Rol Zaten Bulunmaktadır.");
                    return View(model);
                }
                else
                {
                    var values = _roleManager.Roles.Where(x => x.Id == model.rolid).FirstOrDefault();
                    values.Name = model.rolname;
                    values.NormalizedName = model.rolname.ToUpper();
                    var result = await _roleManager.UpdateAsync(values);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(model);
        }


        public async Task<IActionResult> RolDelete(int id)
        {
            var values = _roleManager.Roles.Where(x => x.Id == id).FirstOrDefault();
            var result = await _roleManager.DeleteAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View();
        }



        //public IActionResult UserRolList()
        //{
        //    var values = _userManager.Users.ToList();
        //    return View(values);
        //}
        public async Task<IActionResult> UserRolList()
        {
            // Tüm kullanıcıları ve rolleri alıyoruz
            var users = _userManager.Users.ToList();
            var roles = _roleManager.Roles.ToList();

            // Kullanıcılar ve roller arasında ilişki kuracak bir model oluşturuyoruz
            List<UserRoleViewModel> userRoleList = new List<UserRoleViewModel>();

            foreach (var user in users)
            {
                // Her kullanıcı için rollerini alıyoruz
                var userRoles = await _userManager.GetRolesAsync(user);

                // Kullanıcı ve rollerini modelde birleştiriyoruz
                UserRoleViewModel userModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    Roles = roles.Select(role => new RoleAssignViewModel
                    {
                        RoleId = role.Id,
                        RoleName = role.Name,
                        Exists = userRoles.Contains(role.Name)
                    }).ToList()
                };

                userRoleList.Add(userModel);
            }

            return View(userRoleList);
        }




        [HttpGet]
        public async Task<IActionResult> AssingnRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = _roleManager.Roles.ToList();
            ViewBag.UserName = user.NameSurname;
            TempData["Userid"] = user.Id;
            var userRoles = await _userManager.GetRolesAsync(user);

            List<RoleAssignViewModel> model = new List<RoleAssignViewModel>();
            foreach (var item in roles)
            {
                RoleAssignViewModel m = new RoleAssignViewModel();
                m.RoleId = item.Id;
                m.RoleName = item.Name;
                m.Exists = userRoles.Contains(item.Name);
                model.Add(m);
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AssingnRole(List<RoleAssignViewModel> model)
        {
            var userid = (int)TempData["Userid"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);

            foreach (var item in model)
            {
                if(item.Exists)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }
            return RedirectToAction("UserRolList");
        }
    }
}
