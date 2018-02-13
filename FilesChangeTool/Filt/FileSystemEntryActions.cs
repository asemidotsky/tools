using System;

namespace FilesChangeTool
{
    public class FileSystemEntryActions
    {
        public FileSystemEntryActions(
            Action<string, FileSystemEntryActionParameter> directoryAction, 
            Action<string, FileSystemEntryActionParameter> fileAction,
            FileSystemEntryActionParameter parameter)
        {
            DirectoryAction = directoryAction;
            FileAction = fileAction;
            Parameter = parameter;
        }

        private Action<string, FileSystemEntryActionParameter> DirectoryAction { get; set; }
        private Action<string, FileSystemEntryActionParameter> FileAction { get; set; }

        public FileSystemEntryActionParameter Parameter { get; set; }

        public void ExecForDirectory(string par1)
        {
            DirectoryAction.Invoke(par1, Parameter);
        }

        public void ExecForFile(string par1)
        {
            FileAction.Invoke(par1, Parameter);
        }
    }
}