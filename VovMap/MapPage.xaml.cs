using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для MapPage.xaml
    /// </summary>
    public partial class MapPage : UserControl
    {
        public Action<string,string> Document { get; set; }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        public MapPage()
        {
            InitializeComponent();
        }

        void ShowPointByName(string name)
        {
            foreach (var item in FindVisualChildren<MapPointControl>(MapCanvas))
            {
                if (item.Title != name) item.Hide();
                else item.Show();
            }
        }

        
        void Moskov()
        {
            Document("Битва за Москву","bitva_za_moskvu");
        }
        
        void Stalin()
        {
            Document("Сталинградская битва","stalingradskaya_bitva");
        }

        void Kursk()
        {
            Document("Курская битва","kurskaya_bitva");
        }

        void Berlin()
        {
            Document("Берлинская операция","berlinskaya_operacia");
        }

        void Bagration()
        {
            Document("Операция Багратион","operacia_bagration");
        }
    }
}
