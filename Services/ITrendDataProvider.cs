using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using TrendingChart.Models;

namespace TrendingChart.Services
{
    public interface ITrendDataProvider
    {
        Task<ParameterTrendData> GetTrendAsync(CancellationToken ct = default);
        String GetInspectionChartPdf(string Id);
    }
}