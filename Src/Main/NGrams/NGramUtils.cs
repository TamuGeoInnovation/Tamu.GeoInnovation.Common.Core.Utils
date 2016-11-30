using System;
using System.Collections;
using System.Linq;
using System.Data;
using System.Text;


namespace USC.GISResearchLab.Common.Utils.NGrams
{
    /// <summary>
    /// Summary description for StringUtils.
    /// </summary>
    public class NGramUtils
    {

        public NGramUtils()
        {
        }

        public static DataTable ComputeGramsFromDataTable(int gramCount, DataTable dataTable, string columnName)
        {
            DataTable ret = new DataTable();

            if (gramCount == 1)
            {
                ret = ComputeUniGramsFromDataTable(dataTable, columnName);
            }
            else if (gramCount == 2)
            {
                ret = ComputeBiGramsFromDataTable(dataTable, columnName);
            }
            else if (gramCount == 3)
            {
                ret = ComputeTriGramsFromDataTable(dataTable, columnName);
            }
            else
            {
                throw new Exception("gramCount " + gramCount + " not yet implemented");
            }

            return ret;
        }

        public static DataTable ComputeUniGramsFromDataTable(DataTable dataTable, string columnName)
        {
            DataTable ret = new DataTable();
            ret.Columns.Add("Word");
            ret.Columns.Add("WordCount");

            Hashtable hashTable = new Hashtable();

            try
            {


                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string words = Convert.ToString(row[columnName]);
                        if (!String.IsNullOrEmpty(words))
                        {
                            string[] parts = words.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            for (int i = 0; i < parts.Length; i++)
                            {
                                string word1 = parts[i];
                                if (!String.IsNullOrEmpty(word1))
                                {
                                    word1 = word1.Trim();
                                    if (!String.IsNullOrEmpty(word1))
                                    {
                                        word1 = word1.ToLower();

                                        if (hashTable.ContainsKey(word1))
                                        {
                                            hashTable[word1] = (int)hashTable[word1] + 1;
                                        }
                                        else
                                        {
                                            hashTable.Add(word1, 1);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                var list = hashTable.Cast<DictionaryEntry>().OrderByDescending(entry => entry.Value).ToList();

                foreach (DictionaryEntry item in list)
                {
                    ret.Rows.Add(item.Key, item.Value);
                }

            }
            catch (Exception ex)
            {
                string msg = "Error getting ComputeUniGramsFromDataTable: " + ex.Message;
                throw new Exception(msg, ex);
            }


            return ret;
        }


        public static DataTable ComputeBiGramsFromDataTable(DataTable dataTable, string columnName)
        {
            DataTable ret = new DataTable();
            ret.Columns.Add("Word");
            ret.Columns.Add("WordCount");

            Hashtable hashTable = new Hashtable();

            try
            {
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string words = Convert.ToString(row[columnName]);
                        if (!String.IsNullOrEmpty(words))
                        {
                            string[] parts = words.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            for (int i = 0; i < parts.Length - 1; i++)
                            {
                                string word1 = parts[i];
                                if (!String.IsNullOrEmpty(word1))
                                {
                                    word1 = word1.Trim();
                                    if (!String.IsNullOrEmpty(word1))
                                    {
                                        word1 = word1.ToLower();

                                        string word2 = parts[i + 1];
                                        if (!String.IsNullOrEmpty(word2))
                                        {
                                            word2 = word2.Trim();
                                            if (!String.IsNullOrEmpty(word2))
                                            {
                                                word2 = word2.ToLower();

                                                StringBuilder sb = new StringBuilder();
                                                sb.Append(word1);
                                                sb.Append(" ");
                                                sb.Append(word2);
                                                string combined = sb.ToString();

                                                if (hashTable.ContainsKey(combined))
                                                {
                                                    hashTable[combined] = (int)hashTable[combined] + 1;
                                                }
                                                else
                                                {
                                                    hashTable.Add(combined, 1);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                var list = hashTable.Cast<DictionaryEntry>().OrderByDescending(entry => entry.Value).ToList();

                foreach (DictionaryEntry item in list)
                {
                    ret.Rows.Add(item.Key, item.Value);
                }

            }
            catch (Exception ex)
            {
                string msg = "Error getting ComputeBiGramsFromDataTable: " + ex.Message;
                throw new Exception(msg, ex);
            }


            return ret;
        }


        public static DataTable ComputeTriGramsFromDataTable(DataTable dataTable, string columnName)
        {
            DataTable ret = new DataTable();
            ret.Columns.Add("Word");
            ret.Columns.Add("WordCount");

            Hashtable hashTable = new Hashtable();

            try
            {
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string words = Convert.ToString(row[columnName]);
                        if (!String.IsNullOrEmpty(words))
                        {
                            string[] parts = words.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            for (int i = 0; i < parts.Length - 2; i++)
                            {
                                string word1 = parts[i];
                                if (!String.IsNullOrEmpty(word1))
                                {
                                    word1 = word1.Trim();
                                    if (!String.IsNullOrEmpty(word1))
                                    {
                                        word1 = word1.ToLower();

                                        string word2 = parts[i + 1];
                                        if (!String.IsNullOrEmpty(word2))
                                        {
                                            word2 = word2.Trim();
                                            if (!String.IsNullOrEmpty(word2))
                                            {
                                                word2 = word2.ToLower();

                                                string word3 = parts[i + 2];
                                                if (!String.IsNullOrEmpty(word3))
                                                {
                                                    word3 = word3.Trim();
                                                    if (!String.IsNullOrEmpty(word3))
                                                    {
                                                        word3 = word3.ToLower();

                                                        StringBuilder sb = new StringBuilder();
                                                        sb.Append(word1);
                                                        sb.Append(" ");
                                                        sb.Append(word2);
                                                        sb.Append(" ");
                                                        sb.Append(word3);
                                                        string combined = sb.ToString();

                                                        if (hashTable.ContainsKey(combined))
                                                        {
                                                            hashTable[combined] = (int)hashTable[combined] + 1;
                                                        }
                                                        else
                                                        {
                                                            hashTable.Add(combined, 1);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                var list = hashTable.Cast<DictionaryEntry>().OrderByDescending(entry => entry.Value).ToList();

                foreach (DictionaryEntry item in list)
                {
                    ret.Rows.Add(item.Key, item.Value);
                }

            }
            catch (Exception ex)
            {
                string msg = "Error getting ComputeTriGramsFromDataTable: " + ex.Message;
                throw new Exception(msg, ex);
            }


            return ret;
        }
    }
}


