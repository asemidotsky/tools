using System;
using System.IO;
using NConsoler;

namespace FilesChangeTool
{
    class FileSystemEntriesProcessor
    {
        [Action]
        public static void Run(
            [Required] string directoryPath,
            [Required] ActionType action,
            [Optional("(.*)")] string pattern,
            [Optional("")] string time,
            [Optional(false)] bool test
            )
        {
            var actionsFactory = new FileSystemEntryActionsFactory();
            FileSystemEntryActions actions = null;
            FileSystemEntryActionParameter parameter;

            switch (action)
            {
                case ActionType.ChangeTime:
                    parameter = new FileSystemEntryActionParameter(time.Trim('"'), test);
                    actions = actionsFactory.CreateChangeTimeActions(parameter);
                    break;
                case ActionType.Remove:
                    parameter = new FileSystemEntryActionParameter(pattern.Trim('"'), test);
                    actions = actionsFactory.RemoveDirectoryActions(parameter);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), action, null);
            }

            var dir = directoryPath;
            ProcessDirectory(dir, 0, actions);
        }

        static void ProcessDirectory(string dirPath, int level, FileSystemEntryActions actions)
        {           
            var entries = Directory.GetFileSystemEntries(dirPath);

            foreach (var path in entries)
            {
                // if directory
                if (Directory.Exists(path))
                {
                    Console.WriteLine($"{new String('-', level)} {new DirectoryInfo(path).Name}");
                    actions.ExecForDirectory(path);

                    // this dublicate check for case when file system action is "Remove Directory"
                    if (Directory.Exists(path))
                    {
                        ProcessDirectory(path, ++level, actions);
                    }
                }
                else
                {
                    Console.WriteLine($"{new String('-', level)} {new FileInfo(path).Name}");
                    actions.ExecForFile(path);
                }
            }
        }
    }
}
