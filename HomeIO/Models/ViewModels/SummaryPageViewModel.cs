using HomeIO.Models.Views;
using System.Collections.Generic;
using System.Linq;

namespace HomeIO.Models.ViewModels
{
    public class SummaryPageViewModel
    {
        public double TotalCost { get; set; }
        public List<SumRecordView> SumRecords { get; set; }

        public SummaryPageViewModel(List<IList<RecordView>> list)
        {
            this.SumRecords = new List<SumRecordView>();

            foreach (var type in list) {
                if (type.Any()) {
                    this.SumRecords.Add(new SumRecordView(type));
                }
            }

            this.TotalCost = this.SumRecords.Sum(x => x.Cost);
        }
    }
}