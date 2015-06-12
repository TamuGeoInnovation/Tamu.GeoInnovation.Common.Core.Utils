using System;

namespace USC.GISResearchLab.Common.Core.Utils.Arrays
{
    public class ArrayUtils
    {
        public static object[] Add(object[] array, object o)
        {
            if (array == null)
            {
                array = new object[0];
            }

            object[] newList = new object[array.Length + 1];
            for (int j = 0; j < array.Length; j++)
            {
                newList[j] = array[j];
            }

            newList[newList.Length - 1] = o;

            return newList;
        }

        public static int[] Add(int[] array, int o)
        {
            if (array == null)
            {
                array = new int[0];
            }

            int[] newList = new int[array.Length + 1];
            for (int j = 0; j < array.Length; j++)
            {
                newList[j] = array[j];
            }

            newList[newList.Length - 1] = o;

            return newList;
        }

        public static string[] Add(string[] array, string o)
        {
            if (array == null)
            {
                array = new string[0];
            }

            string[] newList = new string[array.Length + 1];
            for (int j = 0; j < array.Length; j++)
            {
                newList[j] = array[j];
            }

            newList[newList.Length - 1] = o;

            return newList;
        }


        public static bool Contains(string[] array, string s)
        {
            return Contains(array, s, false);
        }

        public static bool Contains(string[] array, string s, bool ignoreCase)
        {
            bool ret = false;
            for (int i = 0; i < array.Length; i++)
            {
                if (String.Compare(array[i], s, ignoreCase) == 0)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        public static bool ContainsDuplicate<T>(T[] array)
        {
            bool ret = false;
            int i, j;

            for (i = 0; i < array.Length; i++)
            {
                for (j = i + 1; j < array.Length; j++)
                {
                    if (array[i].Equals(array[j]))
                    {
                        ret = true;
                        break;
                    }
                }
                if (ret) break;
            }

            return ret;
        }
    }
}
