namespace USC.GISResearchLab.Common.TemplateObjects.SingleValueObjects
{
    public class SingleValueObject
    {
        #region Properties
        private object _Value;
        public object Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        #endregion

        public SingleValueObject(object value)
        {
            Value = value;
        }
    }
}
