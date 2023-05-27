using AutoMapper;
using ComputerShop.WebApp.Models;
using ComputerShopLogic.Dto;
using ComputerShopLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShop.WebApp.Controllers
{
    public class ComponentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IComponentService _componentService;

        public ComponentController(IMapper mapper,
            IComponentService componentService)
        {
            _mapper = mapper;
            _componentService = componentService;
        }
        // GET: ComponentController
        public ActionResult Index()
        {
            var componentsDto = _componentService.GetAll();
            var componentsView = new List<ComponentViewModel>();
            foreach (var component in componentsDto)
            {
                var view = _mapper.Map<ComponentViewModel>(component);
                componentsView.Add(view);
            }

            return View(componentsView);
        }

        // GET: ComponentController/Details/5
        public ActionResult Details(int id)
        {
            var dto = _componentService.GetById(id);
            var view = _mapper.Map<ComponentViewModel>(dto);
            return PartialView(view);
        }

        // GET: ComponentController/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: ComponentController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(ComponentViewModel component)
        {
            var dto = _mapper.Map<ComponentDto>(component);
            _componentService.Create(dto);
            return RedirectToAction("Index");
        }

        // GET: ComponentController/Edit/5
        public ActionResult Edit(int id)
        {
            var dto = _componentService.GetById(id);
            var view = _mapper.Map<ComponentViewModel>(dto);
            return PartialView(view);
        }

        // POST: ComponentController/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(ComponentViewModel component)
        {
            var dto = _mapper.Map<ComponentDto>(component);
            _componentService.Update(dto);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _componentService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
