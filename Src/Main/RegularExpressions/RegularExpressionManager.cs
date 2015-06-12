using System;
using System.Text.RegularExpressions;

namespace USC.GISResearchLab.Common.Core.RegularExpressions
{
    public class RegularExpressionManager
    {

        public static string StripHTML(string s)
        {
            string ret = s;
            if (!String.IsNullOrEmpty(s))
            {
                ret = Regex.Replace(s, @"<(.|\n)*?>", String.Empty);
            }
            return ret;
        }

        // this is from http://stackoverflow.com/questions/204646/
        public static bool ContainsHTML(string s)
        {
            bool ret = false;

            // check for open/close tag
            Regex tagRegex = new Regex(@"<\s*([^ >]+)[^>]*>.*?<\s*/\s*\1\s*>");
            ret = tagRegex.IsMatch(s);

            if (!ret)
            {
                // check for single tag
                Regex tagRegex2 = new Regex(@"<[^>]+>");
                ret = tagRegex2.IsMatch(s);
            }

            return ret;
        }

    }
}
