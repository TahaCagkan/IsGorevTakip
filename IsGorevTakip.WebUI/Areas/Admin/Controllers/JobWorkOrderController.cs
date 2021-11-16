using IsGorevTakip.BLL.Abstract;
using IsGorevTakip.Entities.Concrete;
using IsGorevTakip.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsGorevTakip.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class JobWorkOrderController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IJobWorkService _jobWorkService;
        public JobWorkOrderController(IAppUserService appUserService, IJobWorkService jobWorkService)
        {
            _appUserService = appUserService;
            _jobWorkService = jobWorkService;
        }
        public IActionResult Index()
        {
            TempData["Active"] = "jobWorkOrderActive";
            //var model = _appUserService.GetAllNotAdmin();
            List<JobWork> jobWorks = _jobWorkService.GetAllTable();
            List<JobWorkListGetAllViewModel> models = new List<JobWorkListGetAllViewModel>();
            foreach (var item in jobWorks)
            {
                JobWorkListGetAllViewModel model = new JobWorkListGetAllViewModel();
                model.Id = item.Id;
                model.Description = item.Description;
                model.Urgency = item.Urgency;
                model.Name = item.Name;
                model.AppUser = item.AppUser;
                model.CreateDate = item.CreateDate;
                model.Report = item.Report;
                models.Add(model);

            }
            return View(models);
        }
        public IActionResult SendWorker(int id,string searchByUrl,int pagein=1)
        {
            TempData["Active"] = "jobWorkOrderActive";

            ViewBag.ActivePage = pagein;
            //ViewBag.TotalPage = (int)Math.Ceiling((double)_appUserService.GetAllNotAdmin().Count() / 3);
            var jobWork = _jobWorkService.GetUrgencyId(id);
            ViewBag.SearchBy = searchByUrl;

            int totalPage;
            var personels = _appUserService.GetAllNotAdmin(out totalPage, searchByUrl,pagein);
            ViewBag.TotalPage = totalPage;

            List<AppUserListViewModel> appUserListModel = new List<AppUserListViewModel>();
            foreach (var item in personels)
            {
                AppUserListViewModel model = new AppUserListViewModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.Lastname = item.LastName;
                model.Email = item.Email;
                model.Picture = item.Picture;
                appUserListModel.Add(model);
            }
            ViewBag.Personals = appUserListModel;

            JobWorkListViewModel jobModel = new JobWorkListViewModel();
            jobModel.Id = jobWork.Id;
            jobModel.Name = jobWork.Name;
            jobModel.Description = jobWork.Description;
            jobModel.Urgency = jobWork.Urgency;
            jobModel.CreateDate = jobWork.CreateDate;
            return View(jobModel);
        }
    }
}
