using HomeIO.Models.Entities;
using HomeIO.Models.Repositories;
using System;
using System.Collections.Generic;

namespace HomeIO.Models.ViewModels
{
    public class FormTariffViewModel
    {
        public Tariff Tariff { get; set; }
        public List<RType> Types { get; set; }
        public bool HasTariff { get; set; }

        public FormTariffViewModel(int id)
        {
            TariffRepository TariffRepo = new TariffRepository();
            TypeRepository typeRepo = new TypeRepository();

            Tariff = TariffRepo.GetById(id);
            Types = (List<RType>)typeRepo.GetAll();
            HasTariff = true;
        }

        public FormTariffViewModel()
        {
            TypeRepository typeRepo = new TypeRepository();
            Types = (List<RType>)typeRepo.GetAll();
            this.HasTariff = false;
        }
    }
}