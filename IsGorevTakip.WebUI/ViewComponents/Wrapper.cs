using IsGorevTakip.BLL.Abstract;
using IsGorevTakip.Entities.Concrete;
using IsGorevTakip.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsGorevTakip.WebUI.ViewComponents
{
    public class Wrapper : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IDeclaretionnService _declaretionnService; 
     public Wrapper(UserManager<AppUser> userManager, IDeclaretionnService declaretionnService)
        {
            _userManager = userManager;
            _declaretionnService = declaretionnService;
        }

        public IViewComponentResult Invoke()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            AppUserListViewModel model = new AppUserListViewModel();

            model.Id = user.Id;
            model.Name = user.Name;
            model.Picture = user.Picture;
            model.Lastname = user.LastName;
            model.Email = user.Email;

            var declarationn = _declaretionnService.GetNotReaded(user.Id).Count;

            ViewBag.DeclaretionCount = declarationn;

            var roles = _userManager.GetRolesAsync(user).Result;
            if (roles.Contains("Admin"))
            {
                return View(model);
            }
            return View("Member",model);
        }
    }
}
