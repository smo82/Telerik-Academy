using System;

public static class FileUtils
{
    /// <summary>
    /// Gets the extension of a given file name
    /// </summary>
    /// <param name="fileName">A string containing the file name</param>
    /// <returns>Returns the extension of a given file name</returns>
    public static string GetFileExtension(string fileName)
    {
        int indexOfLastDot = fileName.LastIndexOf(".");
        if (indexOfLastDot == -1)
        {
            return string.Empty;
        }

        string extension = fileName.Substring(indexOfLastDot + 1);
        return extension;
    }

    /// <summary>
    /// Gets the name of a file without its extension
    /// </summary>
    /// <param name="fileName">A string containing the file name</param>
    /// <returns>Returns the name of a file without its extension</returns>
    public static string GetFileNameWithoutExtension(string fileName)
    {
        int indexOfLastDot = fileName.LastIndexOf(".");
        if (indexOfLastDot == -1)
        {
            return fileName;
        }

        string extension = fileName.Substring(0, indexOfLastDot);
        return extension;
    }
}