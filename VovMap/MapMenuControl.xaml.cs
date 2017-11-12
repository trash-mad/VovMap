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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VovMap
{
    /// <summary>
    /// Логика взаимодействия для MapMenuControl.xaml
    /// </summary>
    public partial class MapMenuControl : UserControl
    {
        class Battle
        {
            public Battle(string Name, string Value)
            {
                this.Name = Name;
                this.Value = Value;
            }

            public string Name
            {
                private set;get;
            }
            public string Value
            {
                private set; get;
            }
        }

        bool IsOpened = false;
        List<Battle> battlelist;

        public Action<string> ShowControl { get; set; }

        public MapMenuControl()
        {
            battlelist = new List<Battle>
            {
                new Battle("Битва за Москву","bitva_za_moskvu"),
                new Battle("Сталинградская битва","stalingradskaya_bitva"),
                new Battle("Курская битва","kurskaya_bitva"),
                new Battle("Берлинская Операция","berlinskaya_operacia"),
                new Battle("Операция «Багратион»","operacia_bagration")
            };
            InitializeComponent();
            RootElem.Height = 50;


            BattleList.ItemsSource = battlelist;

        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (IsOpened)
            {
                Storyboard sb = Resources["sbHideLeftMenu"] as Storyboard;
                sb.Begin(RootElem);
            }
            else
            {
                Storyboard sb = Resources["sbShowLeftMenu"] as Storyboard;
                sb.Begin(RootElem);
            }
            IsOpened = !IsOpened;
        }

        private void BattleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (sender as ListBox).SelectedItem;
            (sender as ListBox).SelectedIndex = -1;
            if (item == null) return;
            ShowControl((item as Battle).Name);
        }
    }
}
