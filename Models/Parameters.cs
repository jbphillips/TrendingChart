using TrendingChart.Models.Nominal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendingChart.Models
{
    internal class Parameters
    {
        public NominalModel Nominal { get; set; }
        public string CorrectionItemId { get; set; }
    }
}