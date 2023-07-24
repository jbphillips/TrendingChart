using DevExpress.Pdf.Native.BouncyCastle.Utilities.IO.Pem;
using TrendingChart.Models;
using System.Diagnostics;
using System.Numerics;

namespace TrendingChart.Services
{
    class TrendDataProvider : ITrendDataProvider
    {
        static readonly Lazy<ParameterTrendData> _dataSource = new Lazy<ParameterTrendData>(FetchConfigTrendDataSource);

        public Task<ParameterTrendData> GetTrendAsync(CancellationToken ct = default)
        {
            return Task.FromResult(_dataSource.Value);
        }

        static ParameterTrendData FetchConfigTrendDataSource()
        {
            string filePath = @"..\TrendingChart\Data\ParameterTrendData.json";

            ParameterTrendData trendData = new ParameterTrendData();

            try
            {
                using (StreamReader file = File.OpenText(filePath))
                {
                    Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                    trendData = (ParameterTrendData)serializer.Deserialize(file, typeof(ParameterTrendData));
                }
            }

            catch (Exception ex) 
            {
                Debug.WriteLine("Fetching trend data source error: " + ex.Message);
            }

            // calculate and add trendline to the data source
            TrendDataProvider tp = new TrendDataProvider();
            trendData = tp.BuildTrendLineArray(trendData);

            return trendData;
        }

        /// <summary>
        /// Build and populate TrendLineData with the calculated trendline using the MeasurementErrors x and y error values
        /// The calculated TrendLineData needs to be a part of the MeasurementErrors model as the chart can only have one data source
        /// </summary>
        /// <param name="parameterTrendData"></param>
        /// <returns></returns>
        private ParameterTrendData BuildTrendLineArray(ParameterTrendData parameterTrendData)
        {
            var ListOfYaxisValues = parameterTrendData.MeasurementErrors.Select(x => x.ErrorValue).ToList();
            var ListOfXaxisValues = parameterTrendData.MeasurementErrors.Select(x => x.XAxisValue).ToList();

            Trendline trendline = new Trendline((IList<decimal>)ListOfYaxisValues, (IList<decimal>)ListOfXaxisValues);

            //The two positions to generate point between
            Vector3 positionA = new Vector3(Decimal.ToSingle(trendline.Start));
            Vector3 positionB = new Vector3(Decimal.ToSingle(trendline.End));

            //The number of points to generate
            const int pointsCount = 26;
            //Where to store those number of points
            Vector3[] pointsResult;

            pointsResult = new Vector3[pointsCount];
            trendline.GeneratePoints(positionA, positionB, pointsResult, pointsCount);

            parameterTrendData.MeasurementErrors[0].TrendLineCalculated = new List<TrendLineData>();

            // load trendline values into displayable enumeration
            int count = 0;
            foreach (var point in pointsResult)
            {
                TrendLineData myTrendLine = new TrendLineData();
                myTrendLine.ID = "TrendLine";
                myTrendLine.XAxisValue = count;
                myTrendLine.YAxisValue = (decimal)point.Y;
                
                parameterTrendData.MeasurementErrors[0].TrendLineCalculated.Add(myTrendLine);
                count++;
            }

            return parameterTrendData;
        }

        /// <summary>
        /// This will probaly be called from the Client service. 
        /// I put code here for reference
        /// I do not know if we get back a URI to a file or memory stream string
        /// Either way, we will fetch the PDF
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetInspectionChartPdf(string id)
        {           

            MemoryStream ms = new MemoryStream();
            string s = string.Empty;

            try
            {
                // check for resource etc. Stubbed code here for reference
                //Client.DownloadMeasurementObjectFile(ms, id, "GAMA_A1", "InspectionChartPDF");

                s = Convert.ToBase64String(ms.ToArray());
                 
            }
            catch(Exception ex)
            {
                // do something with exception
            }

            return s;

        }
    }
}
