using System;
using System.IO;

public class File
{
    public File(FileInfo fileInfo)
    {
        this.Name = fileInfo.Name;
        this.Size = fileInfo.Length;
    }

    public string Name { get; private set; }

    public long Size { get; private set; }
}