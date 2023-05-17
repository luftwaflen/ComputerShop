using AutoMapper;
using ComputerShop.WebApp.Models;
using ComputerShopLogic.Dto;
using ComputerShopLogic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ComputerShop.WebApp.Controllers
{
    public class ComponentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITagService _tagService;
        private readonly IComponentService _componentService;

        public ComponentController(IMapper mapper,
            ITagService tagService,
            IComponentService componentService)
        {
            _mapper = mapper;
            _tagService = tagService;
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
                view.Icon = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fmarket.yandex.by%2Fproduct--gigabyte-geforce-gtx-470-700mhz-pci-e-20-1280mb-3348mhz-320-bit-2xdvi-mini-hdmi-hdcp%2F6411981&psig=AOvVaw1kvA6BbZ-5ncb4GLDboVrs&ust=1684448906058000&source=images&cd=vfe&ved=0CBEQjRxqFwoTCIjGt6ez_f4CFQAAAAAdAAAAABAE";
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
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<ComponentDto>(component);
                _componentService.Create(dto);
                return RedirectToAction("Index");
            }

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
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ComponentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ComponentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
