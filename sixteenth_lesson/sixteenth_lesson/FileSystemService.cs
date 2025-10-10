using System;
using System.ServiceProcess;
using System.Threading;

namespace sixteenth_lesson
{
    public partial class FileSystemService : ServiceBase
    {
        private FileSystemLogger fileSystemLogger;
        public FileSystemService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            fileSystemLogger = new FileSystemLogger();
            var loggerThread = new Thread(new ThreadStart(fileSystemLogger.Start));
            loggerThread.Start();
        }

        protected override void OnStop()
        {
            fileSystemLogger.Stop();
        }
    }
}
