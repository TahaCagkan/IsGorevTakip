using AutoMapper;
using IsGorevTakip.BLL.Abstract;
using IsGorevTakip.DTO.DTos.DeclaretionnDtos;
using IsGorevTakip.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsGorevTakip.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DeclaretionnController : Controller
    {
        private readonly IDeclaretionnService _declaretionnService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public DeclaretionnController(IDeclaretionnService declaretionnService, UserManager<AppUser> userManager, IMapper mapper)
        {
            _mapper = mapper;
            _declaretionnService = declaretionnService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            //var declarationns = _declaretionnService.GetNotReaded(user.Id);
            //List<DeclarationnListViewModel> models = new List<DeclarationnListViewModel>();
            //foreach (var item in declarationns)
            //{
            //    DeclarationnListViewModel model = new DeclarationnListViewModel();
            //    model.Id = item.Id;
            //    model.Description = item.Description;
            //    models.Add(model);
            //}

            return View(_mapper.Map<List<DeclaretionnListDto>>(_declaretionnService.GetNotReaded(user.Id)));
        }
        [HttpPost]
        public IActionResult Index(int id)
        {
            var updatedDeclaretionn = _declaretionnService.GetId(id);
            updatedDeclaretionn.Is_Active_Status = true;
            _declaretionnService.Update(updatedDeclaretionn);
            return RedirectToAction("Index");
        }
    }
}
