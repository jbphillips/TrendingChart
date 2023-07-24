using TrendingChart.Models.Nominal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendingChart.Services
{
    public class StateContainer
    {
        public string CorrectionItemId { get; set; }
        public NominalModel SelectedNominal { get; set; }
    }
}
