using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Resources;
using System.Windows.Shapes;

namespace VovMap
{
    /// <summary>
    /// Логика взаимодействия для TextPage.xaml
    /// </summary>
    public partial class TextPage : UserControl
    {
        public Action Back { get; set; }

        public TextPage(string name, string resname)
        {
            InitializeComponent();

            TitleLabel.Content = name;
            
            StreamResourceInfo res = System.Windows.Application.GetResourceStream(new Uri("pack://application:,,,/VovMap;component/Pages/"+ resname + ".rtf"));
            TextRange textRange = new TextRange(TextBox.Document.ContentStart, TextBox.Document.ContentEnd);
            textRange.Load(res.Stream, System.Windows.DataFormats.Rtf);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Back();
        }
    }
}
