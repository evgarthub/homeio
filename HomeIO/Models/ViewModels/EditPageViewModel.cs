using System.Collections.Generic;
using HomeIO.Models.Repositories;
using HomeIO.Models.Entities;

namespace HomeIO.Models.ViewModels
{
    public class EditPageViewModel
    {
        public Record Record { get; set; }
        public List<RType> Types { get; set; }

        public EditPageViewModel(int id) {
            RecordRepository recordRepo = new RecordRepository();
            TypeRepository typeRepo = new TypeRepository();

            this.Record = recordRepo.GetById(id);
            this.Types = (List<RType>)typeRepo.GetAll();
        }
    }
}