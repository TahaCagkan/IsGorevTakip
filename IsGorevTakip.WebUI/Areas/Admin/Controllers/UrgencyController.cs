using AutoMapper;
using IsGorevTakip.BLL.Abstract;
using IsGorevTakip.DTO.DTos.UrgencyDtos;
using IsGorevTakip.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IsGorevTakip.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class UrgencyController : Controller
    {
        private readonly IUrgencyService _urgencyService;
        private readonly IMapper _mapper;

        public UrgencyController(IUrgencyService urgencyService, IMapper mapper)
        {
            _urgencyService = urgencyService;
            _mapper = mapper;

        }

        public IActionResult Index()
        {
            TempData["Active"] = "urgencyActive";
            //List<Urgency> urgencies = _urgencyService.GetAll();
            //List<UrgencyListViewModel> model = new List<UrgencyListViewModel>();

            //foreach (var item in urgencies)
            //{
            //    UrgencyListViewModel urgencyModel = new UrgencyListViewModel();
            //    urgencyModel.Id = item.Id;
            //    urgencyModel.Definition = item.Definition;

            //    model.Add(urgencyModel);
            //}
            
            return View(_mapper.Map<List<UrgencyListDto>>(_urgencyService.GetAll()));
        }

        public IActionResult AddUrgency()
        {
            TempData["Active"] = "urgencyActive";
            return View(new UrgencyAddDto());
        }

        [HttpPost]
        public IActionResult AddUrgency(UrgencyAddDto model)
        {
            if (ModelState.IsValid)
            {
                _urgencyService.Save(new Urgency()
                {
                    Definition = model.Definition
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult UpdateUrgency(int id)
        {
            TempData["Active"] = "urgencyActive";
            //var urgency = _urgencyService.GetId(id);
            //UpdateUrgencyViewModel model = new UpdateUrgencyViewModel
            //{
            //    Id = urgency.Id,
            //    Definition = urgency.Definition
            //};          
            return View(_mapper.Map<UrgencyUpdateDto>(_urgencyService.GetId(id)));
        }

        [HttpPost]
        public IActionResult UpdateUrgency(UrgencyUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                _urgencyService.Update(new Urgency
                {
                    Id = model.Id,
                    Definition = model.Definition
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
