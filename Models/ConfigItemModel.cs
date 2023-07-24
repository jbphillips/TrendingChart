using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TrendingChart.Models.Config
{
    public partial class ConfigItemModel
    {
        [JsonProperty("IdentityKey")]
        public string IdentityKey { get; set; }

        [JsonProperty("MzrdQualityKey")]
        public string MzrdQualityKey { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("AsciiMain")]
        public string AsciiMain { get; set; }

        [JsonProperty("AsciiSubscript")]
        public string AsciiSubscript { get; set; }

        [JsonProperty("Unit")]
        public string Unit { get; set; }

        [JsonProperty("UnitsConvFactor")]
        public long UnitsConvFactor { get; set; }

        [JsonProperty("LocalizedName")]
        public object LocalizedName { get; set; }

        [JsonProperty("IsClosedLoop")]
        public bool IsClosedLoop { get; set; }

        [JsonProperty("IsClosedLoopChecked")]
        public bool IsClosedLoopChecked { get; set; }

        [JsonProperty("IsTrendAnalysis")]
        public bool IsTrendAnalysis { get; set; }

        [JsonProperty("NoCorrection")]
        public CorrectionLimit NoCorrection { get; set; }

        [JsonProperty("CorrectionLimit")]
        public CorrectionLimit CorrectionLimit { get; set; }

        [JsonProperty("CorrectionLimitByUser")]
        public CorrectionLimit CorrectionLimitByUser { get; set; }

        [JsonProperty("IsNoCorrectionLowerError")]
        public bool IsNoCorrectionLowerError { get; set; }

        [JsonProperty("IsNoCorrectionUpperError")]
        public bool IsNoCorrectionUpperError { get; set; }

        [JsonProperty("IsCorrectionLimitLowerError")]
        public bool IsCorrectionLimitLowerError { get; set; }

        [JsonProperty("IsCorrectionLimitUpperError")]
        public bool IsCorrectionLimitUpperError { get; set; }
    }

    public partial class CorrectionLimit
    {
        [JsonProperty("upper")]
        public decimal Upper { get; set; }

        [JsonProperty("lower")]
        public decimal Lower { get; set; }
    }

    public partial class ConfigItemModel
    {
        public static ConfigItemModel FromJson(string json) => JsonConvert.DeserializeObject<ConfigItemModel>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this ConfigItemModel self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
