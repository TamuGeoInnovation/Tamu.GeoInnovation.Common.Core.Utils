using System;

namespace USC.GISResearchLab.Common.Core.Utils.Booleans
{
    public class BooleanUtils
    {
        public static bool IsBoolean(object o)
        {
            bool ret = true;
            try
            {
                bool test = Convert.ToBoolean(o);
            }
            catch (Exception)
            {
                ret = false;
            }

            return ret;
        }
    }
}
