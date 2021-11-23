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
    public class JobWorkMemberOrderController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IDeclaretionnService _declaretionnService;
        private readonly IJobWorkService _jobWorkService;
        private readonly IReportService _reportService;

        public JobWorkMemberOrderController(IJobWorkService jobWorkService, UserManager<AppUser> userManage, IReportService reportService, IDeclaretionnService declaretionnService)
        {
            _userManager = userManage;
            _jobWorkService = jobWorkService;
            _reportService = reportService;
            _declaretionnService = declaretionnService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "jobWorkActive";

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var jobWorks = _jobWorkService.GetAllTable(x => x.AppUserId == user.Id && !x.Is_Active_Status);

            List<JobWorkListGetAllViewModel> models = new List<JobWorkListGetAllViewModel>();
            foreach (var item in jobWorks)
            {
                JobWorkListGetAllViewModel model = new JobWorkListGetAllViewModel();
                model.Id = item.Id;
                model.Description = item.Description;
                model.Urgency = item.Urgency;
                model.Name = item.Name;
                model.AppUser = item.AppUser;
                model.Report = item.Report;
                models.Add(model);
            }
            return View(models);
        }
        public IActionResult AddedReport(int id)
        {
            var jobWork = _jobWorkService.GetUrgencyId(id);

            ReportAddViewModel model = new ReportAddViewModel();
            model.JobWorkId = id;
            model.JobWorks = jobWork;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddedReport(ReportAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _reportService.Save(new Report()
                {
                    JobWorkId = model.JobWorkId,
                    Detail = model.Detail,
                    Definition = model.Definition
                });

                //Rolu admin olan kullanicilar tamamlanan raporlari gorsun
                var adminUserList = await _userManager.GetUsersInRoleAsync("Admin");
                var activeUser = await _userManager.FindByNameAsync(User.Identity.Name);

                foreach (var admin in adminUserList)
                {
                    _declaretionnService.Save(new Declarationn
                    {
                        Description = $"{activeUser.Name}{activeUser.LastName} yeni bir rapor yazdı",
                        AppUserId = admin.Id
                    });
                }

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult UpdateReport(int id)
        {
            TempData["Active"] = "jobWorkActive";

            var report = _reportService.GetReportJobWorkId(id);
            ReportUpdateViewModel model = new ReportUpdateViewModel();
            model.JobWorkId = report.Id;
            model.Definition = report.Definition;
            model.Detail = report.Detail;
            model.JobWorks = report.JobWork;
            model.JobWorkId = report.JobWorkId;
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateReport(ReportUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var updatedReport = _reportService.GetReportJobWorkId(model.JobWorkId);

                updatedReport.Definition = model.Definition;
                updatedReport.Detail = model.Detail;

                _reportService.Update(updatedReport);
                return RedirectToAction("Index");
            }
            return View(model);            
        }

        public async Task<IActionResult> OKOrderMission(int jobWorkId)
        {
            var updatedJobWork = _jobWorkService.GetId(jobWorkId);
            updatedJobWork.Is_Active_Status = true;
            _jobWorkService.Update(updatedJobWork);

            //Rolu admin olan kullanicilar tamamlanan raporlari gorsun
            var adminUserList = await _userManager.GetUsersInRoleAsync("Admin");
            var activeUser = await _userManager.FindByNameAsync(User.Identity.Name);
            foreach (var admin in adminUserList)
            {
                _declaretionnService.Save(new Declarationn
                {
                    Description = $"{activeUser.Name}{activeUser.LastName} vermiş olduğunuz bir görevi tamamladı",
                    AppUserId = admin.Id
                });
            }

            return Json(null);
        }
    }
}
