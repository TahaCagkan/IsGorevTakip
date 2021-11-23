using AutoMapper;
using IsGorevTakip.BLL.Abstract;
using IsGorevTakip.DTO.DTos.JobWorkDtos;
using IsGorevTakip.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace IsGorevTakip.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class JobWorkController : Controller
    {
        private readonly IJobWorkService _jobWorkService;
        private readonly IUrgencyService _urgencyService;
        private readonly IMapper _mapper;

        public JobWorkController(IJobWorkService jobWorkService, IUrgencyService urgencyService, IMapper mapper)
        {
            _jobWorkService = jobWorkService;
            _urgencyService = urgencyService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["Active"] = "jobWorkActive";
            //List<JobWork> jobwork = _jobWorkService.GetUrgencyNotOK();
            //List<JobWorkListViewModel> models = new List<JobWorkListViewModel>();
            //foreach (var item in jobwork)
            //{
            //    JobWorkListViewModel model = new JobWorkListViewModel
            //    {
            //        Description = item.Description,
            //        Urgency = item.Urgency,
            //        UrgencyId = item.UrgencyId,
            //        Name = item.Name,
            //        Is_Active_Status = item.Is_Active_Status,
            //        Id = item.Id,
            //        CreateDate = item.CreateDate
            //    };
            //    models.Add(model);
            //}

            return View(_mapper.Map<List<JobWorkListDto>>(_jobWorkService.GetUrgencyNotOK()));
        }
        public IActionResult AddJobWork()
        {
            TempData["Active"] = "jobWorkActive";

            ViewBag.Urgencies = new SelectList(_urgencyService.GetAll(), "Id", "Definition");
            return View(new JobWorkAddDto());
        }
        [HttpPost]
        public IActionResult AddJobWork(JobWorkAddDto model)
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
            //JobWorkUpdateViewModel model = new JobWorkUpdateViewModel
            //{
            //    Id = jobWork.Id,
            //    Description = jobWork.Description,
            //    UrgencyId = jobWork.UrgencyId,
            //    Name = jobWork.Name
            //};
            ViewBag.Urgencies = new SelectList(_urgencyService.GetAll(), "Id", "Definition", jobWork.UrgencyId);
            return View(_mapper.Map<JobWorkUpdateDto>(jobWork));
        }
        [HttpPost]
        public IActionResult UpdateJobWork(JobWorkUpdateDto model)
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
                ViewBag.Urgencies = new SelectList(_urgencyService.GetAll(), "Id", "Definition", model.UrgencyId);
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
