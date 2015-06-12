using System.Text;

namespace USC.GISResearchLab.Common.Synonyms
{
    public class Synonym
    {
        #region Properties
        private string _PreferredString;
        public string PreferredString
        {
            get { return _PreferredString; }
            set { _PreferredString = value; }
        }

        private string _AlternateString;
        public string AlternateString
        {
            get { return _AlternateString; }
            set { _AlternateString = value; }
        }

        public Synonym(string preferredString, string alternateString)
        {
            PreferredString = preferredString;
            AlternateString = alternateString;
        }
        #endregion

        public bool termsAreEqual()
        {
            return PreferredString.Equals(AlternateString);
        }

        public bool isPreferred()
        {
            return termsAreEqual();
        }

        public string toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            sb.Append(PreferredString);
            if (!isPreferred())
            {
                sb.Append(", ");
                sb.Append(AlternateString);
            }
            sb.Append("]");
            return sb.ToString();
        }
    }
}
