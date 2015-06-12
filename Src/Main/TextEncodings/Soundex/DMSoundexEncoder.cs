using System;
using System.Collections.Generic;
using System.Text;

namespace USC.GISResearchLab.Common.Core.TextEncodings.Soundex
{
    public class DMSoundexEncoder
    {
        List<char> Vowels_List = null;
        List<char> BeginningChars = null;

        public DMSoundexEncoder()
        {
            Vowels_List = new List<char>(5);
            Vowels_List.Add('A');
            Vowels_List.Add('E');
            Vowels_List.Add('I');
            Vowels_List.Add('O');
            Vowels_List.Add('U');

            BeginningChars = new List<char>(5);
            BeginningChars.Add('A');
            BeginningChars.Add('E');
            BeginningChars.Add('I');
            BeginningChars.Add('O');
            BeginningChars.Add('U');

        }
        public String compute(string word)
        {
            
            return compute(word, 6);
        }
        public string compute(string s, int length)
        {



            string[,] tokens = {{ "SCHTSCH", "2", "4", "4" },
            { "SCHTSH", "2", "4", "4" },
            { "SCHTCH", "2", "4", "4" },
            { "ZHDZH", "2", "4", "4" },
            { "STSCH", "2", "4", "4" },
            { "SHTCH", "2", "4", "4" },
            { "TTSCH", "4", "4", "4" },
            { "ZSCH", "4", "4", "4" },
            { "ZDZH", "2", "4", "4" },
            { "TTSZ", "4", "4", "4" },
            { "TTCH", "4", "4", "4" },
            { "TSCH", "4", "4", "4" },
            { "SZCZ", "2", "4", "4" },
            { "SZCS", "2", "4", "4" },
            { "STRZ", "2", "4", "4" },
            { "STRS", "2", "4", "4" },
            { "STSH", "2", "4", "4" },
            { "STCH", "2", "4", "4" },
            { "SCHT", "2", "43", "43" },
            { "SCHD", "2", "43", "43" },
            { "SHCH", "2", "4", "4" },
            { "ZSH", "4", "4", "4" },
            { "ZHD", "2", "43", "43" },
            { "ZDZ", "2", "4", "4" },
            { "TTZ", "4", "4", "4" },
            { "TZS", "4", "4", "4" },
            { "TSZ", "4", "4", "4" },
            { "TTS", "4", "4", "4" },
            { "TSH", "4", "4", "4" },
            { "TRS", "4", "4", "4" },
            { "TRZ", "4", "4", "4" },
            { "TCH", "4", "4", "4" },
            { "SZT", "2", "43", "43" },
            { "SHD", "2", "43", "43" },
            { "SZD", "2", "43", "43" },
            { "SCH", "4", "4", "4" },
            { "SHT", "2", "43", "43"},
            { "DZH", "4", "4", "4" },
            { "DZS", "4", "4", "4" },
            { "DSH", "4", "4", "4" },
            { "DSZ", "4", "4", "4" },
            { "DRZ", "4", "4", "4" },
            { "DRS", "4", "4", "4" },
            { "CSZ", "4", "4", "4" },
            { "CZS", "4", "4", "4" },
            { "CHS", "5", "54", "54" },
            { "ZS", "4", "4", "4" },
            { "ZH", "4", "4", "4" },
            { "ZD", "2", "43", "43" },
            { "UE", "0", "", "" },
            { "UJ", "0", "1", "" },
            { "UY", "0", "1", "" },
            { "UI", "0", "1", "" },
            { "TZ", "4", "4", "4" },
            { "TC", "4", "4", "4" },
            { "TS", "4", "4", "4" },
            { "TH", "3", "3", "3" },
            { "SZ", "4", "4", "4" },
            { "ST", "2", "43", "43" },
            { "SH", "4", "4", "4" },
            { "RZ", "4", "4", "4" },
            { "RS", "4", "4", "4" },
            { "PF", "7", "7", "7" },
            { "PH", "7", "7", "7" },
            { "OJ", "0", "1", "" },
            { "OY", "0", "1", "" },
            { "OI", "0", "1", "" },
            { "NM", "", "66", "66" },
            { "MN", "", "66", "66" },
            { "KH", "5", "5", "5" },
            { "KS", "5", "54", "54" },
            { "FB", "7", "7", "7" },
            { "FB", "7", "7", "7" },
            { "EU", "1", "1", "" },
            { "EJ", "0", "1", "" },
            { "EY", "0", "1", "" },
            { "EI", "0", "1", "" },
            { "DT", "3", "3", "3" },
            { "DZ", "4", "4", "4" },
            { "DS", "4", "4", "4" },
            { "CS", "4", "4", "4" },
            { "CZ", "4", "4", "4" },
            { "CK", "5", "5", "5" },
            { "CH", "5", "5", "5" },
            { "AU", "0", "7", "" },
            { "AJ", "0", "1", "" },
            { "AY", "0", "1", "" },
            { "AI", "0", "1", "" },
            { "IU", "1", "", "" },
            { "I0", "1", "", "" },
            { "IE", "1", "", "" },
            { "IA", "1", "", "" },
            { "Z", "4", "4", "4" },
            { "Y", "1", "", "" },
            { "X", "5", "54", "54" },
            { "W", "7", "7", "7" },
            { "V", "7", "7", "7" },
            { "U", "0", "", "" },
            { "T", "3", "3", "3" },
            { "S", "4", "4", "4" },
            { "R", "9", "9", "9" },
            { "Q", "5", "5", "5" },
            { "P", "7", "7", "7" },
            { "O", "0", "", "" },
            { "N", "6", "6", "6" },
            { "M", "6", "6", "6" },
            { "L", "8", "8", "8" },
            { "K", "5", "5", "5" },
            { "J", "1", "1", "1" },
            { "I", "0", "", "" },
            { "H", "5", "5", "" },
            { "G", "5", "5", "5" },
            { "F", "7", "7", "7" },
            { "E", "0", "", "" },
            { "D", "3", "3", "3" },
            { "C", "4", "4", "4" },
            { "B", "7", "7", "7" },
            { "A", "0", "", "" }};

            s = s.ToUpper();
            s = s.Replace(" ", "");
            s = s.Replace("'", "");
            s = s.Replace("-", "");
            string value = "";

            if (String.IsNullOrEmpty(s))
            {
                value = "000000";
                return value;
            }
            else
            {

                StringBuilder tempbuffer = new StringBuilder();
                StringBuilder tempbuffer1 = new StringBuilder();
                StringBuilder final = new StringBuilder();
                tempbuffer1.Append(s);


                char t = tempbuffer1[0];
                if (BeginningChars.Contains(t))
                {
                    t = '0';
                    tempbuffer1.Replace(tempbuffer1[0], t, 0, 1);
                }
                s = tempbuffer1.ToString();

                // normal cases of find and replace
                int rowCount = tokens.GetLength(0);
                for (int i = 0; i < rowCount; i++)
                {
                    string checkString = tokens[i, 0];



                    if (s.Contains(checkString))
                    {

                        bool isStart = false;
                        bool isVowelAfter = false;

                        int index = s.IndexOf(checkString);
                        isStart = (index == 0);


                        int nextCharLoc = index + checkString.Length;
                        if (s.Length > nextCharLoc)
                        {

                            char nextChar = s[nextCharLoc];
                            if (Vowels_List.Contains(nextChar))
                            {
                                isVowelAfter = true;
                            }
                        }

                        if (isStart)
                        {
                            s = s.Replace(checkString, tokens[i, 1]);

                        }
                        if (isVowelAfter)
                        {
                            s = s.Replace(checkString, tokens[i, 2]);
                        }
                        if (!isStart && !isVowelAfter)
                        {
                            s = s.Replace(checkString, tokens[i, 3]);
                        }
                    }
                }
                int size = s.Length;
                tempbuffer.Append(s);
                if (size < length)
                {
                    tempbuffer.Append('0', length - size);
                    value = tempbuffer.ToString();
                }
                if (size >= length)
                {
                    for (int k = 0; k < length; k++)
                    {
                        final.Append(tempbuffer[k]);
                    }
                    value = final.ToString();
                }

                return value;
            }
        }
    }
}
