using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace sixteenth_lesson
{
    public class FileSystemLogger
    {
        private const string PATH = @"D:\internship\file_system\filesystemLog.txt";

        private List< FileSystemWatcher> watcherList;
        bool enabled = true;

        public FileSystemLogger()
        {
            watcherList = new List< FileSystemWatcher>();
            foreach (var drive in DriveInfo.GetDrives())
            {
                var watcher = new FileSystemWatcher(drive.Name) {IncludeSubdirectories = true, Filter = "*.*" } ;
                watcher.Deleted += Watcher_Deleted;
                watcherList.Add(watcher);
            }
        }

        public void Start()
        {
            foreach (var watcher in watcherList)
            {
                watcher.EnableRaisingEvents = true;
            }
            while (enabled)
            {
                Thread.Sleep(1000);
            }
        }
        public void Stop()
        {
            foreach (var watcher in watcherList)
            { 
                watcher.EnableRaisingEvents = false;
            }
            enabled = false;
        }

        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            var filePath = e.FullPath;
            LogData(filePath);
        }

        private void LogData(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(PATH, true))
            {
                var date = DateTime.Now;
                writer.WriteLine($"{filePath} был удален {date}");
            }
        }
    }
}
