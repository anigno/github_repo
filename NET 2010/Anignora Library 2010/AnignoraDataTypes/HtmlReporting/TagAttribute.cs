namespace AnignoraDataTypes.HtmlReporting
{
    public class TagAttribute
    {
        public string Key { get; private set; }
        public string Value { get; private set; }

        public TagAttribute(string p_key, string p_value)
        {
            Key = p_key;
            Value = p_value;
        }
    }
}