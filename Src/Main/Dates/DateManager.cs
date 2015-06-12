using System;
using System.Globalization;

namespace USC.GISResearchLab.Common.Core.Dates
{
    public class DateManager
    {

        public static int[] GetDaysInMonths(int year)
        {
            GregorianCalendar calendar = new GregorianCalendar();
            int[] ret = new int[12];
            for (int i = 0; i < 12; i++)
            {
                ret[i] = calendar.GetDaysInMonth(year, i + 1);
            }
            return ret;
        }

        public static int GetDayOfYearFromStartDayOfMonth(int month, int year)
        {
            int ret = 1;
            int[] daysInMonths = GetDaysInMonths(year);
            for (int i = 0; i < month; i++)
            {
                ret += daysInMonths[i];
            }

            return ret;
        }

        public static DateTime GetDateFromDayOfYear(int dayOfYear, int year)
        {
            DateTime ret = new DateTime();

            try
            {
                int[] daysInMonths = GetDaysInMonths(year);

                int month = 0;
                int daysPotential = 0;
                int daysUsed = 0;

                for (int i = 0; i < daysInMonths.Length; i++)
                {
                    daysPotential += daysInMonths[i];
                    if (dayOfYear <= daysPotential)
                    {
                        month = i + 1;
                        break;
                    }

                    daysUsed += daysInMonths[i];
                }

                int dayOfMonth = dayOfYear - daysUsed;

                ret = new DateTime(year, month, dayOfMonth);

            }
            catch (Exception e)
            {
                throw new Exception("Exception in GetDateFromDayOfYear: " + e.Message, e);
            }
            return ret;
        }


        public static DateTime GetDateFromStartOfWeek(int weekNumber, int year)
        {
            int[] daysInMonths = GetDaysInMonths(year);
            int dayOfYear = ((weekNumber - 1) * 7) + 1;
            return GetDateFromDayOfYear(dayOfYear, year);
        }

    }
}
