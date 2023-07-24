using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TrendingChart
{
    public class Trendline
    {
        public Trendline(IList<decimal> yAxisValues, IList<decimal> xAxisValues)
            : this(yAxisValues.Select((t, i) => new Tuple<decimal, decimal>(xAxisValues[i], t)))
        { }
        public Trendline(IEnumerable<Tuple<Decimal, Decimal>> data)
        {
            var cachedData = data.ToList();

            var n = cachedData.Count;
            var sumX = cachedData.Sum(x => x.Item1);
            var sumX2 = cachedData.Sum(x => x.Item1 * x.Item1);
            var sumY = cachedData.Sum(x => x.Item2);
            var sumXY = cachedData.Sum(x => x.Item1 * x.Item2);

            //b = (sum(x*y) - sum(x)sum(y)/n)
            //      / (sum(x^2) - sum(x)^2/n)
            Slope = (sumXY - ((sumX * sumY) / n))
                        / (sumX2 - (sumX * sumX / n));

            //a = sum(y)/n - b(sum(x)/n)
            Intercept = (sumY / n) - (Slope * (sumX / n));

            Start = GetYValue(cachedData.Min(a => a.Item1));
            End = GetYValue(cachedData.Max(a => a.Item1));
        }

        public decimal Slope { get; private set; }
        public decimal Intercept { get; private set; }
        public decimal Start { get; private set; }
        public decimal End { get; private set; }

        public decimal GetYValue(decimal xValue)
        {
            return Intercept + Slope * xValue;
        }

        /// <summary>
        /// Based off from the start, end and slope - calc needed points to display on chart
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="result"></param>
        /// <param name="chunkAmount"></param>
        public void GeneratePoints(Vector3 from, Vector3 to, Vector3[] result, int chunkAmount)
        {
            //divider must be between 0 and 1
            float divider = 1f / chunkAmount;
            float linear = 0f;

            if (chunkAmount == 0)
            {
                Debug.WriteLine("chunkAmount Distance must be > 0 instead of " + chunkAmount);
                return;
            }

            if (chunkAmount == 1)
            {
                result[0] = Vector3.Lerp(from, to, 0.5f); //Return half/middle point
                return;
            }

            for (int i = 0; i < chunkAmount; i++)
            {
                if (i == 0)
                {
                    linear = divider / 2;
                }
                else
                {
                    linear += divider; //Add the divider to it to get the next distance
                }
                // Debug.Log("Loop " + i + ", is " + linear);
                result[i] = Vector3.Lerp(from, to, linear);
            }
        }
    }
}