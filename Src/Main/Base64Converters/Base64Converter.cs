using System;

namespace USC.GISResearchLab.Common.Utils.Converters
{
    public class Base64Converter
    {

        public static int GetConvertLenthFromBase64ToString(int base64Length)
        {
            int ret = -1;
            try
            {
                byte[] buff = new byte[base64Length];
                string s = System.Convert.ToBase64String(buff).ToUpper();
                ret = s.Length;
            }
            catch (Exception e)
            {
                throw new Exception("Error occured getting convert length" + e.Message, e);
            }
            return ret;
        }

    }
}
