using System;

namespace USC.GISResearchLab.Common.Utils.Math
{
    /// <summary>
    /// Summary description for MathUtils.
    /// </summary>
    public class MathUtils
    {
        public MathUtils()
        {
        }

        public static long greatestCommonDivisor(long a, long b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a = a % b;
                else
                    b = b % a;
            }
            if (a == 0)
                return b;
            else
                return a;
        }

        public static double DegreesToRadians(double degrees)
        {
            return (degrees * System.Math.PI / 180.0);
        }

        public static double RadiansToDegrees(double radians)
        {
            return (radians / System.Math.PI * 180.0);
        }

        public static int GetNumberOfDecimals(decimal d)
        {
            return BitConverter.GetBytes(decimal.GetBits(d)[3])[2];
        }
    }
}
