namespace Anignora_LogViewer.BL
{
    public class HistoryFileData
    {
        public string FilePath { get; set; }
        public string SIndex { get; set; }
        public int Fatals { get; set; }
        public int Errors { get; set; }
        public int Warnings { get; set; }
        public string SStartTime { get; set; }
        public string SEndTime { get; set; }
    }
}