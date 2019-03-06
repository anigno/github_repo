namespace AnignoraDataTypes.HtmlReporting
{
    public class HtmlReporter
    {
        public TagHtml HtmlTag { get; private set; }

        public HtmlReporter()
        {
            HtmlTag = new TagHtml();
        }

        public string Report
        {
            get { return HtmlTag.ToString(); }
        }

    }
}
