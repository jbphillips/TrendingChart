using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace TrendingChart.Models.Nominal
{
    public partial class NominalModel
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("State")]
        public string State { get; set; }

        [JsonProperty("ParentType")]
        public long ParentType { get; set; }

        [JsonProperty("ParentID")]
        public string ParentId { get; set; }

        [JsonProperty("ID")]
        public Guid Id { get; set; }

        [JsonProperty("TimeStamp")]
        public DateTimeOffset TimeStamp { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("SubType")]
        public string SubType { get; set; }

        [JsonProperty("AppData")]
        public AppData AppData { get; set; }
    }

    public partial class AppData
    {
        [JsonProperty("Inspection")]
        public Inspection Inspection { get; set; }

        [JsonProperty("UserInput")]
        public UserInput UserInput { get; set; }
    }

    public partial class Inspection
    {
        [JsonProperty("TimeStamp")]
        public DateTimeOffset TimeStamp { get; set; }

        [JsonProperty("Strings")]
        public InspectionStrings Strings { get; set; }

        [JsonProperty("Booleans")]
        public Booleans Booleans { get; set; }

        [JsonProperty("Integers")]
        public Booleans Integers { get; set; }

        [JsonProperty("Doubles")]
        public Booleans Doubles { get; set; }

        [JsonProperty("Resources")]
        public Booleans Resources { get; set; }
    }

    public partial class Booleans
    {
    }

    public partial class InspectionStrings
    {
        [JsonProperty("MeasuredQualityCharacteristics")]
        public string MeasuredQualityCharacteristics { get; set; }
    }

    public partial class UserInput
    {
        [JsonProperty("TimeStamp")]
        public DateTimeOffset TimeStamp { get; set; }

        [JsonProperty("Strings")]
        public UserInputStrings Strings { get; set; }

        [JsonProperty("Booleans")]
        public PurpleBooleans Booleans { get; set; }

        [JsonProperty("Integers")]
        public Booleans Integers { get; set; }

        [JsonProperty("Doubles")]
        public Booleans Doubles { get; set; }

        [JsonProperty("Resources")]
        public Booleans Resources { get; set; }
    }

    public partial class PurpleBooleans
    {
        [JsonProperty("Confirmation")]
        public bool Confirmation { get; set; }
    }

    public partial class UserInputStrings
    {
        [JsonProperty("SmartInstructions")]
        public string SmartInstructions { get; set; }

        [JsonProperty("ImplementWhen")]
        public string ImplementWhen { get; set; }
    }

    public partial class NominalModel
    {
        public static NominalModel FromJson(string json) => JsonConvert.DeserializeObject<NominalModel>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this NominalModel self) => JsonConvert.SerializeObject(self, Converter.Settings);
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