namespace USC.GISResearchLab.Common.Utils.Strings.Patterns
{
    public class PatternUtils
    {

        public static string SubstitutionExpressionStart = "{";
        public static string SubstitutionExpressionEnd = "}";

        public static string[] GetSubstitutionExpressions(string s)
        {
            return GetSubstitutionExpressions(s, SubstitutionExpressionStart, SubstitutionExpressionEnd);
        }

        public static string[] GetSubstitutionExpressions(string s, string substitutionExpressionStart, string substitutionExpressionEnd)
        {
            string[] ret = null;
            if ((s.IndexOf(substitutionExpressionStart) != -1) && (s.IndexOf(substitutionExpressionEnd) != -1))
            {
                while ((s.IndexOf(substitutionExpressionStart) != -1) && (s.IndexOf(substitutionExpressionEnd) != -1))
                {
                    int start = s.IndexOf(substitutionExpressionStart) + 1;
                    int end = s.IndexOf(substitutionExpressionEnd);

                    if (start < end)
                    {

                        string expression = s.Substring(start, end - start);

                        if (ret == null)
                        {
                            ret = new string[0];
                        }

                        string[] temp = new string[ret.Length + 1];
                        ret.CopyTo(temp, 0);
                        temp[temp.Length - 1] = expression;
                        ret = temp;

                    }

                    s = s.Substring(end + 1);
                }
            }
            return ret;
        }
    }
}
