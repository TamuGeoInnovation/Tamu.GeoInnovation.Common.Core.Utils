using System;
using System.Text;

namespace USC.GISResearchLab.Common.Utils.Encoding
{
    public class Utf8EncodingUtils
    {

        public static byte[] StringToUTF8ByteArray(string s)
        {
            byte[] ret = null;
            try
            {
                UTF8Encoding encoding = new UTF8Encoding();
                ret = encoding.GetBytes(s);
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred converting string into utf-8 byte array", e);
            }

            return ret;

        }

        public static string UTF8ByteArrayToString(byte[] bytes)
        {
            string ret = null;
            try
            {
                UTF8Encoding encoding = new UTF8Encoding();
                ret = encoding.GetString(bytes);
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred converting utf-8 byte array into string", e);
            }

            return ret;

        }

    }
}
