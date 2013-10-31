using System;
using System.Collections.Generic;
using System.IO;

public class Folder
{
    public Folder(DirectoryInfo dirInfo)
    {
        this.DirInfo = dirInfo;
        this.Name = dirInfo.Name;
        this.Files = new File[dirInfo.GetFiles().Length];
        this.ChildFolders = new Folder[dirInfo.GetDirectories().Length];

        this.Initialize();
    }

    public DirectoryInfo DirInfo { get; private set; }

    public string Name { get; private set; }

    public File[] Files { get; private set; }

    public Folder[] ChildFolders { get; private set; }

    public int Count
    {
        get
        {
            return this.ChildFolders.Length;
        }
    }

    public Folder this[int index]
    {
        get
        {
            if (index < 0 && index > (this.ChildFolders.Length - 1))
            {
                throw new IndexOutOfRangeException(string.Format(
                    "Invalid index {0}. The index should be in the interval [{1} .. {2}]!", index, 0, this.ChildFolders.Length));
            }

            return this.ChildFolders[index];
        }

        set
        {
            if (index < 0 && index > (this.ChildFolders.Length - 1))
            {
                throw new IndexOutOfRangeException(string.Format(
                    "Invalid index {0}. The index should be in the interval [{1} .. {2}]!", index, 0, this.ChildFolders.Length));
            }

            this.ChildFolders[index] = value;
        }
    }

    public void Initialize()
    {
        FileInfo[] innerFiles = this.DirInfo.GetFiles();
        for (int i = 0; i < innerFiles.Length; i++)
        {
            this.Files[i] = new File(innerFiles[i]);
        }

        DirectoryInfo[] childFolders = this.DirInfo.GetDirectories();
        for (int i = 0; i < childFolders.Length; i++)
        {
            this.ChildFolders[i] = new Folder(childFolders[i]);
        }
    }

    // DFS Traverse of the subfolders
    public List<File> GetSubtreeFiles()
    {
        List<File> result = new List<File>();

        foreach (Folder folder in this.ChildFolders)
        {
            result.AddRange(folder.GetSubtreeFiles());
        }

        result.AddRange(this.Files);

        return result;
    }
}
