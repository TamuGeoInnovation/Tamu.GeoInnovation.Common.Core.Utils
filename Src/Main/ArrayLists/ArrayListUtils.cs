using System;
using System.Collections;

namespace USC.GISResearchLab.Common.Utils.ArrayLists
{
	/// <summary>
	/// Summary description for ArrayListUtils.
	/// </summary>
	public class ArrayListUtils
	{
		public ArrayListUtils()
		{
		}

        public static ArrayList intersectLists(ArrayList list1, ArrayList list2)
        {

            ArrayList ret = new ArrayList();

            for (int i = 0; i < list1.Count; i++)
            {
                int id = (int)list1[i];

                if (list2.Contains(id))
                {
                    ret.Add(id);
                }
            }

            return ret;

        }

        public static ArrayList unionLists(ArrayList list1, ArrayList list2)
        {

            ArrayList ret = new ArrayList();

            for (int i = 0; i < list1.Count; i++)
            {
                int id = (int)list1[i];
                if (!ret.Contains(id))
                {
                    ret.Add(id);
                }
            }

            for (int i = 0; i < list2.Count; i++)
            {
                int id = (int)list2[i];
                if (!ret.Contains(id))
                {
                    ret.Add(id);
                }
            }

            return ret;

        }

		public static bool isEmpty(ArrayList a)
		{
			bool ret = true;
			if (a != null)
			{
				if (a.Count > 0)
				{
					ret = false;
				}
			}
			return ret;
		}

        public static string[] AsStringArray(ArrayList a)
        {
            string[] ret = null;
            if (a != null)
            {
                ret = new string[a.Count];
                for (int i = 0; i < ret.Length; i++)
                {
                    ret[i] = (string)a[i];
                }
            }
            return ret;
        }

		public static bool ContainsString(ArrayList a, string s)
		{
			bool ret = false;
			if (!isEmpty(a))
			{
                for (int i = 0; i < a.Count; i++)
                {
                    string curr = (string)a[i];
                    if (String.Compare(curr, s, true) == 0)
                    {
                        ret = true;
                        break;
                    }
                }
			}
			return ret;
		}
	}
}
