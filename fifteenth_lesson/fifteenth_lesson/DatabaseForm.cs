using System;
using System.Windows.Forms;

namespace fifteenth_lesson
{
    public partial class DatabaseForm : Form
    {
        public DatabaseForm()
        {
            InitializeComponent();

            timer1.Interval = 1000;
            timer1.Enabled = false;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var result = await DatabaseManager.GetDataAsync();
            textBoxStatus.Text += result + Environment.NewLine;
            timer1.Enabled = true;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var result = await DatabaseManager.SetDataAsync();
            textBoxStatus.Text += result + Environment.NewLine;
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBoxStatus.Text += "Данные получены" + Environment.NewLine;
        }
    }
}
