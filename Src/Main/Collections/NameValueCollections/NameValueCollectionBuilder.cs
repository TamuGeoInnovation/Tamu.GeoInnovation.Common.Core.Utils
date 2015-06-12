using System;
using System.Collections.Specialized;

namespace USC.GISResearchLab.Common.Core.Collections.NameValueCollections
{
    public class NameValueCollectionBuilder
    {
        public static NameValueCollection BuildFromString(string collectionString, char pairSeparator, char nameValueSeparators)
        {
            return BuildFromString(collectionString, new char[] { pairSeparator }, new char[] { nameValueSeparators });
        }

        public static NameValueCollection BuildFromString(string collectionString, char[] pairSeparators, char[] nameValueSeparators)
        {
            return BuildFromString(collectionString, pairSeparators, nameValueSeparators, null, null);
        }

        public static NameValueCollection BuildFromString(string collectionString, char pairSeparator, char nameValueSeparators, string[] excludeChars, string excludeTrailingChar)
        {
            return BuildFromString(collectionString, new char[] { pairSeparator }, new char[] { nameValueSeparators }, excludeChars, excludeTrailingChar);
        }

        public static NameValueCollection BuildFromString(string collectionString, char[] pairSeparators, char[] nameValueSeparators, string[] excludeInternalChars, string excludeTrailingChar)
        {
            NameValueCollection ret = new NameValueCollection();
            string[] parts = collectionString.Split(pairSeparators);

            foreach (string pair in parts)
            {
                if (!String.IsNullOrEmpty(pair))
                {
                    string current = pair.Trim();

                    if (!String.IsNullOrEmpty(excludeTrailingChar))
                    {
                        if (current.EndsWith(excludeTrailingChar))
                        {
                            current = current.Substring(0, current.Length - 1);
                            current = current.Trim();
                        }
                    }

                    if (!String.IsNullOrEmpty(current))
                    {
                        string[] values = pair.Split(nameValueSeparators);

                        string name = values[0];
                        string value = values[1];

                        if (excludeInternalChars != null)
                        {
                            foreach (string excludeChar in excludeInternalChars)
                            {
                                if (!String.IsNullOrEmpty(excludeChar))
                                {
                                    name = name.Replace(excludeChar, "");
                                    value = value.Replace(excludeChar, "");
                                }
                            }
                        }

                        name = name.Trim();
                        value = value.Trim();


                        if (!String.IsNullOrEmpty(excludeTrailingChar))
                        {
                            if (name.EndsWith(excludeTrailingChar))
                            {
                                name = name.Substring(0, name.Length - 1);
                            }

                            if (value.EndsWith(excludeTrailingChar))
                            {
                                value = value.Substring(0, value.Length - 1);
                            }

                            name = name.Trim();
                            value = value.Trim();
                        }

                        ret[name] = value;
                    }
                }
            }

            return ret;
        }
    }
}
