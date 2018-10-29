using System.IO;

namespace Booking.Ticketing.Services
{
    public interface IFileWatcherService
    {
        void MonitorDirectory(string path);
        void FileSystemWatcher_Created(object sender, FileSystemEventArgs e);
    }
}
