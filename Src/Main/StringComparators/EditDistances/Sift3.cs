using System;

namespace USC.GISResearchLab.Common.Core.StringComparators.EditDistances
{
    // this is from http://siderite.blogspot.com/2007/04/super-fast-and-accurate-string-distance.html
    public class Sift3
    {
        public static float Distance(string s1, string s2, int maxOffset)
        {
            if (String.IsNullOrEmpty(s1))
            {
                return String.IsNullOrEmpty(s2) ? 0 : s2.Length;
            }
            if (String.IsNullOrEmpty(s2))
            {
                return s1.Length;
            }
            int c = 0;
            int offset1 = 0;
            int offset2 = 0;
            int lcs = 0;
            while ((c + offset1 < s1.Length) && (c + offset2 < s2.Length))
            {
                if (s1[c + offset1] == s2[c + offset2])
                {
                    lcs++;
                }
                else
                {
                    offset1 = 0;
                    offset2 = 0;
                    for (int i = 0; i < maxOffset; i++)
                    {
                        if ((c + i < s1.Length) && (s1[c + i] == s2[c]))
                        {
                            offset1 = i;
                            break;
                        }
                        if ((c + i < s2.Length) && (s1[c] == s2[c + i]))
                        {
                            offset2 = i;
                            break;
                        }
                    }
                }
                c++;
            }
            return (s1.Length + s2.Length) / 2 - lcs;
        }
    }
}
