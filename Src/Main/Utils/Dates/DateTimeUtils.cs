using System;
using USC.GISResearchLab.Common.Utils.Math;

namespace USC.GISResearchLab.Common.Utils.Dates
{
	/// <summary>
	/// Summary description for DateTimeUtils.
	/// </summary>
	public class DateTimeUtils
	{
		public static TimeSpan MAX_TIME_SPAN = new TimeSpan(9999, 0, 0);
		public static TimeSpan MIN_TIME_SPAN = new TimeSpan(0, 0, 0, 0, 0);

		public static TimeSpan DEFAULT_TIME_SPAN = new TimeSpan(0, 0, 1, 0, 0);
		
		public static DateTime MAX_DATETIME = new DateTime(9999,1,1);
		public static DateTime MIN_DATETIME = new DateTime(1,1,1);

		public DateTimeUtils()
		{
		}

        public static bool IsDateTime(string s)
        {
            bool ret = false;

            try
            {
                DateTime d = DateTime.Parse(s);
                ret = true;
            }
            catch (Exception e)
            {
                ret = false;
            }

            return ret;
        }

        public static bool IsTimeSpan(string s)
        {
            bool ret = false;

            try
            {
                TimeSpan d = TimeSpan.Parse(s);
                ret = true;
            }
            catch (Exception e)
            {
                ret = false;
            }

            return ret;
        }

        public static bool withinRange(DateTime d, DateTime start, DateTime end)
        {
            bool ret = false;

            if ((d.Ticks >= start.Ticks) && (d.Ticks <= end.Ticks))
            {
                ret = true;
            }

            return ret;
        }

		public static DateTime buildDateTime(string date, string time)
		{
			return DateTime.Parse(date + " " + time);

		}

		public static DateTime getDateTime(string time, string date)
		{
			DateTime ret;

			// Extract hours, minutes, seconds and milliseconds
			int UtcHours = Convert.ToInt32(time.Substring(0, 2));
			int UtcMinutes = Convert.ToInt32(time.Substring(2, 2));
			int UtcSeconds = Convert.ToInt32(time.Substring(4, 2));
			int UtcMilliseconds = 0;

			// Extract milliseconds if it is available
			if (time.Length > 7)
			{
				UtcMilliseconds = Convert.ToInt32(time.Substring(7));
			}

			// Extract day , month, and year
			int UtcDay = Convert.ToInt32(date.Substring(0, 2));
			int UtcMonth = Convert.ToInt32(date.Substring(2, 2));
			int UtcYear = 2000 + Convert.ToInt32(date.Substring(4, 2));

			// Now build a DateTime object with all values
			DateTime SatelliteTime = new DateTime(UtcYear,
				UtcMonth, UtcDay, UtcHours, UtcMinutes, UtcSeconds,
				UtcMilliseconds);

			ret = SatelliteTime.ToLocalTime();
			
			return ret;
		}

		public static DateTime getTime(string s)
		{
			DateTime ret;

			// Extract hours, minutes, seconds and milliseconds
			int UtcHours = Convert.ToInt32(s.Substring(0, 2));
			int UtcMinutes = Convert.ToInt32(s.Substring(2, 2));
			int UtcSeconds = Convert.ToInt32(s.Substring(4, 2));
			int UtcMilliseconds = 0;

			// Extract milliseconds if it is available
			if (s.Length > 7)
			{
				UtcMilliseconds = Convert.ToInt32(s.Substring(7));
			}

			// Now build a DateTime object with all values
			DateTime Today = DateTime.Now.ToUniversalTime();
			DateTime SatelliteTime = new DateTime(Today.Year,
				Today.Month, Today.Day, UtcHours, UtcMinutes, UtcSeconds,
				UtcMilliseconds);

			ret = SatelliteTime.ToLocalTime();
			
			return ret;
		}

		public static DateTime getMinDateTime(DateTime t1, DateTime t2)
		{
			DateTime ret;
			if (t1.Equals(null) && !t2.Equals(null))
			{
				ret = t2;
			}
			else if(t2.Equals(null) && !t1.Equals(null))
			{
				ret = t1;
			}
			else if (t1.Equals(null) && t2.Equals(null))
			{
				throw new Exception("DateTimeUtils.minDateTime(t1, t2) Exception: both parameters are null");
			}
			else
			{
				if (t1 <= t2)
				{
					ret = t1;
				}
				else
				{
					ret = t2;
				}
			}
			return ret;
		}

		public static DateTime getMaxDateTime(DateTime t1, DateTime t2)
		{
			DateTime ret;
			if (t1.Equals(null) && !t2.Equals(null))
			{
				ret = t2;
			}
			else if(t2.Equals(null) && !t1.Equals(null))
			{
				ret = t1;
			}
			else if (t1.Equals(null) && t2.Equals(null))
			{
				throw new Exception("DateTimeUtils.maxDateTime(t1, t2) Exception: both parameters are null");
			}
			else
			{
				if (t1 >= t2)
				{
					ret = t1;
				}
				else
				{
					ret = t2;
				}
			}
			return ret;
		}

		public static TimeSpan getMinTimeSpan(TimeSpan t1, TimeSpan t2, TimeSpan t3, TimeSpan t4)
		{
			TimeSpan m1 = getMinTimeSpan(t1, t2);
			TimeSpan m2 = getMinTimeSpan(t3, t4);
			return getMinTimeSpan(m1, m2);
		}

		public static TimeSpan getMinTimeSpan(TimeSpan t1, TimeSpan t2)
		{
			TimeSpan ret;
			if (t1.Equals(null) && !t2.Equals(null))
			{
				ret = t2;
			}
			else if(t2.Equals(null) && !t1.Equals(null))
			{
				ret = t1;
			}
			else if (t1.Equals(null) && t2.Equals(null))
			{
				throw new Exception("DateTimeUtils.getMinTimeSpan(t1, t2) Exception: both parameters are null");
			}
			else
			{
				if (t1 <= t2)
				{
					ret = t1;
				}
				else
				{
					ret = t2;
				}
			}
			return ret;
		}

        public static TimeSpan getMaxTimeSpan(TimeSpan t1, TimeSpan t2, TimeSpan t3, TimeSpan t4)
        {
            TimeSpan m1 = getMaxTimeSpan(t1, t2);
            TimeSpan m2 = getMaxTimeSpan(t3, t4);
            return getMaxTimeSpan(m1, m2);
        }

        public static TimeSpan getMaxTimeSpan(TimeSpan t1, TimeSpan t2)
        {
            TimeSpan ret;
            if (t1.Equals(null) && !t2.Equals(null))
            {
                ret = t2;
            }
            else if (t2.Equals(null) && !t1.Equals(null))
            {
                ret = t1;
            }
            else if (t1.Equals(null) && t2.Equals(null))
            {
                throw new Exception("DateTimeUtils.getMaxTimeSpan(t1, t2) Exception: both parameters are null");
            }
            else
            {
                if (t1 >= t2)
                {
                    ret = t1;
                }
                else
                {
                    ret = t2;
                }
            }
            return ret;
        }

		public static TimeSpan getGreatestComomonTimeSpanDivisor(TimeSpan t1, TimeSpan t2, TimeSpan t3, TimeSpan t4)
		{
			TimeSpan gcd1 = getGreatestComomonTimeSpanDivisor(t1, t2);
			TimeSpan gcd2 = getGreatestComomonTimeSpanDivisor(t3, t4);
			return getGreatestComomonTimeSpanDivisor(gcd1, gcd2);
		}

		public static TimeSpan getGreatestComomonTimeSpanDivisor(TimeSpan t1, TimeSpan t2)
		{
			long greatestCommonTicks = MathUtils.greatestCommonDivisor(t1.Ticks, t2.Ticks);
			return new TimeSpan(greatestCommonTicks);
		}
	}
}

