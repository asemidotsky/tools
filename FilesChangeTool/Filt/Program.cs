using NConsoler;

namespace FilesChangeTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Consolery.Run(typeof(FileSystemEntriesProcessor), args);
        }
    }
}
