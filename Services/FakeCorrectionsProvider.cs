using TrendingChart.Models;
using TrendingChart.Models.Config;
using TrendingChart.Models.Nominal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MudBlazor.Icons;

namespace TrendingChart.Services
{
    internal class FakeCorrectionsProvider : IFakeCorrectionsProvider
    {
        static readonly Lazy<NominalModel> _dataSource = new Lazy<NominalModel>(FetchNominalDataSource);

        public Task<NominalModel> GetCorrectionsDataAsync(CancellationToken ct = default)
        {
            return Task.FromResult(_dataSource.Value);
        }

        static NominalModel FetchNominalDataSource()
        {
            string filePath = @"..\TrendingChart\Data\Nominal_SetupComplete.json";

            NominalModel nominalData = new NominalModel();

            try
            {
                using (StreamReader file = File.OpenText(filePath))
                {
                    Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                    nominalData = (NominalModel)serializer.Deserialize(file, typeof(NominalModel));
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine("Fetching trend data source error: " + ex.Message);
            }

            return nominalData;
        }

        /// <summary>
        /// ConfigItem Object Fetch
        /// </summary>
        static readonly Lazy<ConfigItemModel> _dataSourceConfigItem = new Lazy<ConfigItemModel>(FetchConfigDataSource);

        /// <summary>
        /// Fetch ConfigItemModel: ProfileSlopeDeviationCfgObj
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<ConfigItemModel> GetConfigItemDataAsync(CancellationToken ct = default)
        {
            return Task.FromResult(_dataSourceConfigItem.Value);
        }

        /// <summary>
        /// Fetch config data: ProfileSlopeDeviationCfgObj
        /// </summary>
        /// <returns></returns>
        static ConfigItemModel FetchConfigDataSource()
        {
            string filePath = @"..\TrendingChart\Data\ProfileSlopeDeviationCfgObj.json";

            ConfigItemModel configItemModelData = new ConfigItemModel();

            try
            {
                using (StreamReader file = File.OpenText(filePath))
                {
                    Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                    configItemModelData = (ConfigItemModel)serializer.Deserialize(file, typeof(ConfigItemModel));
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine("Fetching ProfileSlopeDeviationCfgObj data source error: " + ex.Message);
            }

            return configItemModelData;
        }
    }
}