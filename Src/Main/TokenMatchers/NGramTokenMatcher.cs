using System;

namespace USC.GISResearchLab.Common.Core.TokenMatchers
{
    public class NGramTokenMatcher
    {

        public static int GetStartingMatchIndex(string[] sentencetokens, string[] searchTokens)
        {
            return GetStartingMatchIndex(0, sentencetokens, searchTokens);
        }

        public static int GetStartingMatchIndex(int startPosition, string[] sentencetokens, string[] searchTokens)
        {
            return GetStartingMatchIndex(startPosition, sentencetokens, searchTokens, true);
        }

        public static int GetStartingMatchIndex(string[] sentencetokens, string[] searchTokens, bool ignoreCase)
        {
            return GetStartingMatchIndex(sentencetokens, searchTokens, ignoreCase);
        }

        public static int GetStartingMatchIndex(int startPosition, string[] sentencetokens, string[] searchTokens, bool ignoreCase)
        {
            int ret = -1;

            try
            {
                if (sentencetokens != null && searchTokens != null)
                {
                    if (searchTokens.Length <= sentencetokens.Length)
                    {
                        for (int i = startPosition; i <= sentencetokens.Length - searchTokens.Length; i++)
                        {
                            bool currentWindowMatch = true;
                            for (int j = 0; j < searchTokens.Length; j++)
                            {

                                string searchToken = searchTokens[j];
                                string sentenceToken = sentencetokens[i + j];

                                if (String.Compare(searchToken, sentenceToken, ignoreCase) != 0)
                                {
                                    currentWindowMatch = false;
                                    break;
                                }
                            }

                            if (currentWindowMatch == true)
                            {
                                ret = i;
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occurred in NGramTokenMatcher: " + ex.Message, ex);
            }

            return ret;
        }

    }
}
