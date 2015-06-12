using System;
using System.Text;

namespace USC.GISResearchLab.Common.Utils.Types
{
    public class TypeUtils
    {
        public static object GetDefaultValue(Type type)
        {
            object ret = null;

            try
            {
                if (type.Equals(typeof(Int16)))
                {
                    ret = new Int16();
                }
                else if (type.Equals(typeof(Int32)))
                {
                    ret = new Int32();
                }
                else if (type.Equals(typeof(String)))
                {
                    ret = new StringBuilder().ToString();
                }
                else if (type.Equals(typeof(DateTime)))
                {
                    ret = new DateTime();
                }
                else if (type.Equals(typeof(Char)))
                {
                    ret = new Char();
                }
                else if (type.Equals(typeof(Double)))
                {
                    ret = new Double();
                }
                else if (type.Equals(typeof(Decimal)))
                {
                    ret = new Decimal();
                }
                else if (type.Equals(typeof(Single)))
                {
                    ret = new Single();
                }
                else
                {
                    throw new Exception("GetDefaultValue error - Unknown type: " + type.ToString());
                }

            }
            catch (Exception e)
            {
                throw new Exception("Error occurred getting default value for type: " + type.ToString() + " - " + e.Message, e);
            }

            return ret;
        }

        public static Type FromName(string name)
        {
            Type ret = null;
            if (String.Compare(name, "integer", true) == 0)
            {
                ret = typeof(Int32);
            }
            else if (String.Compare(name, "string", true) == 0)
            {
                ret = typeof(String);
            }
            else if (String.Compare(name, "double", true) == 0)
            {
                ret = typeof(Double);
            }
            else if (String.Compare(name, "decimal", true) == 0)
            {
                ret = typeof(Decimal);
            }
            else if (String.Compare(name, "single", true) == 0)
            {
                ret = typeof(Single);
            }
            else if (String.Compare(name, "datetime", true) == 0)
            {
                ret = typeof(DateTime);
            }
            else
            {
                throw new Exception("Type FromName exception: Unknown type: " + name);
            }

            return ret;
        }
    }
}
