using System;

namespace USC.GISResearchLab.Common.FieldMappings
{
    [Serializable]
    public class FieldMapping
    {
        public string Name { get; set; }
        public string DefaultValue { get; set; }
        public string Value { get; set; }
        public Type Type { get; set; }
        public int MaxLength { get; set; }
        public int Precision { get; set; }

        public FieldMapping()
        {
        }

        public FieldMapping(string name, Type type, string defaultValue)
            : this(name, type, defaultValue, 0, 0) { }

        public FieldMapping(string name, Type type)
            : this(name, type, null, 0, 0) { }

        public FieldMapping(string name, Type type, string defaultValue, int maxLength, int precision)
        {
            Name = name;
            Type = type;
            DefaultValue = name;
            MaxLength = maxLength;
            Precision = precision;
        }
    }
}
