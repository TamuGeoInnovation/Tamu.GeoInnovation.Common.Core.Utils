using System;
using System.Collections;

namespace USC.GISResearchLab.Common.Utils.Numbers
{
    /// <summary>
    /// Summary description for NumberUtils.
    /// </summary>
    public class NumberUtils
    {
        public NumberUtils()
        {
        }

        static NumberUtils()
        {
            onesNonOrdinalHashtable = new Hashtable();
            for (int i = 0; i < onesNonOrdinal.Length; i++)
            {
                onesNonOrdinalHashtable.Add(onesNonOrdinal[i], i);
            }

            onesOrdinalHashtable = new Hashtable();
            for (int i = 0; i < onesOrdinal.Length; i++)
            {
                onesOrdinalHashtable.Add(onesOrdinal[i], i);
            }

            tensNonOrdinalHashTable = new Hashtable();
            for (int i = 0; i < tensNonOrdinal.Length; i++)
            {
                tensNonOrdinalHashTable.Add(tensNonOrdinal[i], i);
            }

            tensOrdinalHastable = new Hashtable();
            for (int i = 0; i < tensOrdinal.Length; i++)
            {
                tensOrdinalHastable.Add(tensOrdinal[i], i);
            }

            thouHashtable = new Hashtable();
            for (int i = 0; i < thou.Length; i++)
            {
                thouHashtable.Add(thou[i], i);
            }
        }

        public static String[] abbreviation_suffixes = { "ST", "ND", "RD", "TH" };

        public static Hashtable onesNonOrdinalHashtable;
        public static String[] onesNonOrdinal ={
                            "zero",
                            "one",
                            "two",
                            "three",
                            "four",
                            "five",
                            "six",
                            "seven",
                            "eight",
                            "nine",
                            "ten",
                            "eleven",
                            "twelve",
                            "thirteen",
                            "fourteen",
                            "fifteen",
                            "sixteen",
                            "seventeen",
                            "eighteen",
                            "nineteen"
                          };

        public static Hashtable onesOrdinalHashtable;
        public static String[] onesOrdinal ={
                            "zeroth",
                            "first",
                            "second",
                            "third",
                            "fourth",
                            "fifth",
                            "sixth",
                            "seventh",
                            "eighth",
                            "ninth",
                            "tenth",
                            "eleventh",
                            "twelveth",
                            "thirteenth",
                            "fourteenth",
                            "fifteenth",
                            "sixteenth",
                            "seventeenth",
                            "eighteenth",
                            "nineteenth"
                          };

        public static Hashtable tensNonOrdinalHashTable;
        public static String[] tensNonOrdinal ={
                            "zero",
                            "ten",
                            "twenty",
                            "thirty",
                            "forty",
                            "fifty",
                            "sixty",
                            "seventy",
                            "eighty",
                            "ninety"
                          };

        public static Hashtable tensOrdinalHastable;
        public static String[] tensOrdinal ={
                            "zeroth",
                            "tenth",
                            "twentieth",
                            "thirtieth",
                            "fortieth",
                            "fiftieth",
                            "sixtieth",
                            "seventieth",
                            "eightieth",
                            "ninetieth"
                          };

        public static Hashtable thouHashtable;
        public static String[] thou ={
                            "",
                            "thousand",
                            "million",
                            "billion",
                            "trillion",
                            "quadrillion",
                            "quintillion"
                          };

        public static bool IsInt(object o)
        {
            return IsInt(o.ToString());
        }

        public static bool IsInt(string s)
        {
            bool ret = true;
            try
            {
                int test = 0;
                ret = Int32.TryParse(s, out test);
            }
            catch (Exception)
            {
                ret = false;
            }

            return ret;
        }

        public static bool IsDouble(string s)
        {
            return IsDouble((object)s);
        }

        public static bool IsDouble(object o)
        {
            bool ret = true;
            try
            {
                double test = Convert.ToDouble(o);

                if (Double.IsNaN(test))
                {
                    ret = false;
                }
            }
            catch (Exception)
            {
                ret = false;
            }

            return ret;
        }

        public static int AsInt(string s)
        {
            int ret = 0;
            try
            {
                if (s != null)
                {
                    s = s.Trim();
                    ret = Convert.ToInt32(s);
                }
            }
            catch (Exception e)
            {
                throw new Exception("An error occured parsing a int value", e);
            }

            return ret;
        }

        public static double AsDouble(string s)
        {
            double ret = 0;
            try
            {
                if (s != null)
                {
                    s = s.Trim();
                    ret = Convert.ToDouble(s);
                }
            }
            catch (Exception e)
            {
                throw new Exception("An error occured parsing double value", e);
            }
            return ret;
        }

        public static double AsDouble(string s, bool throwError)
        {
            double ret = 0;
            try
            {
                ret = AsDouble(s);
            }
            catch (Exception e)
            {
                if (throwError)
                {
                    throw new Exception("An error occured parsing a double value", e);
                }
            }
            return ret;
        }

        public static bool IsEven(double d)
        {
            return IsEven(Convert.ToInt32(d));
        }

        public static bool IsEven(int i)
        {
            return (evenOdd(i) == 0);
        }

        public static bool IsOdd(double d)
        {
            return IsOdd(Convert.ToInt32(d));
        }

        public static bool IsOdd(int i)
        {
            return (evenOdd(i) == 1);
        }

        public static int evenOdd(int i)
        {
            // return 
            //  0 for even
            //  1 for odd
            return i % 2;
        }

        public static double negative(double d)
        {
            return (-1.0 * d);
        }

        public static int RoundUp(double d)
        {
            int ret = (int)d;
            if (ret < d)
            {
                ret++;
            }
            return ret;
        }

        public static int RoundDown(double d)
        {
            return (int)d;
        }

        public static double getFractionalPart(double d)
        {
            return (d - getWholeNumberPart(d));
        }

        public static double getWholeNumberPart(double d)
        {
            int i = (int)d;
            double dNoFraction = i * 1.0;
            return dNoFraction;
        }

        public static double GetPercentageCompleted(int total, int completed)
        {
            double ret = 0;
            if (completed >= 0 && total > 0)
            {
                ret = (Convert.ToDouble(completed) / Convert.ToDouble(total)) * 100;
            }
            return ret;
        }

        public static double trimDecimals(double val, int decimalPlaces)
        {
            double ret;
            double mult = Convert.ToDouble(System.Math.Pow(10, decimalPlaces));
            double temp = val * mult;
            temp = getWholeNumberPart(temp);
            ret = temp / mult;
            return ret;
        }

        public static bool ContainsNumeral(string s)
        {
            bool ret = false;
            for (int i = 0; i < s.Length; i++)
            {
                if (IsInt(s[i].ToString()))
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        public static int GetFirstNumeral(string s)
        {
            int ret = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (IsInt(s[i].ToString()))
                {
                    ret = AsInt(s[i].ToString());
                    break;
                }
            }
            return ret;
        }

        public static int GetLeadingNumerals(string s)
        {
            int ret = 0;
            string temp = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (IsInt(s[i].ToString()))
                {
                    temp += s[i].ToString();
                }
                else
                {
                    break;
                }
            }

            if (!String.IsNullOrEmpty(temp))
            {
                if (IsInt(temp))
                {
                    ret = AsInt(temp);
                }
            }

            return ret;
        }

        public static string GetTrailingNonNumerals(string s)
        {
            string ret = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (!IsInt(s[i].ToString()))
                {
                    ret += s[i].ToString();
                }
            }

            return ret;
        }

        public static string GetTrailingAfterFirstNonNumerals(string s)
        {
            string ret = "";
            bool foundFristNonNumeral = false;

            for (int i = 0; i < s.Length; i++)
            {
                if (foundFristNonNumeral || !IsInt(s[i].ToString()))
                {
                    ret += s[i].ToString();
                    foundFristNonNumeral = true;
                }
            }

            return ret;
        }

        public static int GetLastNumeral(string s)
        {
            int ret = 0;
            for (int i = s.Length - 1; i > 0; i--)
            {
                if (IsInt(s[i].ToString()))
                {
                    ret = AsInt(s[i].ToString());
                    break;
                }
            }
            return ret;
        }

        public static bool IsNumberAndNumericAbbreviationSuffix(string s)
        {
            bool ret = false;
            if (!String.IsNullOrEmpty(s))
            {
                string abbreviationSuffix = getNumericAbbreviationSuffix(s);
                if (!String.IsNullOrEmpty(abbreviationSuffix))
                {
                    int suffixIndex = s.ToUpper().IndexOf(abbreviationSuffix.ToUpper());
                    if (suffixIndex > 0)
                    {
                        string numberPart = s.Substring(0, suffixIndex);
                        if (IsInt(numberPart))
                        {
                            ret = true;
                        }
                    }
                }
            }
            return ret;
        }

        public static bool IsNumericAbbreviation(string s)
        {
            return GetNumberPartOfNumericAbbreviation(s) > 0;
        }

        public static int GetNumberPartOfNumericAbbreviation(string s)
        {
            int ret = -1;

            if (containsNumericAbbreviationSuffix(s))
            {
                string numericAbbreviationSuffix = getNumericAbbreviationSuffix(s);
                int suffixIndex = s.ToUpper().IndexOf(numericAbbreviationSuffix.ToUpper());
                if (suffixIndex >= 1)
                {
                    string numberPart = s.Substring(0, suffixIndex);

                    if (isNumber(numberPart))
                    {
                        ret = Convert.ToInt32(numberPart);
                    }
                }
            }

            return ret;
        }

        public static bool containsNumericAbbreviationSuffix(String s)
        {
            bool ret = false;
            for (int i = 0; i < abbreviation_suffixes.Length; i++)
            {
                if (s.ToUpper().IndexOf(abbreviation_suffixes[i]) != -1)
                {
                    ret = true;
                }
            }
            return ret;
        }

        public static String getNumericAbbreviationSuffix(String s)
        {
            String ret = null;
            for (int i = 0; i < abbreviation_suffixes.Length; i++)
            {
                if (s.ToUpper().IndexOf(abbreviation_suffixes[i]) != -1)
                {
                    ret = abbreviation_suffixes[i];
                }
            }
            return ret;
        }

        public static String getNumericAbbreviationSuffixForNumber(int i)
        {
            String ret = null;
            String number = "" + i;
            if (number.EndsWith("1"))
            {
                ret = "ST";
            }
            else if (number.EndsWith("2") && !number.EndsWith("12"))
            {
                ret = "ND";
            }
            else if (number.EndsWith("3") && !number.EndsWith("13"))
            {
                ret = "RD";
            }
            else
            {
                ret = "TH";
            }
            return ret;
        }

        public static bool isFraction(String s)
        {
            return isFraction(s, true);
        }

        public static bool isFraction(String s, bool shouldIncludeWholeNumbers)
        {
            bool ret = false;
            if (isNumber(s) && shouldIncludeWholeNumbers)
            {
                ret = true;
            }
            else if (s.IndexOf("/") != -1)
            {
                String[] parts = s.Split('/');
                if (parts.Length == 2)
                {
                    ret = true;
                    for (int i = 0; i < parts.Length; i++)
                    {
                        if (!isNumber(parts[i].Trim()))
                        {
                            ret = false;
                        }
                    }
                }
            }
            else if (s.IndexOf('\\') != -1)
            {
                String[] parts = s.Split('\\');
                if (parts.Length == 2)
                {
                    ret = true;
                    for (int i = 0; i < parts.Length; i++)
                    {
                        if (!isNumber(parts[i].Trim()))
                        {
                            ret = false;
                        }
                    }
                }
            }

            return ret;
        }

        public static bool isDashedNumber(String s)
        {
            bool ret = false;
            if (isNumber(s))
            {
                ret = true;
            }
            else if (s.IndexOf("-") != -1)
            {
                String[] parts = s.Split('-');
                ret = true;
                for (int i = 0; i < parts.Length; i++)
                {
                    if (!isNumber(parts[i].Trim()))
                    {
                        ret = false;
                    }
                }
            }
            return ret;
        }

        public static bool isPoundNumber(String s)
        {
            bool ret = false;
            if (isNumber(s))
            {
                ret = true;
            }
            else if (s.IndexOf("#") != -1)
            {
                String[] parts = s.Split('#');
                if (parts.Length == 2)
                {
                    if (isNumber(parts[1]))
                    {
                        ret = true;
                    }
                }
            }
            return ret;
        }

        public static bool isPartlyDashedNumber(String s)
        {
            bool ret = false;
            if (isNumber(s))
            {
                ret = true;
            }
            else if (s.IndexOf("-") != -1)
            {
                String[] parts = s.Split('-');
                ret = true;
                for (int i = 0; i < parts.Length; i++)
                {
                    if (isNumber(parts[i].Trim()))
                    {
                        ret = true;
                    }
                }
            }
            return ret;
        }

        public static bool isNumber(String s)
        {
            bool ret = false;
            if (s != null)
            {
                try
                {
                    float i = 0;
                    ret = Single.TryParse(s, out i);
                }
                catch (InvalidCastException)
                {
                    ret = false;
                }
                catch (FormatException)
                {
                    ret = false;
                }
                catch (OverflowException)
                {
                    ret = false;
                }
                catch (ArithmeticException)
                {
                    ret = false;
                }
                catch (Exception e)
                {
                    string here = e.Message;
                    ret = false;
                }
            }
            return ret;
        }

        public static bool resemblesNumber(String s)
        {
            return isPartlyDashedNumber(s);
        }

        public static int absoluteValueInt(int i, int j)
        {
            int ret = 0;
            if (i < j)
            {
                ret = j - i;
            }
            else
            {
                ret = i - j;
            }
            return ret;
        }

        public static bool isAnyTypeOfNumber(String s)
        {
            return (isNumber(s) || isDashedNumber(s) || isFraction(s) || isPoundNumber(s) || resemblesNumber(s));
        }

        public static string IntegerToWords(string s)
        {
            return IntegerToWords(s, false);
        }

        public static string IntegerToWords(string s, bool useOrdinals)
        {
            string ret = "";
            if (IsInt(s))
            {
                int number = Convert.ToInt32(s);
                ret = IntegerToWords(number, useOrdinals);
            }
            else if (IsNumberAndNumericAbbreviationSuffix(s))
            {
                int number = GetNumberPartOfNumericAbbreviation(s);
                ret = IntegerToWords(number, useOrdinals);
            }
            return ret;
        }

        public static string IntegerToWords(long inputNum)
        {
            return IntegerToWords(inputNum, false);
        }

        // the following is from http://www.hotblue.com/article0001.aspx
        public static string IntegerToWords(long inputNum, bool useOrdinals)
        {
            int dig1, dig2, dig3, level = 0, lasttwo, threeDigits;

            string retval = "";
            string x = "";


            string[] ones = null;
            if (useOrdinals)
            {
                ones = onesOrdinal;
            }
            else
            {
                ones = onesNonOrdinal;
            }

            bool isNegative = false;
            if (inputNum < 0)
            {
                isNegative = true;
                inputNum *= -1;
            }

            if (inputNum == 0)
                return ("zero");

            string s = inputNum.ToString();

            while (s.Length > 0)
            {
                // Get the three rightmost characters
                x = (s.Length < 3) ? s : s.Substring(s.Length - 3, 3);

                // Separate the three digits
                threeDigits = int.Parse(x);
                lasttwo = threeDigits % 100;
                dig1 = threeDigits / 100;
                dig2 = lasttwo / 10;
                dig3 = (threeDigits % 10);

                // append a "thousand" where appropriate
                if (level > 0 && dig1 + dig2 + dig3 > 0)
                {
                    retval = thou[level] + " " + retval;
                    retval = retval.Trim();
                }

                // check that the last two digits is not a zero
                if (lasttwo > 0)
                {
                    if (lasttwo < 20) // if less than 20, use "ones" only
                    {
                        retval = ones[lasttwo] + " " + retval;
                    }
                    else // otherwise, use both "tens" and "ones" array
                    {
                        // if the ones is a zero, only use the tend
                        if (dig3 > 0)
                        {
                            retval = tensNonOrdinal[dig2] + " " + ones[dig3] + " " + retval;
                        }
                        else
                        {
                            if (useOrdinals)
                            {
                                retval = tensOrdinal[dig2] + " " + retval;
                            }
                            else
                            {
                                retval = tensNonOrdinal[dig2] + " " + retval;
                            }
                        }
                    }
                }

                // if a hundreds part is there, translate it
                if (dig1 > 0)
                {
                    retval = onesNonOrdinal[dig1] + " hundred " + retval;
                }

                s = (s.Length - 3) > 0 ? s.Substring(0, s.Length - 3) : "";
                level++;
            }

            while (retval.IndexOf("  ") > 0)
            {
                retval = retval.Replace("  ", " ");
            }

            retval = retval.Trim();

            if (isNegative)
            {
                retval = "negative " + retval;
            }

            return (retval);
        }

        public static bool IsNumberWords(string s)
        {
            bool ret = false;

            int numberValue = WordsToInteger(s);
            if (numberValue != Int32.MaxValue)
            {
                ret = true;
            }

            return ret;
        }

        public static string WordsToIntegerToOrdinalWords(string s)
        {
            string ret = "";
            if (IsNumberWords(s))
            {
                int numberValue = NumberUtils.WordsToInteger(s);
                ret = NumberUtils.IntegerToWords(numberValue, true);
            }
            return ret;
        }

        public static string WordsToNumericAbbreviation(string s)
        {
            string ret = "";
            if (IsNumberWords(s))
            {
                int numberValue = NumberUtils.WordsToInteger(s);
                string abbrv = getNumericAbbreviationSuffixForNumber(numberValue);
                ret = numberValue + abbrv;
            }


            return ret;
        }

        public static int WordsToInteger(string s)
        {
            int ret = 0;

            if (!String.IsNullOrEmpty(s))
            {
                s = s.Trim();
                s = s.ToLower();

                bool found = false;

                if (onesOrdinalHashtable.Contains(s))
                {
                    ret += (int)onesOrdinalHashtable[s];
                    found = true;
                }

                if (onesNonOrdinalHashtable.Contains(s))
                {
                    ret += (int)onesNonOrdinalHashtable[s];
                    found = true;
                }

                if (tensNonOrdinalHashTable.Contains(s))
                {
                    if (!onesNonOrdinalHashtable.Contains(s)) // ten will show up in both ones and tens and need not be duplicated
                    {
                        ret += (int)tensNonOrdinalHashTable[s] * 10;
                        found = true;
                    }
                }

                if (tensOrdinalHastable.Contains(s))
                {
                    if (!onesOrdinalHashtable.Contains(s)) // tenth will show up in both ones and tens and need not be duplicated
                    {
                        ret += (int)tensOrdinalHastable[s] * 10;
                        found = true;
                    }
                }

                if (thouHashtable.Contains(s))
                {
                    ret += (int)thouHashtable[s] * 1000;
                    found = true;
                }


                if (!found)
                {
                    // look for combos "twentysecond" 


                    // currently only implemented thus far up to ninety nine
                    // currently only handles "tens non-ordinal ones ordinal": "twenty first" and "tens non-ordinal ones non-ordinal": "twenty one"

                    bool hasTensNonOrdinal = false;
                    int tensNonOrdinalIndex = -1;
                    int tensNonOrdinalLength = -1;


                    foreach (string key in tensNonOrdinalHashTable.Keys)
                    {
                        tensNonOrdinalIndex = s.IndexOf(key);
                        if (tensNonOrdinalIndex >= 0)
                        {
                            tensNonOrdinalLength = key.Length;
                            hasTensNonOrdinal = true;
                            break;
                        }
                    }


                    // if there is a "twenty" in there continue
                    if (hasTensNonOrdinal && tensNonOrdinalIndex == 0)
                    {
                        string tensPart = s.Substring(tensNonOrdinalIndex, tensNonOrdinalLength);
                        if (tensNonOrdinalHashTable.Contains(tensPart))
                        {
                            ret += (int)tensNonOrdinalHashTable[tensPart] * 10;

                            string onesPart = s.Substring(tensNonOrdinalLength);

                            if (onesOrdinalHashtable.Contains(onesPart))
                            {
                                ret += (int)onesOrdinalHashtable[onesPart];
                                found = true;
                            }

                            if (onesNonOrdinalHashtable.Contains(onesPart))
                            {
                                ret += (int)onesNonOrdinalHashtable[onesPart];
                                found = true;
                            }
                        }
                    }

                    if (!found)
                    {
                        ret = Int32.MaxValue;
                    }
                }
            }

            return ret;
        }
    }
}
