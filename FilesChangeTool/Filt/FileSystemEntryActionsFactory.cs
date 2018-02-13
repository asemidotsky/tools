using System;
using System.IO;
using System.Text.RegularExpressions;

namespace FilesChangeTool
{
    public class FileSystemEntryActionsFactory
    {
        public FileSystemEntryActions CreateChangeTimeActions(FileSystemEntryActionParameter parameter)
        {
            return new FileSystemEntryActions(ChangeDirectoryTimeAction, ChangeFileTimeAction, parameter);
        }

        public FileSystemEntryActions RemoveDirectoryActions(FileSystemEntryActionParameter parameter)
        {
            return new FileSystemEntryActions(RemoveDirectory, EmptyAction, parameter);
        }

        private void EmptyAction(string path, FileSystemEntryActionParameter parameter)
        {
            
        }

        private void ChangeDirectoryTimeAction(string path, FileSystemEntryActionParameter parameter)
        {
            if (parameter.TestMode)
            {
                return;
            }

            var time = DateTime.Parse(parameter.Parameter.ToString());
            Directory.SetCreationTime(path, time);
            Directory.SetLastAccessTime(path, time);
            Directory.SetLastWriteTime(path, time);
        }

        private void ChangeFileTimeAction(string path, FileSystemEntryActionParameter parameter)
        {
            if (parameter.TestMode)
            {
                return;
            }

            var time = DateTime.Parse(parameter.Parameter.ToString());
            File.SetCreationTime(path, time);
            File.SetLastAccessTime(path, time);
            File.SetLastWriteTime(path, time);
        }

        private void RemoveDirectory(string path, FileSystemEntryActionParameter parameter)
        {
            var regex = new Regex(parameter.Parameter.ToString());
            if (parameter.TestMode)
            {
                if (regex.IsMatch(path))
                {
                    Print("for deletion", ConsoleColor.Green);
                }
                return;
            }

            if (regex.IsMatch(path))
            {
                Directory.Delete(path, true);
                Print("deleted", ConsoleColor.Red);
            }      
        }

        private static void Print(string text, ConsoleColor color)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = currentColor;
        }
    }
}
