using System;
using USC.GISResearchLab.Common.Utils.Types;

namespace USC.GISResearchLab.Common.Attributes
{
    public class AttributeHelper
    {

        #region properties
        private string _Name;
        private string _Alias;
        private string _OriginalColumnName;
        private object _Value;
        private Type _DataType;

        public Type DataType
        {
            get { return _DataType; }
            set
            {
                _DataType = value;
                if (value != null) _Value = TypeUtils.GetDefaultValue(_DataType);
            }
        }


        public string Alias
        {
            get { return _Alias; }
            set { _Alias = value; }
        }

        public object Value
        {
            get { return _Value; }
            set { _Value = value; }
        }


        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string OriginalColumnName
        {
            get { return _OriginalColumnName; }
            set { _OriginalColumnName = value; }
        }

        #endregion

        public AttributeHelper()
        {
            DataType = null;
            Alias = "";
            Name = "";
        }

        public AttributeHelper(string name, Type dataType, string originalColumnName)
        {
            DataType = dataType;
            Alias = name;
            Name = name;
            OriginalColumnName = originalColumnName;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            AttributeHelper p = obj as AttributeHelper;
            if ((Object)p == null)
            {
                return false;
            }

            return (Name == p.Name) && (DataType == p.DataType);
        }

        public bool Equals(AttributeHelper p)
        {
            if ((object)p == null)
            {
                return false;
            }

            return (Name == p.Name) && (DataType == p.DataType);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ DataType.GetHashCode();
        }

        public static bool operator ==(AttributeHelper a, AttributeHelper b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            return a.Name == b.Name && a.DataType == b.DataType;
        }

        public static bool operator !=(AttributeHelper a, AttributeHelper b)
        {
            return !(a == b);
        }
    }
}
