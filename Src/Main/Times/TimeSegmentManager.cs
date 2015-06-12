using System;
using System.Data;

namespace USC.GISResearchLab.Common.Core.Times
{
    public enum TimeSegmentTypes {year, month, week, day, hour, minute, second, millisecond};

    public class TimeSegmentManager
    {

        public static DataTable GetAllTimeSegmentTypes()
        {
            DataTable ret = new DataTable();
            ret.Columns.Add(new DataColumn("value", typeof(string)));

            foreach (TimeSegmentTypes item in Enum.GetValues(typeof(TimeSegmentTypes)))
            {
                DataRow row = ret.NewRow();
                row["value"] = item.ToString();
                ret.Rows.Add(row);
            }

            return ret;
        }

        public static TimeSegmentTypes GetTimeSegmentTypeFromString(string s)
        {
            TimeSegmentTypes ret = TimeSegmentTypes.year;

            if (String.Compare(s, "year", true) == 0)
            {
                ret = TimeSegmentTypes.year;
            }
            else if (String.Compare(s, "month", true) == 0)
            {
                ret = TimeSegmentTypes.month;
            }
            else if (String.Compare(s, "week", true) == 0)
            {
                ret = TimeSegmentTypes.week;
            }
            else if (String.Compare(s, "day", true) == 0)
            {
                ret = TimeSegmentTypes.day;
            }
            else if (String.Compare(s, "hour", true) == 0)
            {
                ret = TimeSegmentTypes.hour;
            }
            else if (String.Compare(s, "minute", true) == 0)
            {
                ret = TimeSegmentTypes.minute;
            }
            else if (String.Compare(s, "second", true) == 0)
            {
                ret = TimeSegmentTypes.second;
            }
            else if (String.Compare(s, "millisecond", true) == 0)
            {
                ret = TimeSegmentTypes.millisecond;
            }
            else
            {
                throw new Exception("Unexpected or unimplemented TimeSegmentTypes: " + s);
            }

            return ret;
        }

    }
}
