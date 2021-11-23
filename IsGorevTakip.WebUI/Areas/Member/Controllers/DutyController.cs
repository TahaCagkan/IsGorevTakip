using IsGorevTakip.BLL.Abstract;
using IsGorevTakip.Entities.Concrete;
using IsGorevTakip.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsGorevTakip.WebUI.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class DutyController : Controller
    {
        private readonly IJobWorkService _jobWorkService;
        private readonly UserManager<AppUser> _userManager;
        public DutyController(IJobWorkService jobWorkService, UserManager<AppUser> userManager)
        {
            _jobWorkService = jobWorkService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(int activePage = 1)
        {
            TempData["Active"] = "dutyJobWork";

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            int totalPage;
            var jobWorks = _jobWorkService.GetAllTableNotOk(out totalPage, user.Id, activePage);

            List<JobWorkListGetAllViewModel> models = new List<JobWorkListGetAllViewModel>();
            foreach (var duty in jobWorks)
            {
                JobWorkListGetAllViewModel model = new JobWorkListGetAllViewModel();
                model.Id = duty.Id;
                model.Description = duty.Description;
                model.Urgency = duty.Urgency;
                model.Name = duty.Name;
                model.AppUser = duty.AppUser;
                model.CreateDate = duty.CreateDate;
                models.Add(model);
            }
            return View(models);
        }
    }
}
