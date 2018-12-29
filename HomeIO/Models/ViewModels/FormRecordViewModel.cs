using HomeIO.Models.Entities;
using HomeIO.Models.Repositories;
using System;
using System.Collections.Generic;

namespace HomeIO.Models.ViewModels
{
    public class FormRecordViewModel
    {
        public Record Record { get; set; }
        public List<RType> Types { get; set; }
        public bool HasRecord { get; set; }

        public FormRecordViewModel(int id)
        {
            RecordRepository recordRepo = new RecordRepository();
            TypeRepository typeRepo = new TypeRepository();

            Record = recordRepo.GetById(id);
            Types = (List<RType>)typeRepo.GetAll();
            HasRecord = true;
        }

        public FormRecordViewModel()
        {
            TypeRepository typeRepo = new TypeRepository();
            Types = (List<RType>)typeRepo.GetAll();
            Record = new Record
            {
                CurrentValue = 0,
                Date = DateTime.Now
            };
            this.HasRecord = false;
        }
    }
}