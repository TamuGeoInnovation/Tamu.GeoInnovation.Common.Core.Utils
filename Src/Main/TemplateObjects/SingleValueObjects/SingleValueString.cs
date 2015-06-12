namespace USC.GISResearchLab.Common.TemplateObjects.SingleValueObjects
{
    public class SingleValueString : SingleValueObject
    {
        #region Properties
        private string _Value;
        public new string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        public SingleValueString(string value)
            :base(value)
        {
        }

        #endregion
    }
}
