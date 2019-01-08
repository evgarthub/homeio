using HomeIO.Models.Entities;
using HomeIO.Models.Repositories;
using HomeIO.Models.ViewModels;
using HomeIO.Models.Views;
using System.Web.Mvc;

namespace HomeIO.Controllers
{
	public class RecordController : Controller
    {
        private RecordRepository RecordRepo { get; set; }
        private RecordViewRepository RecordsRepo { get; set; }
        private TypeRepository TypeRepo { get; set; }

        public RecordController()
        {
            this.RecordRepo = new RecordRepository();
            this.RecordsRepo = new RecordViewRepository();
            this.TypeRepo = new TypeRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            return View(new FormRecordViewModel());
        }

        [HttpPost]
		[Authorize]
		public ActionResult New(Record record)
        {
            RecordRepo.Create(record);
            return View("Thanks", record);
        }

		[Authorize]
		public ActionResult List()
        {
            var list = RecordsRepo.GetAll();
            return View(list);
        }

		[Authorize]
		public ActionResult ListById(int id)
        {
            var list = RecordsRepo.GetByTypeId(id);
            return View("List", list);
        }

		[Authorize]
		public ActionResult Edit(int id)
        {
            return View(new FormRecordViewModel(id));
        }

        [HttpPost]
		[Authorize]
		public ActionResult Edit(Record record)
        {
            RecordRepo.Update(record);
            return View("Thanks", new EditPageViewModel(record.Id));
        }

		[Authorize]
		public ActionResult Delete(int id)
        {
            RecordRepo.Delete(id);
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}