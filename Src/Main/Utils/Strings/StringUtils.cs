using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using USC.GISResearchLab.Common.Core.Utils.Booleans;
using USC.GISResearchLab.Common.Utils.Dates;
using USC.GISResearchLab.Common.Utils.Numbers;

namespace USC.GISResearchLab.Common.Utils.Strings
{
	/// <summary>
	/// Summary description for StringUtils.
	/// </summary>
	public class StringUtils
	{

        public enum EsacpeCharAction{remove, repeat, replace};

		public StringUtils()
		{
		}


        public static string GetRandomString()
        {
            string[] arrStr = "A,B,C,D,1,2,3,4,5,6,7,8,9,0".Split(",".ToCharArray());
            string strDraw = string.Empty;
            Random r = new Random();
            for (int i = 0; i < 5; i++)
            {
                strDraw += arrStr[r.Next(0, arrStr.Length - 1)];
            }
            return strDraw;
        }

        public static string EscapeChar(string fullString, string escapeChar, EsacpeCharAction action)
        {
            return EscapeChar(fullString, escapeChar, action, null);
        }

        public static string EscapeChar(string fullString, string escapeChar, EsacpeCharAction action, string replacementChar)
        {
            string ret = fullString;


            if (!String.IsNullOrEmpty(fullString))
            {
                switch (action)
                {
                    case EsacpeCharAction.remove:
                        ret = ret.Replace(escapeChar, "");
                        break;
                    case EsacpeCharAction.repeat:
                        ret = ret.Replace(escapeChar, escapeChar + escapeChar);
                        break;
                    case EsacpeCharAction.replace:
                        if (!String.IsNullOrEmpty(replacementChar))
                        {
                            ret = ret.Replace(escapeChar, replacementChar);
                        }
                        else
                        {
                            throw new Exception("Replacement character is null");
                        }
                        break;
                    default:
                        throw new Exception("Unexpected or unimplemented EsacpeCharAction: " + action);
                }
            }

            return ret;
        }

        public static NameValueCollection ToNameValueCollection(string qs)
        {
            NameValueCollection nvc = new NameValueCollection();
            //strip string data before the question mark
            qs = qs.IndexOf('?') > 0 ? qs.Remove(0, qs.IndexOf('?') + 1) : qs;
            
            string[] sqarr = qs.Split("&".ToCharArray());

            for (int i = 0; i < sqarr.Length; i++)
            {
                if (sqarr[i].IndexOf('=') > 0)
                {
                    string[] pairs = sqarr.GetValue(i).ToString().Split("=".ToCharArray());
                    nvc.Add(pairs[0], pairs[1]);
                }
            }
            return nvc;
        }

        public static string RemoveNonAlphaNumercChars(string s)
        {
            return RemoveNonAlphaNumercChars(s, null);
        }

        public static string RemoveNonAlphaNumercChars(string s, List<char> charsToKeep)
        {
            string ret = "";

            if (!String.IsNullOrEmpty(s))
            {
                int index = 0;
                foreach (char c in s.ToCharArray())
                {
                    if (charsToKeep != null)
                    {
                        if (Char.IsLetterOrDigit(c) || charsToKeep.Contains(c))
                        {
                            ret += c.ToString();
                        }
                    }
                    else
                    {
                        if (Char.IsLetterOrDigit(c))
                        {
                            ret += c.ToString();
                        }
                    }
                    index++;
                }
            }

            return ret;
        }

        public static bool ContainsNonAlphaNumercChars(string s)
        {
            bool ret = false;

            if (!String.IsNullOrEmpty(s))
            {
                int index = 0;
                foreach (char c in s.ToCharArray())
                {
                    if (!Char.IsLetterOrDigit(c))
                    {
                        ret = true;
                        break;
                    }
                    index++;
                }
            }

            return ret;
        }

        public static string ConcatCSV(string[] values)
        {
            return ConcatCSV(null, values, null);
        }

        public static string ConcatCSV(string csvList, string[] values)
        {
            return ConcatCSV(csvList, values, null);
        }

        public static string ConcatCSV(string[] values, string surroundingChar)
        {
            return ConcatCSV(null, values, surroundingChar);
        }

        public static string ConcatCSV(string csvList, string[] values, string surroundingChar)
        {
            string ret = csvList;
            int i = 0;
            if (values != null)
            {
                foreach (string s in values)
                {
                    ret = ConcatCSV(i, ret, s, surroundingChar);
                    i++;
                }
            }
            return ret;
        }

        public static string ConcatCSV(string csvList, string s)
        {
            return ConcatCSV(1, csvList, s, null);
        }

        public static string ConcatCSV(int index, string csvList, string s, string surroundingChar)
        {
            string ret = csvList;


            if (!String.IsNullOrEmpty(surroundingChar))
            {
                if (s.Contains(surroundingChar))
                {
                    s = s.Replace(surroundingChar, surroundingChar + surroundingChar);
                }
            }
            else // if there isn't any surrounding char, there is no way we can leave a comma in there - replace with [and]
            {
                if (s.Contains(","))
                {
                    s = s.Replace(",", " [and] ");
                }
            }

            if (String.IsNullOrEmpty(ret) && index == 0)
            {
                if (!String.IsNullOrEmpty(surroundingChar))
                {
                    ret = surroundingChar + s + surroundingChar;
                }
                else
                {
                    ret = s;
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(ret))
                {
                    if (!String.IsNullOrEmpty(surroundingChar))
                    {
                        ret += "," + surroundingChar + s + surroundingChar;
                    }
                    else
                    {
                        ret += "," + s;
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(surroundingChar))
                    {
                        ret += surroundingChar + s + surroundingChar;
                    }
                    else
                    {
                        ret += s;
                    }
                }
            }
            return ret;
        }

        public static string[] SplitAddressOnSpaces(string s)
        {
            return s.Split(' ');
        }

        public static string Shorten(string s, int length)
        {
            if (s != null)
            {
                if (s.Length > length)
                {
                    s = s.Substring(0, length - 3);
                    s += "...";
                }
            }
            return s;
        }

        public static string GetNextIncrementalString(string s)
        {
            string ret = "";

            string lastChar = Convert.ToString(s[s.Length - 1]);
            if (NumberUtils.IsInt(lastChar))
            {
                int lastInt = NumberUtils.AsInt(lastChar);
                lastInt++;
                ret = s.Substring(0, s.Length - 1) + lastInt;

            }
            else
            {
                ret = s + "_1";
            }

            return ret;
        }

        public static bool ContainsNumeral(string s)
        {
            return NumberUtils.ContainsNumeral(s);
        }

        public static int GetFirstNumeral(string s)
        {
            return NumberUtils.GetFirstNumeral(s);
        }

        public static int GetLastNumeral(string s)
        {
            return NumberUtils.GetLastNumeral(s);
        }

		public static bool IsEmpty(string s)
		{
			bool ret = true;
			if (s != null)
			{
				if (s != String.Empty)
				{
					ret = false;
				}
			}
			return ret;
		}


        // this is from http://stackoverflow.com/questions/11789194/string-format-how-can-i-format-to-x-digits-regardless-of-decimal-place
        // sets a specific number of decimal places, pads to the right with 0's if not there, puts a +/- in front, does not round
        public static string FormatNumDigitsWithSign(double number, int x)
        {
            string asString = (number >= 0 ? "+" : "") + number.ToString("F50", System.Globalization.CultureInfo.InvariantCulture);

            if (asString.Contains("."))
            {
                if (asString.Length > x + 2)
                {
                    return asString.Substring(0, x + 2);
                }
                else
                {
                    // Pad with zeros
                    return asString.Insert(asString.Length, new String('0', x + 2 - asString.Length));
                }
            }
            else
            {
                if (asString.Length > x + 1)
                {
                    return asString.Substring(0, x + 1);
                }
                else
                {
                    // Pad with zeros
                    return asString.Insert(1, new String('0', x + 1 - asString.Length));
                }
            }
        }

        // this is from http://stackoverflow.com/questions/11789194/string-format-how-can-i-format-to-x-digits-regardless-of-decimal-place
        // sets a specific number of decimal places, pads to the right with 0's if not there, does not put a + in front if not already there, does not round
        public static string FormatNumDigits(double number, int x)
        {
            string asString = number.ToString("F50", System.Globalization.CultureInfo.InvariantCulture);

            if (asString.Contains("."))
            {
                if (asString.Length > x + 2)
                {
                    return asString.Substring(0, x + 2);
                }
                else
                {
                    // Pad with zeros
                    return asString.Insert(asString.Length, new String('0', x + 2 - asString.Length));
                }
            }
            else
            {
                if (asString.Length > x + 1)
                {
                    return asString.Substring(0, x + 1);
                }
                else
                {
                    // Pad with zeros
                    return asString.Insert(1, new String('0', x + 1 - asString.Length));
                }
            }
        }

        public static string FormatNumDigits(double d, int totalCharacterLength, bool shouldRound, int roundedNumberOfDecimalPlaces, bool shouldIncludePositiveNegative)
        {
            string ret = "";

            try
            {
                double rounded = d;
                if (shouldRound)
                {
                    rounded = System.Math.Round(rounded, roundedNumberOfDecimalPlaces);
                }

                if (shouldIncludePositiveNegative)
                {
                    ret = FormatNumDigitsWithSign(rounded, totalCharacterLength - 2);
                }
                else
                {
                    ret = FormatNumDigits(rounded, totalCharacterLength - 2);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Exception in FormatNumDigits - " + e.Message, e);
            }

            return ret;
        }



        public static string CleanWhitespaces(string s)
        {
            if (!IsEmpty(s))
            {
                s = s.Trim();

                s = s.Replace("\t", " ");
                s = s.Replace("\r\n", " ");
                s = s.Replace("\n", " ");
                s = s.Replace(Environment.NewLine, " ");

                s = s.Replace("  ", " ");
            }
            return s;
        }


        public static bool AreEqualIgnoreCase(string s1, string s2)
        {
            return (String.Compare(s1, s2, true) == 0);
        }

        public static string PadLeft(string s, string pad, int totalLength)
        {
            string ret = null;

            if (pad != null)
            {
                if (s == null)
                {
                    s = "";
                }

                while (s.Length < totalLength)
                {
                    s = pad + s;
                }

                ret = s;
            }

            return ret;
        }

        public static string ReplaceAfterIndex(string inputString, int searchStartPosition, string searchTerm, string replaceTerm)
        {
            string ret = null;

            if (!String.IsNullOrEmpty(inputString))
            {
                if (inputString.Length > searchStartPosition)
                {
                    int searchIndex = inputString.IndexOf(searchTerm, searchStartPosition);
                    if (searchIndex > 0)
                    {
                        string firstHalf = inputString.Substring(0, searchIndex);

                        int remainingLength = inputString.Length - searchIndex - searchTerm.Length;

                        if (remainingLength > 0)
                        {
                            string secondHalf = inputString.Substring(searchIndex + searchTerm.Length, remainingLength);

                            ret = firstHalf + replaceTerm + secondHalf;
                        }
                    }
                }
            }

            return ret;
        }

        public static bool StartsWithNumber(string s)
        {
            bool ret = false;
            if (s != null)
            {
                if (s.Length > 0)
                {
                    string firstChar = s[0].ToString();
                    ret = StringIsInt(firstChar);
                }
            }
            return ret;
        }

        public static bool IsBoolean(int i)
        {
            bool ret = false;
            
            if (i == 0 || i == 1)
            {
                ret = true;
            }
            
            return ret;
        }

        public static bool IsBoolean(string s)
        {
            return BooleanUtils.IsBoolean(s);
        }

        public static bool StringIsInt(string s)
        {
            return IsInt(s);
        }

        public static bool IsInt(string s)
        {
            return NumberUtils.IsInt(s);
        }

        public static int ToInt(string s)
        {
            return NumberUtils.AsInt(s);
        }

        public static bool IsDouble(string s)
        {
            return NumberUtils.IsDouble(s);
        }

        public static bool IsDateTime(string s)
        {
            return DateTimeUtils.IsDateTime(s);
        }

        public static bool IsTimeSpan(string s)
        {
            return DateTimeUtils.IsTimeSpan(s);
        }

        public static bool ToBool(string s)
        {
            bool ret = false;
            if (s != null)
            {
                s = s.Trim();
                try
                {
                    ret = Convert.ToBoolean(s);
                }
                catch (Exception)
                {
                    ret = false;
                }
            }
            return ret;
        }

        public static double ToDouble(string s)
        {
            return NumberUtils.AsDouble(s);
        }

        public static string Sanitize(string s)
        {
            if (!IsEmpty(s))
            {
                s = s.Trim();
                s = s.Replace("'", "''");
                s = s.ToUpper();
                s = CleanWhitespaces(s);
            }
            return s;
        }

        public string ValueOrNullString(string s)
        {
            string ret;
            if (IsEmpty(s))
            {
                ret = "null";
            }
            else
            {
                ret = s;
            }
            return ret;
        }

        public static string ValueAndBlankOrNoBlank(string s)
        {
            string ret = "";
            if (!IsEmpty(s))
            {
                ret = s + " ";
            }
            return ret;
        }

        public static string ValueOrNoBlank(string s)
        {
            string ret = "";
            if (!IsEmpty(s))
            {
                ret = s;
            }
            return ret;
        }

        public static string ValueOrEmpty(string s)
        {
            string ret = "";
            if (!String.IsNullOrEmpty(s))
            {
                ret = s;
            }
            return ret;
        }

        public static string ValueOrNoBlank(string s, bool includeTrailingSpace)
        {
            string ret = "";
            if (!IsEmpty(s))
            {
                ret = s;
                if (includeTrailingSpace)
                {
                    ret += " ";
                }
            }
            return ret;
        }

        public static string ValueOrBlank(string s)
        {
            string ret = " ";
            if (!IsEmpty(s))
            {
                ret = s;
            }
            return ret;
        }

        public static string ValueOrReplacement(string s, string replacement)
        {
            string ret = replacement;
            if (!IsEmpty(s))
            {
                ret = s;
            }
            return ret;
        }

        public static string TrimLeading(string s, string toTrim)
        {
            if (!IsEmpty(s))
            {
                s = s.Trim();
                if (s.StartsWith(toTrim))
                {
                    s = s.Substring(toTrim.Length);
                }
            }
            return s;
        }

        public static string TrimEnd(string s, string toTrim)
        {
            if (!IsEmpty(s))
            {
                s = s.Trim();
                if (s.EndsWith(toTrim))
                {
                    s = s.Substring(0, s.Length - 1);
                }
            }
            return s;
        }

        public static string TrimCSVList(string s)
        {
            return TrimEnd(s, ",");
        }

        public static string TrimBarList(string s)
        {
            return TrimEnd(s, "|");
        }

        public static string Clean(string s)
        {
            string ret = s;
            if (!IsEmpty(s))
            {
                if (s != null)
                {
                    ret = s.Trim().ToUpper();
                }
            }
            return ret;
        }

        
        public static string InsertCharAtPositionFromEnd(string source, string insert, int position)
        {
            string ret = "";

            if (position < source.Length)
            {
                int count = 0;
                for (int i = source.Length - 1; i >= 0; i--)
                {
                    char current = source[i];
                    if (count == position)
                    {
                        ret = insert + ret;
                    }

                    ret = current + ret;

                    count++;
                }
            }

            return ret;
        }

        public static string FromArray(string[] arr, string between)
        {
            return ConcatArrayWithCharBetween(arr, between);
        }

        public static string ConcatArrayAsStringWithCharBetween(string[] arr, string between)
        {
            string ret = "";
            if (arr != null)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (!String.IsNullOrEmpty(ret))
                    {
                        ret += between;
                    }

                    if (!String.IsNullOrEmpty(arr[i]))
                    {
                        ret += arr[i];
                    }
                }
            }
            return ret;
        }

        public static string ConcatArrayWithCharBetween(string[] arr, string between)
        {
            string ret = null;
            if (arr != null)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (!String.IsNullOrEmpty(arr[i]))
                    {
                        if (String.IsNullOrEmpty(ret))
                        {
                            ret += arr[i];
                        }
                        else
                        {
                            ret += between + arr[i];
                        }
                    }
                }
            }
            return ret;
        }

        public static string ConcatArrayArrayWithCharBetween(string[][] arrArr, string between)
        {
            string ret = "";

            if (arrArr != null)
            {
                for (int i = 0; i < arrArr.Length; i++)
                {
                    string[] arr = arrArr[i];

                    if (arr != null)
                    {
                        for (int j = 0; j < arr.Length; j++)
                        {
                            if (!String.IsNullOrEmpty(ret))
                            {
                                ret += between;
                            }
                            ret += arr[i];
                        }
                    }
                }
            }
            return ret;
        }
	}
}
