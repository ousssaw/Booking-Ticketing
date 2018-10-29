using Booking.Ticketing.Import;
using System.IO;

namespace Booking.Ticketing.Services
{
    public class FileWatcherService : IFileWatcherService
    {
        private readonly CsvFileReader _csvFileRedaer;
        private readonly ITicketingServices _ticketingService;

        public FileWatcherService(CsvFileReader csvFileReader, ITicketingServices orderService)
        {
            _csvFileRedaer = csvFileReader;
            _ticketingService = orderService;
        }
        public void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            if (File.Exists(e.FullPath))
            {
                var ticketsLines = _csvFileRedaer.ReadDocument(e.FullPath);
            }


            //var allFiles = _csvFileRedaer.GetAllFiles();
            //if (allFiles != null)
            //{
            //    foreach (var file in allFiles)
            //    {
            //        var prchestraLines = _csvFileRedaer.ReadDocument(file, "VPV_VENTEVPV4");
            //        _orderService.SetOrderIntoDb(prchestraLines);
            //    }
            //    _orderService.CreateVpOrder("VPV_VENTEVPV4", 6001865);
            //}
            //else
            //{
            //    _logger.LogInfo($"No file", LogType.Technical);
            //}
        }

        public void MonitorDirectory(string path)
        {
            FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();
            fileSystemWatcher.Path = path;
            fileSystemWatcher.Created += FileSystemWatcher_Created;
            fileSystemWatcher.EnableRaisingEvents = true;
        }
    }
}
