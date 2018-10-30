using Booking.Ticketing.Import;
using System.IO;

namespace Booking.Ticketing.Services
{
    public class FileWatcherService : IFileWatcherService
    {
        private readonly CsvFileReader _csvFileRedaer;
        private readonly ITicketingServices _ticketingService;

        public FileWatcherService(CsvFileReader csvFileReader, ITicketingServices ticketingService)
        {
            _csvFileRedaer = csvFileReader;
            _ticketingService = ticketingService;
        }
        public void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            if (File.Exists(e.FullPath))
            {
                var ticketsLines = _csvFileRedaer.ReadDocument(e.FullPath);
            }
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
