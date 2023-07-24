using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendingChart.Models
{
    /// <summary>
    /// Tolerance line definition
    /// </summary>
    public class ToleranceLineData
    {
        /// <summary>
        /// Creates an instance of the ToleranceLineData class
        /// </summary>
        public ToleranceLineData()
        {
            Label = string.Empty;
        }

        /// <summary>
        ///  Display name for the constant line on the chart (human readable and translated)
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Y-axis value for the constant line on the chart
        /// </summary>
        public decimal Value { get; set; }
    }

    /// <summary>
    /// Measurement error data and details for a single data point
    /// </summary>
    public class MeasurementErrorData
    {
        /// <summary>
        /// Creates an instance of the MeasurementErrorData class
        /// </summary>
        public MeasurementErrorData()
        {
            PdfData = string.Empty;
        }

        /// <summary>
        /// Plottable measurement error value
        /// </summary>
        public decimal ErrorValue { get; set; }

        /// <summary>
        /// Plottable x axis value
        /// </summary>
        public decimal XAxisValue { get; set; }

        /// <summary>
        /// Displayable correction value that was made to the measurement error value
        /// </summary>
        public decimal CorrectionValue { get; set; }

        /// <summary>
        /// Base64 encoded pdf data from the measurement machine
        /// </summary>
        public string PdfData { get; set; }

        /// <summary>
        /// list of calculated trend data to overlay on chart display
        /// </summary>
        public List<TrendLineData> TrendLineCalculated { get; set; }
    }

    /// <summary>
    /// Calculated Trendline data
    /// </summary>
    public class TrendLineData
    {
        /// <summary>
        /// Creates an instance of the TrendLineData class
        /// </summary>
        public TrendLineData()
        {
            ID = string.Empty;
        }

        /// <summary>
        /// Identifier for the parameter (not displayed)
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Plottable x axis trend value
        /// </summary>
        public decimal XAxisValue { get; set; }

        /// <summary>
        /// Plottable y axis trend value
        /// </summary>
        public decimal YAxisValue { get; set; }

    }

    /// <summary>
    /// Parameter Trend Data model provided by ConfigApp Parameter Grid page
    /// </summary>
    public class ParameterTrendData
    {
        /// <summary>
        /// Creates an instance of the ParameterTrendData class
        /// </summary>
        public ParameterTrendData()
        {
            ID = string.Empty;
            ChartLabel = string.Empty;
            XAxisLabel = string.Empty;
            YAxisLabel = string.Empty;
            ErrorPlotLabel = string.Empty;
            TrendLineLabel = string.Empty;
            UpperFixedTolerance = new ToleranceLineData();
            LowerFixedTolerance = new ToleranceLineData();
            UpperNoCorrectionTolerance = new ToleranceLineData();
            LowerNoCorrectionTolerance = new ToleranceLineData();
            MeasurementErrors = new List<MeasurementErrorData>();
        }

        /// <summary>
        /// Identifier for the parameter (not displayed)
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Display name for the chart (human readable and translated parameter name)
        /// </summary>
        public string ChartLabel { get; set; }

        /// <summary>
        /// Display name for the charts x-axis (human readable and translated)
        /// </summary>
        public string XAxisLabel { get; set; }

        /// <summary>
        /// Display name for the charts y-axis (human readable and translated)
        /// </summary>
        public string YAxisLabel { get; set; }

        /// <summary>
        /// Display name for the error plot in legend (human readable and translated)
        /// </summary>
        public string ErrorPlotLabel { get; set; }

        /// <summary>
        /// Display name for the trend line in legend (human readable and translated)
        /// </summary>
        public string TrendLineLabel { get; set; }

        /// <summary>
        /// Upper fixed tolerance data
        /// </summary>
        public ToleranceLineData UpperFixedTolerance { get; set; }

        /// <summary>
        /// Lower fixed tolerance data
        /// </summary>
        public ToleranceLineData LowerFixedTolerance { get; set; }

        /// <summary>
        /// Upper no correction tolerance data
        /// </summary>
        public ToleranceLineData UpperNoCorrectionTolerance { get; set; }

        /// <summary>
        /// Lower no correction tolerance data
        /// </summary>
        public ToleranceLineData LowerNoCorrectionTolerance { get; set; }

        /// <summary>
        /// list of measurement errors to plot with details for roll-over display
        /// </summary>
        public List<MeasurementErrorData> MeasurementErrors { get; set; }       
    }
}
