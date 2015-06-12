using System;
using System.Collections;
using System.Data;
using USC.GISResearchLab.Common.Attributes;

namespace USC.GISResearchLab.Common.Utils.Attributes
{
    public class AttributeHelperUtils
    {
        public static ArrayList FillValues(ArrayList attributeList, DataRow dataRow)
        {

            ArrayList ret = null;

            try
            {

                for (int i = 0; i < attributeList.Count; i++)
                {
                    AttributeHelper attributeHelper = (AttributeHelper)attributeList[i];

                    string name = attributeHelper.OriginalColumnName;
                    int index = dataRow.Table.Columns[name].Ordinal;

                    if (index >= 0)
                    {
                        object value = dataRow.ItemArray[index];
                        if (value != null && !value.ToString().Equals(""))
                        {
                            attributeHelper.Value = value;
                        }

                        if (ret == null)
                        {
                            ret = new ArrayList();
                        }
                        ret.Add(attributeHelper);
                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception("Error occurred filling atttribute list values", e);
            }

            return ret;
        }
    }
}
