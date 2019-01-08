using System.Collections.Generic;
using HomeIO.Models.Repositories;
using HomeIO.Models.Entities;
using HomeIO.Models.Views;

namespace HomeIO.Models.ViewModels
{
    public class EditPageViewModel
    {
        public RecordView Record { get; set; }
        public List<RType> Types { get; set; }

        public EditPageViewModel(int id) {
            RecordViewRepository recordRepo = new RecordViewRepository();
            TypeRepository typeRepo = new TypeRepository();

            this.Record = recordRepo.GetById(id);
            this.Types = (List<RType>)typeRepo.GetAll();
        }
    }
}