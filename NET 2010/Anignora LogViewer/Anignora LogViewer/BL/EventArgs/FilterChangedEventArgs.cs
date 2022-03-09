namespace Anignora_LogViewer.BL.EventArgs
{
    public class FilterChangedEventArgs : System.EventArgs
    {
        public string FilterName { get; private set; }

        public FilterChangedEventArgs(string p_filterName)
        {
            FilterName = p_filterName;
        }
    }
}