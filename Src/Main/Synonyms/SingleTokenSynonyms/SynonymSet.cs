using System;
using System.Collections.Generic;

namespace USC.GISResearchLab.Common.Synonyms
{
    public class SynonymSet
    {

        #region Properties

        public string Key { get; set; }

        public List<String> SynonymValues { get; set; }

        #endregion

        public SynonymSet(String key)
        {
            Key = key.ToUpper();
            SynonymValues = new List<String>();
            SynonymValues.Add(key.ToUpper());
        }

        public SynonymSet(String[] set)
        {
            Key = set[0].ToUpper();
            SynonymValues = new List<String>();

            for (int i = 0; i < set.Length; i++)
            {
                SynonymValues.Add(set[i].ToUpper());
            }
        }

        public void Add(String value)
        {
            if (!Contains(value.ToUpper()))
            {
                SynonymValues.Add(value.ToUpper());
            }
        }

        public bool Contains(String value)
        {
            return SynonymValues.Contains(value.ToUpper());
        }

        public Synonym Get(String value)
        {
            Synonym synonym = null;
            if (Contains(value.ToUpper()))
            {
                String synonymValue = (String)SynonymValues[SynonymValues.IndexOf(value.ToUpper())];
                synonym = new Synonym(Key, synonymValue.ToUpper());
            }
            return synonym;
        }
    }
}