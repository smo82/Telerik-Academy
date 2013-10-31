/*
 * Task02
 * 
 * Write a program to traverse the directory C:\WINDOWS and all its subdirectories recursively and 
 * to display all files matching the mask *.exe. Use the class System.IO.Directory.
 */

using System;
using System.Collections.Generic;
using System.IO;

public class TraverseWin
{
    private static List<FileInfo> files = new List<FileInfo>();
    private static List<DirectoryInfo> folders = new List<DirectoryInfo>();

    public static void Main(string[] args)
    {
        // Please check if your WINDOWS directory is on drive C:
        DirectoryInfo dirInfo = new DirectoryInfo("C:\\WINDOWS\\");
        FullDirList(dirInfo, "*.exe");

        PrintFilesFound();
    }

    private static void FullDirList(DirectoryInfo dir, string searchPattern)
    {
        try
        {
            foreach (FileInfo f in dir.GetFiles(searchPattern))
            {
                files.Add(f);                    
            }
        }
        catch
        {     
            // We got an error trying to access the dir
            return;
        }

        // if we didn't get an error getting the files, we should not get an error getting the dirs too
        // so no try-catch here
        foreach (DirectoryInfo d in dir.GetDirectories())
        {
            folders.Add(d);
            FullDirList(d, searchPattern);                    
        }
    }

    private static void PrintFilesFound()
    {
        foreach (FileInfo fileInfo in files)
        {
            Console.WriteLine(fileInfo.Name);
        }
    }
}