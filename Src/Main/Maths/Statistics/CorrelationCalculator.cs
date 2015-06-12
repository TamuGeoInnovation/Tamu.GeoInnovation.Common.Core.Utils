
using System;

namespace USC.GISResearchLab.Common.Core.Maths.Statistics
{
    public class CorrelationCalculator
    {

        public CorrelationCalculator()
        {

        }

        public double[] Correlation(double[] dataA, double[] dataB)
        {

            double covariance = 0;
            double pearson = 0;

            if (dataA.Length != dataB.Length)
            {
                throw new ArgumentException("Length of arrays are different");
            }

            DescriptiveStatisticsCalculator statisticsA = new DescriptiveStatisticsCalculator(dataA);
            DescriptiveStatisticsCalculator statisticsB = new DescriptiveStatisticsCalculator(dataB);

            for (int i = 0; i < dataA.Length; i++)
            {
                covariance += (dataA[i] - statisticsA.Average) * (dataB[i] - statisticsB.Average);
            }

            covariance /= dataA.Length;
            pearson = covariance / (statisticsA.StdDev * statisticsB.StdDev);

            return new double[] { covariance, pearson };
        }
    }
}
