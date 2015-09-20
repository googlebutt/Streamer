using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Streamer
{
    public partial class MainWindow : Window
            {

        public MainWindow()
        {
            InitializeComponent();

        }

        public void launch_livestreamer_OnClick(object sender, RoutedEventArgs e)

        {
            var procInfo = new System.Diagnostics.ProcessStartInfo();
            procInfo.FileName = "cmd.exe";
            procInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            procInfo.Arguments = "/C livestreamer twitch.tv/" + stream_path.Text + " " + quality.Text;
            System.Diagnostics.Process.Start(procInfo);
        }

        private void Chat_Click(object sender, RoutedEventArgs e)
        {

            Window1 Window1 = new Window1(this);
            Window1.Show();
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            stream_path.Text = Properties.Settings.Default.box;
            quality.Text = Properties.Settings.Default.qual;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Properties.Settings.Default.box = stream_path.Text;
            Properties.Settings.Default.qual = quality.Text;
            Properties.Settings.Default.Save();
        }
    }
}