/*
 * Task03
 * 
 * Define classes File { string name, int size } and Folder { string name, File[] files, Folder[] childFolders } and 
 * using them build a tree keeping all files and folders on the hard drive starting from C:\WINDOWS. 
 * Implement a method that calculates the sum of the file sizes in given subtree of the tree and test it accordingly. 
 * Use recursive DFS traversal.
 */

using System;
using System.Collections.Generic;
using System.IO;

public class DirTreeMain
{
    public static void Main(string[] args)
    {
        // Please check if your WINDOWS directory is on drive C:
        DirectoryInfo dirInfo = new DirectoryInfo("C:\\WINDOWS\\");

        DirTree winDirTree = new DirTree(new Folder(dirInfo));
        Folder winDirRoot = winDirTree.Root;

        Folder someFolder = winDirRoot;
        for (int i = 0; i < someFolder.Count; i++)
        {
            GetFileSizeSumFolder(someFolder[i]);            
        }        
    }

    private static void GetFileSizeSumFolder(Folder someFolder)
    {
        Console.WriteLine(new string('-', 30));
        Console.WriteLine("We are processing folder {0}.", someFolder.Name);
        List<File> someFolderSubtreeFiles = someFolder.GetSubtreeFiles();
        long sumSizeSubtreeFiles = CalcListFilesSumSize(someFolderSubtreeFiles);
        Console.WriteLine("The sum of all files in this folder subtree is: {0} bytes", sumSizeSubtreeFiles);
    }

    private static long CalcListFilesSumSize(List<File> files)
    {
        long result = 0;
        foreach (File file in files)
        {
            result += file.Size;
        }

        return result;
    }
}