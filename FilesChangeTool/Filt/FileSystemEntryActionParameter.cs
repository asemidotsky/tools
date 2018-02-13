namespace FilesChangeTool
{
    public class FileSystemEntryActionParameter
    {
        public FileSystemEntryActionParameter(object parameter, bool testMode)
        {
            Parameter = parameter;
            TestMode = testMode;
        }

        public object Parameter { get; set; }
        public bool TestMode { get; set; }
    }
}