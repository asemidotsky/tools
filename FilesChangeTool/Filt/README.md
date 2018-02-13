# Tool purpose

This is tool for recursively changing file system entries (directories and files).

Supporting operations:
* Change time properties of the file system entry
* Delete directory by regexp pattern

It's possible to set command line argument `/test` to see anticipated changes of the programm action.

# Change time properties

Change created, last write and last access time for all files and directories in directory C:\data\info
```
filt.exe "C:\data\info" ChangeTime /time:"2018-02-12T10:14:12"
```

# Delete directory

Delete directories in C:\data\info\project which path is ended with `bin` or `obj`
```
filt.exe "C:\data\info\project" Remove /pattern:"(bin|obj)$"
```