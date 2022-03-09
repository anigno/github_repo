namespace Anignora_LogViewer.BL.EventArgs
{
    public class LogLinesChangesEventArgs : System.EventArgs
    {
        public string Filename { get; set; }
        public string[][] LogLines { get; set; }
    }
}