using HomeIO.Models.Entities;
using HomeIO.Models.Repositories;
using HomeIO.Models.ViewModels;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace HomeIO.Controllers
{
	public class RecordController : Controller
    {
        private RecordRepository RecordRepo { get; set; }
        private RecordViewRepository RecordViewRepo { get; set; }
        private TypeRepository TypeRepo { get; set; }

        public RecordController()
        {
            this.RecordRepo = new RecordRepository();
            this.RecordViewRepo = new RecordViewRepository();
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
			
			int recordId = RecordRepo.Create(record, GetUserId());
            return View("Thanks", new EditPageViewModel(recordId));
        }

		[Authorize]
		public ActionResult List(string userId)
		{
			var list = RecordViewRepo.GetUserAll(GetUserId());
			return View(list);
		}

		[Authorize]
		public ActionResult ListById(int id)
        {
            var list = RecordViewRepo.GetUserByTypeId(id, GetUserId());
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

		private string GetUserId()
		{
			return HttpContext.User.Identity.GetUserId();
		}

		private bool CheckUserId(string recordUserId)
		{
			return GetUserId() == recordUserId;
		}
	}
}