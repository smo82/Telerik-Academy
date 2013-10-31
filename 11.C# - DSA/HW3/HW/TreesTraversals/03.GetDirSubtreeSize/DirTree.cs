using System;

public class DirTree
{
    public DirTree(Folder root)
    {
        this.Root = root;
    }

    public Folder Root { get; private set; }
}