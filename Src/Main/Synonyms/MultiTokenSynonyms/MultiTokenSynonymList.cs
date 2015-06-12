using System;
using System.Collections;

namespace USC.GISResearchLab.Common.Synonyms.MultiTokenSynonyms
{
    public class MultiTokenSynonymList : CollectionBase
    {
        #region Properties
        private string[][] _Synonyms;
        public string[][] Synonyms
        {
            get { return _Synonyms; }
            set { _Synonyms = value; }
        }

        #endregion

        public MultiTokenSynonymList()
        {
            Synonyms = new string[0][];
        }

        public MultiTokenSynonymList(ArrayList synonyms)
        {
            if (synonyms != null)
            {
                Synonyms = new string[synonyms.Count][];
                for (int i = 0; i < synonyms.Count; i++)
                {
                    Synonyms[i] = (string[])synonyms[i];
                }
            }
        }

        public string[] this[int index]
        {
            get
            {
                return ((string[])List[index]);
            }
            set
            {
                List[index] = value;
            }
        }

        public int Add(string[] value)
        {
            int ret = -1;
            if (List.IndexOf(value) != -1)
            {
                ret = List.Add(value);
            }
            return ret;
        }

        public int IndexOf(string[] value)
        {
            return (List.IndexOf(value));
        }

        public void Insert(int index, string[] value)
        {
            List.Insert(index, value);
        }

        public void Remove(string value)
        {
            List.Remove(value);
        }

        public bool Contains(string[] value)
        {
            return (List.Contains(value));
        }

        protected override void OnInsert(int index, Object value)
        {
            // Insert additional code to be run only when inserting values.
        }

        protected override void OnRemove(int index, Object value)
        {
            // Insert additional code to be run only when removing values.
        }

        protected override void OnSet(int index, Object oldValue, Object newValue)
        {
            // Insert additional code to be run only when setting values.
        }

        protected override void OnValidate(Object value)
        {
            if (value.GetType() != typeof(string[]))
            {
                throw new ArgumentException("value must be of type string array.", "value");
            }
        }
    }
}