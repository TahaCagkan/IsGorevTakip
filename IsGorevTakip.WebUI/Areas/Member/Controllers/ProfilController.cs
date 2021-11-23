using IsGorevTakip.Entities.Concrete;
using IsGorevTakip.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IsGorevTakip.WebUI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class ProfilController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public ProfilController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "profileActive";
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserListViewModel model = new AppUserListViewModel();
            model.Id = appUser.Id;
            model.Name = appUser.Name;
            model.Lastname = appUser.LastName;
            model.Picture = appUser.Picture;
            model.Email = appUser.Email;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserListViewModel model, IFormFile pictures)
        {
            if (ModelState.IsValid)
            {
                var updatedUser = _userManager.Users.FirstOrDefault(x => x.Id == model.Id);

                if (pictures != null)
                {
                    string picturePath = Path.GetExtension(pictures.FileName);
                    string pictureName = Guid.NewGuid() + picturePath;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img" + pictureName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await pictures.CopyToAsync(stream);
                    }

                    updatedUser.Picture = pictureName;
                }
                updatedUser.Name = model.Name;
                updatedUser.LastName = model.Lastname;
                updatedUser.Email = model.Email;

                var result = await _userManager.UpdateAsync(updatedUser);
                if (result.Succeeded)
                {
                    TempData["message"] = "Güncelleme işleminiz başarı ile gerçekleşti.";
                    return RedirectToAction("Index");
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("",item.Description);
                }
            }
            return View(model);

        }
    }
}
