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
        public TariffViewRepository TariffViewRepo { get; }
        public TariffRepository TariffRepo { get; }

        public TariffController() {
            this.TariffViewRepo = new TariffViewRepository();
            this.TariffRepo = new TariffRepository();
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
            var list = TariffViewRepo.GetById(id);
            return View("List", list);
        }

        public ActionResult New()
        {
            return View(new FormTariffViewModel());
        }

        [HttpPost]
        public ActionResult New(Tariff tariff)
        {
            TariffRepo.Create(tariff);
            return View();
        }
    }
}