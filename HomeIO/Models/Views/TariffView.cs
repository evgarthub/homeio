using DataLayer;
using System;

namespace HomeIO.Models.Entities
{
    public class TariffView : IEntity
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Unit { get; set; }
        public string Cost { get; set; }
        public DateTime Date { get; set; }
        public string Source { get; set; }
        public string TypeName { get; set; }
    }
}