using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace LogServiceAPI.Models
{
    public class LogUtil
    {
        public static void DeleteFile(string filename)
        {
            if (File.Exists(filename))
            {
                //If Directory (Folder) does not exists. Create it.
                File.Delete(filename);
            }
        }
        public static string GetErrorMessage(string line)
        {
            var errorArray = line.Split(':');
            var errorMessage = errorArray[errorArray.Length - 1];
            return errorMessage;
        }
        public static bool CheckForDuplicates(List<string> strings)
        {
            var duplicates = strings.GroupBy(p => p).Where(g => g.Count() > 1).Select(g => g.Key);
            return (duplicates.Count() > 0);
        }
        public static List<string> GetDuplicates(List<string> list)
        {
            var duplicates = list.GroupBy(p => p).Where(g => g.Count() > 1).Select(g => g.Key).ToList();

            return duplicates;
        }
        public static FileDetail GetErrorCount(List<string> list)
        {
            FileDetail errorCount = new();
            for (int i = 0; i < list.Count; i++)
            {
                //var duplicateCount = 0;
                //var uniqueCount = 0;
                if (list[i] != null)
                {
                    for (int j = i + 1; j < list.Count; j++)
                    {
                        if (list[j] != null)
                        {
                            if (list[i].Equals(list[j]))
                            {
                                list[j] = null;
                                errorCount.NumberOfDuplicateErrors += 1;
                            }
                            else
                            {
                                list[j] = null;
                                errorCount.NumberOfUniqueErrors += 1;
                            }
                        }
                    }
                }
            }
            return errorCount;
        }
        public static List<string> GetNumberOfUniqueErrors(List<string> list)
        {
            var uniqueList = list
                .GroupBy(x => x)
                .SelectMany(array => array)
                .Distinct()
                .ToList();

            return uniqueList;
        }
        public static void CreateFolder(string filePath)
        {

            if (!Directory.Exists(filePath))
            {
                //If Directory (Folder) does not exists. Create it.
                Directory.CreateDirectory(filePath);
            }

        }
        public static void CopyFileToFolder(string sourceFile, string destFile)
        {
            // To copy a file to another location and
            // overwrite the destination file if it already exists.
            File.Copy(sourceFile, destFile, true);
        }
        public static void CreateFolderWithFiles(DateTime dateStart, DateTime dateEnd, string sourceFolder, string fileName, string destFolder)
        {
            var targetFolderPath = destFolder + dateStart.ToShortDateString().Replace("/", "_") + "-" + dateEnd.ToShortDateString().Replace("/", "_");

            var targetFileName = fileName;
            var sourceFolderPath = sourceFolder;
            var sourceFileName = fileName;

            CreateFolder(targetFolderPath);

            string destFile = Path.Combine(targetFolderPath, targetFileName);

            var sourceFile = Path.Combine(sourceFolderPath, sourceFileName);

            CopyFileToFolder(sourceFile, destFile);
        }
        public static void CreateAndZipFolder(string destFolder, string fileName, string newFolder)
        {
            try
            {
                CreateFolder(newFolder);
                var zipDest = fileName + ".zip";

                ZipFile.CreateFromDirectory(newFolder, zipDest);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
