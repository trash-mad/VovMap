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

namespace VovMap
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MapPage mp;

        bool w = false;

        public MainWindow()
        {
            InitializeComponent();

            Topmost = true;
            mp = new MapPage();
            mp.Document = OpenDocument;
            PageControl.ShowPage(mp);
        }

        public void OpenDocument(string name,string resname)
        {
            TextPage tp = new TextPage(name, resname);
            tp.Back = () =>
            {
                PageControl.ShowPage(mp);
            };
            PageControl.ShowPage(tp);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (!w)
            {
                Taskbar.Hide();
                WindowStyle = WindowStyle.None;
                WindowState = WindowState.Maximized;
                ResizeMode = ResizeMode.NoResize;
                Width = System.Windows.SystemParameters.PrimaryScreenWidth;
                Height = System.Windows.SystemParameters.PrimaryScreenHeight;
                Topmost = true;
                this.Left = 0;
                this.Top = 0;
            }
            else
            {
                Taskbar.Show();
                WindowStyle = WindowStyle.SingleBorderWindow;
                WindowState = WindowState.Normal;
                ResizeMode = ResizeMode.CanResize;
                Width = System.Windows.SystemParameters.WorkArea.Width-100;
                Height = System.Windows.SystemParameters.WorkArea.Height-100;
                Topmost = false;
                this.Left = 0;
                this.Top = 0;
            }
            w = !w;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Taskbar.Show();
        }
    }
}
