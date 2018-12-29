using HomeIO.Models.Entities;
using HomeIO.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeIO.Controllers
{
    public class TypeController : Controller
    {
        public TypeRepository TypeRepo { get; }

        public TypeController() {
            this.TypeRepo = new TypeRepository();
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var list = TypeRepo.GetAll();
            return View(list);
        }

        public ActionResult New()
        {
            return View(new RType());
        }
    }
}