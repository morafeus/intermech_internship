using System;
using System.ServiceProcess;
using System.Threading;

namespace sixteenth_lesson
{
    public partial class Service1 : ServiceBase
    {
        private FileSystemLogger fileSystemLogger;
        public Service1()
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
