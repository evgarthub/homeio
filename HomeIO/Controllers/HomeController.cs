using HomeIO.Models.Entities;
using HomeIO.Models.Repositories;
using HomeIO.Models.ViewModels;
using HomeIO.Models.Views;
using System.Collections.Generic;
using System.Web.Mvc;

namespace HomeIO.Controllers
{
	public class HomeController : Controller
	{
		public RecordRepository RecordRepo { get; }
		public RecordViewRepository RecordViewRepo { get; }
		public TypeRepository TypeRepo { get; }

		public HomeController()
		{
			RecordViewRepo = new RecordViewRepository();
			TypeRepo = new TypeRepository();
		}

		public ActionResult Index()
		{
			List<IList<RecordView>> list = new List<IList<RecordView>>();
			IList<RType> types = TypeRepo.GetAll();
			foreach (var type in types)
			{
				var typeList = RecordViewRepo.GetTopTwoById(type.Id);
				list.Add(typeList);
			}
			{
				return View(new SummaryPageViewModel(list));
			}
		}
	}
}