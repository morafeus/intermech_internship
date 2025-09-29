using Microsoft.Win32;
using System.Configuration;

namespace fifth_lesson_ex4
{
    public enum SettingType { BackGround, ForeGround, FontSize, FontStyle }
    public class SettingsController
    {
        public void SaveConfig(string value, SettingType type)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            switch (type)
            {
                case SettingType.BackGround:
                    config.AppSettings.Settings["BackgroundColor"].Value = value; break;
                case SettingType.ForeGround:
                    config.AppSettings.Settings["FontColor"].Value = value; break;
                case SettingType.FontSize:
                    config.AppSettings.Settings["FontSize"].Value = value; break;
                case SettingType.FontStyle:
                    config.AppSettings.Settings["FontStyle"].Value = value; break;
                default:
                    break;

            }
            config.Save(ConfigurationSaveMode.Full);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public void SaveToRegistry(string value, SettingType type)
        {
            string registryKeyPath = "ex5_key";
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(registryKeyPath))
            {
                if (key != null)
                {
                    switch (type)
                    {
                        case SettingType.BackGround:
                            key.SetValue("BackgroundColor", value); break;
                        case SettingType.ForeGround:
                            key.SetValue("FontColor", value); break;
                        case SettingType.FontSize:
                            key.SetValue("FontSize", value); break;
                        case SettingType.FontStyle:
                            key.SetValue("FontStyle", value); break;
                        default:
                            break;
                    }
                }
            }
        }

        public string LoadFromRegistry(SettingType type)
        {
            string registryKeyPath = "ex5_key";
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(registryKeyPath))
            {
                if (key != null)
                {
                    switch (type)
                    {
                        case SettingType.BackGround:
                            return key.GetValue("BackgroundColor") as string;
                        case SettingType.ForeGround:
                            return key.GetValue("FontColor") as string;
                        case SettingType.FontSize:
                            return key.GetValue("FontSize") as string;
                        case SettingType.FontStyle:
                            return key.GetValue("FontStyle") as string;
                        default:
                            return null;
                    }
                }
            }
            return null;
        }
    }
}
