//Elizabeth Ifunanyachi Orji BU/22C/IT/7810
using System;
using System.IO;
using System.Linq;

public class OfficeFileSummary
{
    public static void Main()
    {
        // Directory name and file path
        string directoryName = "FileCollection";
        string resultsFileName = "results.txt";
        
        //function to help(helper function)
        bool IsOfficeFile(FileInfo file)
    {
        string[] fileExtensions = { ".xlsx", ".docx", ".pptx" };
        return fileExtensions.Contains(file.Extension.ToLower());
    }

        //making sure that our directory exists
        Directory.CreateDirectory(directoryName);

        // Initialize counters and variables
        int excelCount = 0, wordDocCount = 0, powerPointCount = 0;
        long excelSize = 0, wordDocSize = 0, powerPointSize = 0;
        long totalCount=0, totalSize=0;
        //Our DirectoryInfo object to access our stated directory
        DirectoryInfo directory = new DirectoryInfo(directoryName);

        // Enumerate the files
        foreach (FileInfo file in directory.GetFiles())
        {
            if (IsOfficeFile(file))
            {
                switch (file.Extension.ToLower())
                {
                    case ".xlsx":
                        excelCount++;
                        excelSize += file.Length;
                        break;
                    case ".docx":
                        wordDocCount++;
                        wordDocSize += file.Length;
                        break;
                    case ".pptx":
                        powerPointCount++;
                        powerPointSize += file.Length;
                        break;
                }
                totalCount++;
                totalSize+= file.Length;
            }
        }

        // Write results to file
        using (StreamWriter writer = new StreamWriter(resultsFileName))
        {
            writer.WriteLine("File Summary:");
            writer.WriteLine($"Excel files (.xlsx): {excelCount}, Total size: {excelSize} bytes");
            writer.WriteLine($"Word files (.docx): {wordDocCount}, Total size: {wordDocSize} bytes");
            writer.WriteLine($"PowerPoint files (.pptx): {powerPointCount}, Total size: {powerPointSize} bytes");
        }

        Console.WriteLine($"Results saved to 'results.txt'.");
    }

    
}