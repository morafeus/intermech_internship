using System;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;

namespace sixteenth_lesson_ex2
{
    public enum InstallationFlag { Install, Deinstall}

    public class ServiceInstaller
    {
        private const string SERVCIEPATH = @"../../../sixteenth_lesson/bin/Debug/sixteenth_lesson.exe";

        private static string GetInstallUtilPath()
        {
            var frameworkPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Microsoft.NET", "Framework", "v4.0.30319"); 
            return Path.Combine(frameworkPath, "InstallUtil.exe");
        }

        private static string GetFullPath()
        {
            if(File.Exists(SERVCIEPATH))
            {
                var f = new FileInfo(SERVCIEPATH);
                return f.FullName;
            }
            return SERVCIEPATH;
        }

        public static void InstallationService(InstallationFlag flag)
        {
            var installUtil = GetInstallUtilPath();
            var startInfo = new ProcessStartInfo();

            if (!File.Exists(installUtil))
            {
                Console.WriteLine("утилиты установки не обнаружено");
                return;
            }

            switch (flag)
            {
                case InstallationFlag.Install:
                    { 
                        startInfo = new ProcessStartInfo(installUtil)
                        {
                            Arguments = $"\"{GetFullPath()}\"",
                            UseShellExecute = true,
                            Verb = "runas"
                        };
                        break;
                    }
                case InstallationFlag.Deinstall:
                    {
                        startInfo = new ProcessStartInfo(installUtil)
                        {
                            Arguments = $"/uninstall \"{GetFullPath()}\"",
                            UseShellExecute = true,
                            Verb = "runas"
                        };
                        break;
                    }
            }

            try
            {
                using (Process process = Process.Start(startInfo))
                {
                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static string StartService(string serviceName)
        {
            ServiceController service = new ServiceController(serviceName);
           
            try
            {
                if (service.Status != ServiceControllerStatus.Running)
                {
                    service.Start();
                    var timeout = new TimeSpan(0, 0, 5);
                    service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                    return "служба запущена.";
                }
                else
                {
                    return "данная служба уже работает";
                }
            }
            catch
            {
                return "ошибка при запуске службы";
            }
        }

        public static string StopService(string serviceName)
        {
            ServiceController service = new ServiceController(serviceName);

            try
            {
                if (service.Status != ServiceControllerStatus.Stopped)
                {
                    service.Stop();
                    var timeout = new TimeSpan(0, 0, 5);
                    service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                    return "служба остановлена.";
                }
                else
                {
                    return "данная служба не запущена";
                }
            }
            catch
            {
                return "ошибка при остановке службы";
            }
        }
    }
}
