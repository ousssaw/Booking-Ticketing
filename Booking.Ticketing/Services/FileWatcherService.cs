using Booking.Ticketing.Import;
using System.IO;

namespace Booking.Ticketing.Services
{
    public class FileWatcherService : IFileWatcherService
    {
        private readonly CsvFileReader _csvFileRedaer;
        private readonly IElasticSearchServices _elasticSearchService;

        public FileWatcherService(CsvFileReader csvFileReader, IElasticSearchServices elasticSearchService)
        {
            _csvFileRedaer = csvFileReader;
            _elasticSearchService = elasticSearchService;
        }
        public void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            if (File.Exists(e.FullPath))
            {
                var ticketsLines = _csvFileRedaer.ReadDocument(e.FullPath);
                if(ticketsLines != null)
                {
                    _elasticSearchService.IndexAll(ticketsLines);
                }
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
