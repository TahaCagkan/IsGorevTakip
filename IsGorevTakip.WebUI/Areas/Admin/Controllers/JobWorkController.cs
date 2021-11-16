using IsGorevTakip.BLL.Abstract;
using IsGorevTakip.Entities.Concrete;
using IsGorevTakip.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsGorevTakip.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class JobWorkController : Controller
    {
        private readonly IJobWorkService _jobWorkService;
        private readonly IUrgencyService _urgencyService;
        public JobWorkController(IJobWorkService jobWorkService, IUrgencyService urgencyService)
        {
            _jobWorkService = jobWorkService;
            _urgencyService = urgencyService;
        }

        public IActionResult Index()
        {
            TempData["Active"] = "jobWorkActive";
            List<JobWork> jobwork = _jobWorkService.GetUrgencyNotOK();
            List<JobWorkListViewModel> models = new List<JobWorkListViewModel>();
            foreach (var item in jobwork)
            {
                JobWorkListViewModel model = new JobWorkListViewModel
                {
                    Description = item.Description,
                    Urgency = item.Urgency,
                    UrgencyId = item.UrgencyId,
                    Name = item.Name,
                    Is_Active_Status = item.Is_Active_Status,
                    Id = item.Id,
                    CreateDate = item.CreateDate
                };
                models.Add(model);
            }
            return View(models);
        }
        public IActionResult AddJobWork()
        {
            TempData["Active"] = "jobWorkActive";

            ViewBag.Urgencies = new SelectList(_urgencyService.GetAll(), "Id", "Definition");
            return View(new AddJobWorkViewModel());
        }
        [HttpPost]
        public IActionResult AddJobWork(AddJobWorkViewModel model)
        {
            if (ModelState.IsValid)
            {
                _jobWorkService.Save(new JobWork
                {
                    Description = model.Description,
                    Name = model.Name,
                    UrgencyId = model.UrgencyId
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult UpdateJobWork(int id)
        {
            TempData["Active"] = "jobWorkActive";
            var jobWork = _jobWorkService.GetId(id);
            JobWorkUpdateViewModel model = new JobWorkUpdateViewModel
            {
                Id = jobWork.Id,
                Description = jobWork.Description,
                UrgencyId = jobWork.UrgencyId,
                Name = jobWork.Name
            };
            ViewBag.Urgencies = new SelectList(_urgencyService.GetAll(), "Id", "Definition",jobWork.UrgencyId);
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateJobWork(JobWorkUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _jobWorkService.Update(new JobWork()
                {
                    Id=model.Id,
                    Description = model.Description,
                    UrgencyId = model.UrgencyId,
                    Name = model.Name
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult DeleteJobWork(int id)
        {
            var deletedJobWork = _jobWorkService.GetId(id);
            if(deletedJobWork != null)
            {
                _jobWorkService.Delete(deletedJobWork);
            }
            return Json(null);
        }
    }
}
