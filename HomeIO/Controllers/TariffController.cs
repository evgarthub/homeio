using HomeIO.Models.Entities;
using HomeIO.Models.Repositories;
using HomeIO.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeIO.Controllers
{
    public class TariffController : Controller
    {
		public TariffViewRepository TariffViewRepo { get; set; }
		public TariffRepository TariffRepo { get; }

        public TariffController() {
            this.TariffRepo = new TariffRepository();
			this.TariffViewRepo = new TariffViewRepository();
		}
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var list = TariffViewRepo.GetAll();
            return View(list);
        }

        public ActionResult ListById(int id)
        {
            var list = TariffViewRepo.GetByTypeId(id);
            return View("List", list);
        }

		[Authorize]
		public ActionResult New()
        {
            return View(new FormTariffViewModel());
        }

        [HttpPost]
		[Authorize]
		public ActionResult New(Tariff tariff)
        {
            TariffRepo.Create(tariff);
            return View(new FormTariffViewModel());
        }

		[Authorize]
		public ActionResult Edit(int id)
		{
			return View(new FormTariffViewModel(id));
		}

		[HttpPost]
		[Authorize]
		public ActionResult Edit(Tariff tariff)
		{
			TariffRepo.Update(tariff);
			return RedirectToAction("List");
		}

		[Authorize]
		public ActionResult Delete(int id)
		{
			TariffRepo.Delete(id);
			return Redirect(Request.UrlReferrer.ToString());
		}
	}
}