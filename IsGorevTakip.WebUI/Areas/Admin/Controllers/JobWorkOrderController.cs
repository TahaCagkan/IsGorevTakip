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

namespace IsGorevTakip.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class JobWorkOrderController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IJobWorkService _jobWorkService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IDocumentService _documentService;

        public JobWorkOrderController(IAppUserService appUserService, IJobWorkService jobWorkService, UserManager<AppUser> userManager, IDocumentService documentService)
        {
            _documentService = documentService;
            _appUserService = appUserService;
            _jobWorkService = jobWorkService;
            _userManager = userManager;
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

        public IActionResult SendWorkerDetails(int id)
        {
            TempData["Active"] = "jobWorkOrderActive";

            var jobWork = _jobWorkService.GetReportId(id);
            JobWorkListGetAllViewModel model = new JobWorkListGetAllViewModel();
            model.Id = jobWork.Id;
            model.CreateDate = jobWork.CreateDate;
            model.Report = jobWork.Report;
            model.Name = jobWork.Name;
            model.Description = jobWork.Description;
            model.AppUser = jobWork.AppUser;

            return View(model);
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
                //Kullanici bilgileri icin
                AppUserListViewModel generalAppUserListModel = new AppUserListViewModel();
                generalAppUserListModel.Id = item.Id;
                generalAppUserListModel.Name = item.Name;
                generalAppUserListModel.Lastname = item.LastName;
                generalAppUserListModel.Email = item.Email;
                generalAppUserListModel.Picture = item.Picture;
                appUserListModel.Add(generalAppUserListModel);
            }
            ViewBag.Personals = appUserListModel;
            //is gorev icin
            JobWorkListViewModel jobModel = new JobWorkListViewModel();
            jobModel.Id = jobWork.Id;
            jobModel.Name = jobWork.Name;
            jobModel.Description = jobWork.Description;
            jobModel.Urgency = jobWork.Urgency;
            jobModel.CreateDate = jobWork.CreateDate;
            return View(jobModel);
        }
        [HttpPost]
        public IActionResult SendWorker(EmployeeJobWorkViewModel model)
        {
            var updateJobWork = _jobWorkService.GetId(model.JobWorkId);
            updateJobWork.AppUserId = model.EmployeeJobWorkId;
            _jobWorkService.Update(updateJobWork);

            return RedirectToAction("Index");
        }

        public IActionResult EmployeeJobWork(EmployeeJobWorkViewModel model)
        {
            TempData["Active"] = "jobWorkOrderActive";

            var user = _userManager.Users.FirstOrDefault(x => x.Id == model.EmployeeJobWorkId);

            var jobWorkUser = _jobWorkService.GetUrgencyId(model.JobWorkId);
            //Kullanici bilgileri icin
            AppUserListViewModel generalAppUserListModel = new AppUserListViewModel();
            generalAppUserListModel.Id = user.Id;
            generalAppUserListModel.Name = user.Name;
            generalAppUserListModel.Picture = user.Picture;
            generalAppUserListModel.Lastname = user.LastName;
            generalAppUserListModel.Email = user.Email;
            //is gorev icin
            JobWorkListViewModel jobModel = new JobWorkListViewModel();
            jobModel.Id = jobWorkUser.Id;
            jobModel.Name = jobWorkUser.Name;
            jobModel.Description = jobWorkUser.Description;
            jobModel.Urgency = jobWorkUser.Urgency;
            //personel gorevlendir
            EmployeeJobWorkListViewModel employeeJobWorkListViewModel = new EmployeeJobWorkListViewModel();
            employeeJobWorkListViewModel.AppUser = generalAppUserListModel;
            employeeJobWorkListViewModel.JobWork = jobModel;

            return View(employeeJobWorkListViewModel);
        }

        public IActionResult GetExcel(int id)
        {
            return File(_documentService.TransferExcel(_jobWorkService.GetReportId(id).Report), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Guid.NewGuid()+".xlsx");
        }

        public IActionResult GetPfd(int id)
        {
            var path = _documentService.TransferPdf(_jobWorkService.GetReportId(id).Report);

            return File(path,"application/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}
