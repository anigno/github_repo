namespace AnignoraIO.DirectoryWalking
{
    public class StartCalculationThreadParams
    {
        public string RootDirectory { get; set; }
        public WalkingStyleEnum WalkingStyle { get; set; }

        public StartCalculationThreadParams(string p_rootDirectory, WalkingStyleEnum p_walkingStyle)
        {
            RootDirectory = p_rootDirectory;
            WalkingStyle = p_walkingStyle;
        }
    }
}