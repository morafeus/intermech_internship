
using System.ComponentModel;
using System.ServiceProcess;

namespace sixteenth_lesson
{
    [RunInstaller(true)]
    public partial class LoggerInstaller : System.Configuration.Install.Installer
    {
        ServiceInstaller serviceInstaller;
        ServiceProcessInstaller processInstaller;

        public LoggerInstaller()
        {
            InitializeComponent();
            serviceInstaller = new ServiceInstaller();
            processInstaller = new ServiceProcessInstaller();

            processInstaller.Account = ServiceAccount.LocalSystem;
            serviceInstaller.StartType = ServiceStartMode.Manual;
            serviceInstaller.ServiceName = "16lesson";
            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}
