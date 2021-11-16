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
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class UrgencyController : Controller
    {
        private readonly IUrgencyService _urgencyService;

        public UrgencyController(IUrgencyService urgencyService)
        {
            _urgencyService = urgencyService;
        }

        public IActionResult Index()
        {
            TempData["Active"] = "urgencyActive";
            List<Urgency> urgencies = _urgencyService.GetAll();
            List<UrgencyListViewModel> model = new List<UrgencyListViewModel>();

            foreach (var item in urgencies)
            {
                UrgencyListViewModel urgencyModel = new UrgencyListViewModel();
                urgencyModel.Id = item.Id;
                urgencyModel.Definition = item.Definition;

                model.Add(urgencyModel);
            }
            return View(model);
        }

        public IActionResult AddUrgency()
        {
            TempData["Active"] = "urgencyActive";
            return View(new AddUrgencyViewModel());
        }

        [HttpPost]
        public IActionResult AddUrgency(AddUrgencyViewModel model)
        {
            if (ModelState.IsValid)
            {
                _urgencyService.Save(new Urgency() { 
                    Definition = model.Definition
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult UpdateUrgency(int id)
        {
            TempData["Active"] = "urgencyActive";
            var urgency =   _urgencyService.GetId(id);
            UpdateUrgencyViewModel model = new UpdateUrgencyViewModel
            {
                Id = urgency.Id,
                Definition = urgency.Definition
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateUrgency(UpdateUrgencyViewModel model)
        {
            if(ModelState.IsValid)
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
