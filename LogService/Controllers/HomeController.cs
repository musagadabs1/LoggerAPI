using LogService.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace LogService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        [Obsolete]
        private IHostingEnvironment _environment;

        [Obsolete]
        public HomeController(ILogger<HomeController> logger, IHostingEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public IActionResult DeleteLogsFromPeriods()
        {


            string path = @"C:\Users\SuleM\Downloads\Loggings\Loggings";
            //param.FilePath = @"C:\Users\SuleM\Downloads\Loggings\Loggings";
            var filePaths = Directory.GetFiles(path);//, SearchOption.AllDirectories

            var dateFrom = new DateTime(2019, 10, 19).Date;
            var dateTo = new DateTime(2019, 10, 31).Date;

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

                    if (fileDate >= dateFrom && fileDate <= dateTo)
                    {
                        LogUtil.DeleteFile(filePath);
                    }

                }
            }

            return View("Deleted Successfully.");
        }

        public IActionResult GetFilePath()
        {
            string path = @"C:\Users\SuleM\Downloads\Loggings\Loggings";

            var destPath = @"C:\Logger\Logs\";

            var filePaths = Directory.GetFiles(path);//, SearchOption.AllDirectories

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
                    try
                    {
                        LogUtil.CreateAndZipFolder(destPath, log, newFolder);
                    }
                    catch (Exception)
                    {

                        return Ok("File exist");
                        //throw new HttpResponseMessage(System.Net.HttpStatusCode.NotAcceptable);
                    }

                }

            }


            return Ok("successfully.");
        }

        public IActionResult Index()
        {

            string path = @"C:\Users\SuleM\Downloads\Loggings\Loggings";
            string line;

            string[] filePaths = Directory.GetFiles(path);//, SearchOption.AllDirectories
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

            ViewBag.Errors = duplicates;
            ViewBag.ErrorCount = errorDetails;

            return View(errorDetails);
        }

        public IActionResult DownloadFile(string fileName)
        {
            // Build the file path
            // var path = Path.Combine(_environment.WebRootPath, "Files/") + fileName;

            // Read the file data into bytes array

            //var bytes = System.IO.File.ReadAllBytes(path);
            // return File(/*bytes*/, "application/octet-stream", fileName);
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
