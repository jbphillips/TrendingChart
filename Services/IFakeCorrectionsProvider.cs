using TrendingChart.Models;
using TrendingChart.Models.Config;
using TrendingChart.Models.Nominal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MudBlazor.Icons;

namespace TrendingChart.Services
{
    public interface IFakeCorrectionsProvider
    {
        Task<NominalModel> GetCorrectionsDataAsync(CancellationToken ct = default);
        Task<ConfigItemModel> GetConfigItemDataAsync(CancellationToken ct = default);
    }
}