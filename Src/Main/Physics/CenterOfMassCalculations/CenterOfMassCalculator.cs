using System.Collections.Generic;

namespace USC.GISResearchLab.Common.Core.Physics.CenterOfMassCalculations
{
    public class CenterOfMassCalculator
    {

        public static double[] GetCenterOfMass(List<double[]> xymList)
        {
            double[] ret = new double[2];

            double totalMass = 0;
            double totalX = 0;
            double totalY = 0;

            // sum up the total x, y, and mass of the sytem
            foreach (double[] xym in xymList)
            {
                totalX += xym[0] * xym[2];
                totalY += xym[1] * xym[2];
                totalMass += xym[2];
            }

            ret[0] = totalX / totalMass;
            ret[1] = totalY / totalMass;


            return ret;
        }
    }
}
