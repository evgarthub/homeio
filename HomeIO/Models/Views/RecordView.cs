using System;

namespace HomeIO.Models.Views
{
    public class RecordView
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public double CurrentValue { get; set; }
        public DateTime Date { get; set; }
        public string TypeName { get; set; }
        public string Tariff { get; set; }
        public string Unit { get; set; }
    }
}