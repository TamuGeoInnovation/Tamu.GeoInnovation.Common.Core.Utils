using System;
using System.Text;

namespace USC.GISResearchLab.Common.Synonyms.MultiTokenSynonyms
{
    public class MultiTokenSynonym
    {
        #region Properties
        
        private string[] _PreferredValue;
        public string[] PreferredValue
        {
            get { return _PreferredValue; }
            set { _PreferredValue = value; }
        }

        private string[] _AlternateValue;
        public string[] AlternateValue
        {
            get { return _AlternateValue; }
            set { _AlternateValue = value; }
        }

        #endregion

        public MultiTokenSynonym(string[] preferredValue, string[] alternateValue)
        {
            PreferredValue = preferredValue;
            AlternateValue = alternateValue;
        }

        public bool TermsAreEqual()
        {
            bool ret = true;
            if (PreferredValue != null && AlternateValue != null)
            {
                if (PreferredValue.Length == AlternateValue.Length)
                {
                    for (int i = 0; i < PreferredValue.Length; i++)
                    {
                        string preferredValue = PreferredValue[i];
                        string alternateValue = AlternateValue[i];

                        if (String.Compare(preferredValue, alternateValue, true) != 0)
                        {
                            ret = false;
                            break;
                        }
                    }
                }
                else
                {
                    ret = false;
                }
            }
            else
            {
                ret = false;
            }
            return ret;
        }

        public bool IsPreferred()
        {
            return TermsAreEqual();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append(PreferredValue.ToString());
            if (!IsPreferred())
            {
                sb.Append(", ");
                sb.Append(AlternateValue.ToString());
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}
