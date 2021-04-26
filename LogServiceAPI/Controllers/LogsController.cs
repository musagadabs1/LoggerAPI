using LogServiceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LogServiceAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LogsController : ControllerBase
    {

        // GET api/Logs/GetLogsDupAndUniqCount
        [HttpGet("{path}")]
        public ActionResult<FileDetail> GetLogsDupAndUniqCount(string path)
        {
            string line;

            string[] filePaths = Directory.GetFiles(path);//, SearchOption.AllDirectories

            if (filePaths is null)
            {
                return NotFound();
            }

            List<string> errors = new();

            foreach (var filePath in filePaths)
            {

                using (var sr = System.IO.File.OpenText(filePath))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        var errorMessage = LogUtil.GetErrorMessage(line);
                        errors.Add(errorMessage);

                    }
                }
            }
            var errorDetails = new FileDetail();

            var duplicates = LogUtil.GetDuplicates(errors);
            var uniques = LogUtil.GetNumberOfUniqueErrors(errors);

            errorDetails.NumberOfDuplicateErrors = duplicates.Count;
            errorDetails.NumberOfUniqueErrors = uniques.Count;

            return errorDetails;
        }

        // GET api/Logs/path
        [HttpGet("{path}")]
        public ActionResult GroupLogsAndZip(string path)
        {

            var destPath = @"C:\Logger\Logs\";

            var filePaths = Directory.GetFiles(path);

            foreach (var filePath in filePaths)
            {
                if (filePath != null)
                {
                    var filename = Path.GetFileName(filePath);

                    #region filename formatting
                    var filenameWithoutExtension = Path.ChangeExtension(filename, null);
                    var stringToRemove = "Pms_";
                    var removeComm_ = "comm_";

                    filenameWithoutExtension = filenameWithoutExtension.Replace(stringToRemove, "");
                    filenameWithoutExtension = filenameWithoutExtension.Replace(removeComm_, "");
                    #endregion
                    var fileDate = Convert.ToDateTime(filenameWithoutExtension).Date;

                    #region Date Declaration
                    var beginOctDate2019 = new DateTime(2019, 10, 19);
                    var endOctDate2019 = new DateTime(2019, 10, 31);
                    var beginNovDate2019 = new DateTime(2019, 11, 01);
                    var endNovDate2019 = new DateTime(2019, 11, 30);
                    var beginDecDate2019 = new DateTime(2019, 12, 01);
                    var endDecDate2019 = new DateTime(2019, 12, 31);

                    var beginJanDate2020 = new DateTime(2020, 01, 01);
                    var endJanDate2020 = new DateTime(2020, 01, 31);
                    var beginFebDate2020 = new DateTime(2020, 02, 01);
                    var endFebDate2020 = new DateTime(2020, 02, 28);
                    var beginMarDate2020 = new DateTime(2020, 03, 01);
                    var endMarDate2020 = new DateTime(2020, 03, 31);

                    var beginAprDate2020 = new DateTime(2020, 04, 01);
                    var endAprDate2020 = new DateTime(2020, 04, 30);
                    var beginMayDate2020 = new DateTime(2020, 05, 01);
                    var endMayDate2020 = new DateTime(2020, 05, 31);
                    var beginJunDate2020 = new DateTime(2020, 06, 01);
                    var endJunDate2020 = new DateTime(2020, 06, 30);

                    var beginJulDate2020 = new DateTime(2020, 07, 01);
                    var endJulDate2019 = new DateTime(2020, 07, 31);
                    var beginAugDate2020 = new DateTime(2020, 08, 01);
                    var endAugDate2020 = new DateTime(2020, 08, 31);
                    var beginSepDate2020 = new DateTime(2020, 09, 01);
                    var endSepDate2020 = new DateTime(2020, 09, 30);

                    var beginOctDate2020 = new DateTime(2020, 10, 01);
                    var endOctDate2020 = new DateTime(2020, 10, 31);
                    var beginNovDate2020 = new DateTime(2020, 11, 01);
                    var endNovDate2020 = new DateTime(2020, 11, 30);
                    var beginDecDate2020 = new DateTime(2020, 12, 01);
                    var endDecDate2020 = new DateTime(2020, 12, 31);
                    #endregion

                    if (fileDate >= beginOctDate2019 && fileDate <= endOctDate2019)
                    {
                        LogUtil.CreateFolderWithFiles(beginOctDate2019, endOctDate2019, path, filename, destPath);
                    }
                    if (fileDate >= beginNovDate2019 && fileDate <= endNovDate2019)
                    {

                        LogUtil.CreateFolderWithFiles(beginNovDate2019, endNovDate2019, path, filename, destPath);
                    }
                    if (fileDate >= beginDecDate2019 && fileDate <= endDecDate2019)
                    {
                        LogUtil.CreateFolderWithFiles(beginDecDate2019, endDecDate2019, path, filename, destPath);
                    }

                    if (fileDate >= beginJanDate2020 && fileDate <= endJanDate2020)
                    {
                        LogUtil.CreateFolderWithFiles(beginJanDate2020, endJanDate2020, path, filename, destPath);
                    }
                    if (fileDate >= beginFebDate2020 && fileDate <= endFebDate2020)
                    {
                        LogUtil.CreateFolderWithFiles(beginFebDate2020, endFebDate2020, path, filename, destPath);
                    }
                    if (fileDate >= beginMarDate2020 && fileDate <= endMarDate2020)
                    {
                        LogUtil.CreateFolderWithFiles(beginMarDate2020, endMarDate2020, path, filename, destPath);
                    }
                    if (fileDate >= beginAprDate2020 && fileDate <= endAprDate2020)
                    {
                        LogUtil.CreateFolderWithFiles(beginAprDate2020, endAprDate2020, path, filename, destPath);
                    }
                    if (fileDate >= beginMayDate2020 && fileDate <= endMayDate2020)
                    {
                        LogUtil.CreateFolderWithFiles(beginMayDate2020, endMayDate2020, path, filename, destPath);
                    }
                    if (fileDate >= beginJunDate2020 && fileDate <= endJunDate2020)
                    {
                        LogUtil.CreateFolderWithFiles(beginJunDate2020, endJunDate2020, path, filename, destPath);
                    }
                    if (fileDate >= beginJulDate2020 && fileDate <= endJulDate2019)
                    {
                        LogUtil.CreateFolderWithFiles(beginJulDate2020, endJulDate2019, path, filename, destPath);
                    }
                    if (fileDate >= beginAugDate2020 && fileDate <= endAugDate2020)
                    {
                        LogUtil.CreateFolderWithFiles(beginAugDate2020, endAugDate2020, path, filename, destPath);
                    }
                    if (fileDate >= beginSepDate2020 && fileDate <= endSepDate2020)
                    {
                        LogUtil.CreateFolderWithFiles(beginSepDate2020, endSepDate2020, path, filename, destPath);
                    }
                    if (fileDate >= beginOctDate2020 && fileDate <= endOctDate2020)
                    {
                        LogUtil.CreateFolderWithFiles(beginOctDate2020, endOctDate2020, path, filename, destPath);
                    }
                    if (fileDate >= beginNovDate2020 && fileDate <= endNovDate2020)
                    {
                        LogUtil.CreateFolderWithFiles(beginNovDate2020, endNovDate2020, path, filename, destPath);
                    }
                    if (fileDate >= beginDecDate2020 && fileDate <= endDecDate2020)
                    {
                        LogUtil.CreateFolderWithFiles(beginDecDate2020, endDecDate2020, path, filename, destPath);
                    }
                }
            }

            var newFolder = @"C:\Logger\Logs\zips";
            var loggerPaths = Directory.GetDirectories(destPath);
            foreach (var log in loggerPaths)
            {
                if (log != null)
                {
                    LogUtil.CreateAndZipFolder(destPath, log, newFolder);
                }

            }


            return Ok("successfully done.");
        }

        // GET api/Logs/DeleteLogsFromPeriods/{path},{fromDate},{toDate}
        [HttpGet("{path},{fromDate},{toDate}")]
        public ActionResult DeleteLogsFromPeriods(string path, DateTime fromDate, DateTime toDate)
        {

            //string path = @"C:\Users\SuleM\Downloads\Loggings\Loggings";
            //parameters.FilePath = @"C:\Users\SuleM\Downloads\Loggings\Loggings";
            var filePaths = Directory.GetFiles(path);//, SearchOption.AllDirectories

            //var dateFrom = new DateTime(2019, 10, 19).Date;
            //var dateTo = new DateTime(2019, 10, 31).Date;

            foreach (var filePath in filePaths)
            {
                if (filePath != null)
                {
                    var filename = Path.GetFileName(filePath);

                    #region filename formatting
                    var filenameWithoutExtension = Path.ChangeExtension(filename, null);
                    var stringToRemove = "Pms_";
                    var removeComm_ = "comm_";

                    filenameWithoutExtension = filenameWithoutExtension.Replace(stringToRemove, "");
                    filenameWithoutExtension = filenameWithoutExtension.Replace(removeComm_, "");
                    #endregion
                    var fileDate = Convert.ToDateTime(filenameWithoutExtension).Date;

                    if (fileDate >= fromDate && fileDate <= toDate)
                    {
                        LogUtil.DeleteFile(filePath);
                    }

                }
            }

            return Ok("Deleted Successfully.");
        }
        // GET api/Logs/TotalAvailableLogsInPeriods/{path},{fromDate},{toDate}
        [HttpGet("{path},{fromDate},{toDate}")]
        public ActionResult<int> TotalAvailableLogsInPeriods(string path, DateTime fromDate, DateTime toDate)
        {

            //string path = @"C:\Users\SuleM\Downloads\Loggings\Loggings";
            //parameters.FilePath = @"C:\Users\SuleM\Downloads\Loggings\Loggings";
            var filePaths = Directory.GetFiles(path);//, SearchOption.AllDirectories
            var logs = new List<string>();

            foreach (var filePath in filePaths)
            {
                if (filePath != null)
                {
                    var filename = Path.GetFileName(filePath);

                    #region filename formatting
                    var filenameWithoutExtension = Path.ChangeExtension(filename, null);
                    var stringToRemove = "Pms_";
                    var removeComm_ = "comm_";

                    filenameWithoutExtension = filenameWithoutExtension.Replace(stringToRemove, "");
                    filenameWithoutExtension = filenameWithoutExtension.Replace(removeComm_, "");
                    #endregion
                    var fileDate = Convert.ToDateTime(filenameWithoutExtension).Date;

                    if (fileDate >= fromDate && fileDate <= toDate)
                    {
                        logs.Add(filename);
                    }

                }
            }

            return logs.Count;
        }
        // GET api/Logs/TotalAvailableLogsInPeriods/{path},{fromDate},{toDate}
        [HttpGet("{path},{fromSize},{toSize}")]
        public ActionResult<List<string>> LogsPerSize(string path, long fromSize, long toSize)
        {

            //string path = @"C:\Users\SuleM\Downloads\Loggings\Loggings";
            var filePaths = Directory.GetFiles(path);//, SearchOption.AllDirectories
            var logs = new List<string>();

            foreach (var filePath in filePaths)
            {
                if (filePath != null)
                {
                    var filename = Path.GetFileName(filePath);

                    var fileInfo = new FileInfo(filePath);

                    var fileSize = fileInfo.Length;

                    long size = fileSize / 1024;

                    if (size >= fromSize && size <= toSize)
                    {
                        logs.Add(filename);
                    }

                }
            }

            return logs;
        }

        //GET api/Logs/LogsPerDirectory/{path},{directoryPath}
        [HttpGet("{path},{directoryPath}")]
        public ActionResult<List<string>> LogsPerDirectory(string path, string directoryPath)
        {
            var fileDirectories = Directory.GetDirectories(path);
            var logs = new List<string>();

            foreach (var directory in fileDirectories)
            {
                if (directory == directoryPath)
                {
                    var filePaths = Directory.GetDirectories(directory);
                    foreach (var filePath in filePaths)
                    {
                        if (filePath != null)
                        {
                            var files = Directory.GetFiles(filePath);
                            foreach (var file in files)
                            {
                                var filename = Path.GetFileName(file);
                                logs.Add(filename);
                            }


                        }
                    }
                }

            }



            return logs;
        }
    }
}
