using System;
using System.Collections.Generic;

namespace USC.GISResearchLab.Common.FieldMappings
{
    [Serializable]
    public class OutputFieldMappings
    {
        public bool Enabled { get; set; }
        public List<FieldMapping> FieldMappings { get; set; }


        public OutputFieldMappings(List<FieldMapping> fieldMappings)
        {
            FieldMappings = fieldMappings;
        }

        public FieldMapping GetFieldMapping(string name)
        {
            FieldMapping ret = null;
            if (!String.IsNullOrEmpty(name))
            {
                name = name.Trim();

                if (FieldMappings != null)
                {
                    foreach (FieldMapping fieldMapping in FieldMappings)
                    {
                        if (String.Compare(fieldMapping.Name, name, true) == 0)
                        {
                            ret = fieldMapping;
                            break;
                        }
                    }
                }
            }
            return ret;
        }
    }
}
