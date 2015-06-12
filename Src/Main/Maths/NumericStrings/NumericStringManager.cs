using System;
using System.Collections;
using USC.GISResearchLab.Common.Utils.Numbers;

namespace USC.GISResearchLab.Common.Core.Maths.NumericStrings
{
    public class NumericStringManager
    {

        #region Properties

        public Hashtable StringToNumberCache { get; set; }
        public Hashtable IntegerToWordsCache { get; set; }
        public Hashtable WordsToIntegerCache { get; set; }
        public Hashtable NumericAbbreviationToIntegerCache { get; set; }
        public Hashtable IsNumericAbbreviationCache { get; set; }


        public String[] abbreviation_suffixes = { "ST", "ND", "RD", "TH" };

        public Hashtable onesNonOrdinalHashtable;
        public String[] onesNonOrdinal ={
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

        public Hashtable onesOrdinalHashtable;
        public String[] onesOrdinal ={
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

        public Hashtable tensNonOrdinalHashTable;
        public String[] tensNonOrdinal ={
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

        public Hashtable tensOrdinalHastable;
        public String[] tensOrdinal ={
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

        public Hashtable thouHashtable;
        public String[] thou ={
                            "",
                            "thousand",
                            "million",
                            "billion",
                            "trillion",
                            "quadrillion",
                            "quintillion"
                          };



        #endregion

        public NumericStringManager()
        {
            StringToNumberCache = new Hashtable();
            IntegerToWordsCache = new Hashtable();
            WordsToIntegerCache = new Hashtable();
            NumericAbbreviationToIntegerCache = new Hashtable();
            IsNumericAbbreviationCache = new Hashtable();


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

        public bool IsSomeFormOfNumericValue(string a)
        {
            bool ret = false;

            try
            {
                if (!String.IsNullOrEmpty(a))
                {

                    a = a.ToLower();
                    a = a.Trim();

                    if (IsNumericAbbreviation(a) || IsNumberWords(a) || IsInt(a))
                    {
                        ret = true;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Exception in IsSomeFormOfNumericValue: " + e.Message);
            }
            return ret;
        }

        public bool AreBothSomeFormOfNumericValues(string a, string b)
        {
            bool ret = false;

            try
            {
                if (!String.IsNullOrEmpty(a) && !String.IsNullOrEmpty(b))
                {

                    a = a.ToLower();
                    a = a.Trim();
                    b = b.ToLower();
                    b = b.Trim();

                    if ((IsNumericAbbreviation(a) || IsNumberWords(a) || IsInt(a)) && (IsNumericAbbreviation(b) || IsNumberWords(b) || IsInt(b)))
                    {
                        ret = true;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Exception in AreBothSomeFormOfNumericValues: " + e.Message);
            }
            return ret;
        }

        public bool AreEquivalentNumericValues(string a, string b)
        {
            bool ret = false;

            try
            {

                // if both of them are some type of number, compare the numeric values
                if ((IsNumericAbbreviation(a) || IsNumberWords(a) || IsInt(a)) && (IsNumericAbbreviation(b) || IsNumberWords(b) || IsInt(b)))
                {
                    int aNumber = -1;
                    int bNumber = -1;

                    if (StringToNumberCache.Contains(a.ToLower()))
                    {
                        aNumber = (int)StringToNumberCache[a.ToLower()];
                    }
                    else
                    {
                        if (IsNumericAbbreviation(a))
                        {
                            aNumber = GetNumberPartOfNumericAbbreviation(a);
                        }
                        else if (IsNumberWords(a))
                        {
                            aNumber = WordsToInteger(a);
                        }
                        else if (IsInt(a))
                        {
                            aNumber = Convert.ToInt32(a);
                        }

                        StringToNumberCache.Add(a.ToLower(), aNumber);
                    }

                    if (StringToNumberCache.Contains(b.ToLower()))
                    {
                        bNumber = (int)StringToNumberCache[b.ToLower()];
                    }
                    else
                    {
                        if (IsNumericAbbreviation(b))
                        {
                            bNumber = GetNumberPartOfNumericAbbreviation(b);
                        }
                        else if (IsNumberWords(b))
                        {
                            bNumber = WordsToInteger(b);
                        }
                        else if (IsInt(b))
                        {
                            bNumber = Convert.ToInt32(b);
                        }
                        StringToNumberCache.Add(b.ToLower(), bNumber);
                    }


                    if (aNumber > 0 && bNumber > 0)
                    {
                        if (aNumber == bNumber)
                        {
                            ret = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Exception in AreEquivalentNumericValues: " + e.Message);
            }

            return ret;
        }

        public bool IsNumberAndNumericAbbreviationSuffix(string s)
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

        public bool IsNumericAbbreviation(string s)
        {
            bool ret = false;

            if (IsNumericAbbreviationCache.Contains(s))
            {
                ret = (bool)IsNumericAbbreviationCache[s];
            }
            else
            {
                ret = GetNumberPartOfNumericAbbreviation(s) > 0;
                IsNumericAbbreviationCache.Add(s, ret);
            }
            
            return ret;
        }

        public int GetNumberPartOfNumericAbbreviation(string s)
        {
            int ret = -1;

            if (NumericAbbreviationToIntegerCache.Contains(s))
            {
                ret = (int)NumericAbbreviationToIntegerCache[s];
            }
            else
            {
                if (containsNumericAbbreviationSuffix(s))
                {
                    string numericAbbreviationSuffix = getNumericAbbreviationSuffix(s);
                    int suffixIndex = s.ToUpper().IndexOf(numericAbbreviationSuffix.ToUpper());
                    if (suffixIndex >= 1)
                    {
                        string numberPart = s.Substring(0, suffixIndex);

                        if (IsInt(numberPart))
                        {
                            ret = Convert.ToInt32(numberPart);
                        }
                    }
                }

                NumericAbbreviationToIntegerCache.Add(s, ret);
            }

            return ret;
        }

        public bool containsNumericAbbreviationSuffix(String s)
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

        public String getNumericAbbreviationSuffix(String s)
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

        public String getNumericAbbreviationSuffixForNumber(int i)
        {
            String ret = null;
            String number = "" + i;
            if (number.EndsWith("1"))
            {
                ret = "ST";
            }
            else if (number.EndsWith("2"))
            {
                ret = "ND";
            }
            else if (number.EndsWith("3"))
            {
                ret = "RD";
            }
            else
            {
                ret = "TH";
            }
            return ret;
        }

        public string IntegerToWords(string s)
        {
            return IntegerToWords(s, false);
        }

        public string IntegerToWords(string s, bool useOrdinals)
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

        public string IntegerToWords(long inputNum)
        {
            return IntegerToWords(inputNum, false);
        }

        // the following is from http://www.hotblue.com/article0001.aspx
        public string IntegerToWords(long inputNum, bool useOrdinals)
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

        public bool IsNumberWords(string s)
        {
            bool ret = false;

            int numberValue = WordsToInteger(s);
            if (numberValue != Int32.MaxValue)
            {
                ret = true;
            }

            return ret;
        }

        public string WordsToIntegerToOrdinalWords(string s)
        {
            string ret = "";
            if (IsNumberWords(s))
            {
                int numberValue = WordsToInteger(s);
                ret = IntegerToWords(numberValue, true);
            }
            return ret;
        }

        public string WordsToNumericAbbreviation(string s)
        {
            string ret = "";
            if (IsNumberWords(s))
            {
                int numberValue = WordsToInteger(s);
                string abbrv = getNumericAbbreviationSuffixForNumber(numberValue);
                ret = numberValue + abbrv;
            }


            return ret;
        }

        public int WordsToInteger(string s)
        {
            int ret = 0;

            if (!String.IsNullOrEmpty(s))
            {
                s = s.Trim();
                s = s.ToLower();

                if (WordsToIntegerCache.Contains(s))
                {
                    ret = (int)WordsToIntegerCache[s];
                }
                else
                {

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

                    WordsToIntegerCache.Add(s, ret);
                }
            }

            return ret;
        }


        public bool IsInt(string s)
        {
            return NumberUtils.IsInt(s);
        }
    }
}
