using System.Collections;

namespace USC.GISResearchLab.Common.Synonyms.MultiTokenSynonyms
{
    public class MultiTokenSynonymSet
    {

        #region Properties

        private string[] _Key;
        public string[] Key
        {
            get { return _Key; }
            set { _Key = value; }
        }

        public ArrayList _SynonymList;
        public ArrayList SynonymList
        {
            get { return _SynonymList; }
            set { _SynonymList = value; }
        }

        #endregion

        public MultiTokenSynonymSet(string[] key)
        {
            Key = key;
            SynonymList = new ArrayList();
            SynonymList.Add(key);
        }

        public MultiTokenSynonymSet(string[][] set)
        {
            Key = set[0];
            SynonymList = new ArrayList();

            for (int i = 0; i < set.Length; i++)
            {
                SynonymList.Add(set[i]);
            }
        }

        public void Add(string[] value)
        {
            if (!Contains(value))
            {
                SynonymList.Add(value);
            }
        }

        public bool Contains(string[] value)
        {
            return SynonymList.Contains(value);
        }

        public MultiTokenSynonym Get(string[] value)
        {
            MultiTokenSynonym synonym = null;
            if (Contains(value))
            {
                string[] synonymValue = (string[])SynonymList[SynonymList.IndexOf(value)];
                synonym = new MultiTokenSynonym(Key, synonymValue);
            }
            return synonym;
        }
    }
}