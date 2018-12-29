using System.Collections.Generic;
using HomeIO.Models.Repositories;
using HomeIO.Models.Entities;

namespace HomeIO.Models.ViewModels
{
    public class ListPageViewModel
    {
        public List<Record> Records { get; set; }
        public List<RType> Types { get; set; }

        public ListPageViewModel(RecordRepository recordRepo) {
            recordRepo = new RecordRepository();
			var typeRepo = new TypeRepository();


			this.Records = (List<Record>)recordRepo.GetAll();
            this.Types = (List<RType>)typeRepo.GetAll();
        }
    }
}