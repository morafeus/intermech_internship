using System;         
using System.Windows.Forms;

namespace sixteenth_lesson_ex2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Enabled = true;
        }

        private void InstallButton_Click(object sender, EventArgs e)
        {
            ServiceInstaller.InstallationService(InstallationFlag.Install);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

            ServiceInstaller.InstallationService(InstallationFlag.Deinstall);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {

        }

        private void StopButton_Click(object sender, EventArgs e)
        {

        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            DataTextBox.Text = string.Empty;
            DataTextBox.Text = await LogFileManager.GetDataAsync();

        }
    }
}
