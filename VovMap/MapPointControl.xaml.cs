using Microsoft.VisualBasic;
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
    /// Логика взаимодействия для MapPointControl.xaml
    /// </summary>
    public partial class MapPointControl : UserControl
    {

        bool IsMenuOpened = true;

        public string Border
        {
            set
            {
                if (value == "A")
                {
                    ContentTextBorder.CornerRadius = new CornerRadius(0, 30, 0, 30);
                    return;
                }
                if (value == "B")
                {
                    ContentTextBorder.CornerRadius = new CornerRadius(30, 0, 30, 0);
                    return;
                }
                throw new NotImplementedException();
            }
        }

        public string PinOrientation
        {
            set
            {
                if(value== "Bottom")
                {
                    PinIconPlace.VerticalAlignment = VerticalAlignment.Bottom;
                    return;
                }

                if (value == "Top")
                {
                    PinIconPlace.VerticalAlignment = VerticalAlignment.Top;
                    return;
                }

                throw new NotImplementedException();
            }
        }

        public string PinPosition
        {
            set
            {
                if (value == "Left")
                {
                    MainGrid.ColumnDefinitions[0].Width = new GridLength(50);
                    MainGrid.ColumnDefinitions[1].Width = new GridLength(50, GridUnitType.Star);

                    Grid.SetColumn(PinIconPlace, 0); 
                    Grid.SetColumn(TextPlace, 1); 
                    return;
                }
                if (value == "Right")
                {
                    MainGrid.ColumnDefinitions[1].Width = new GridLength(50);
                    MainGrid.ColumnDefinitions[0].Width = new GridLength(50, GridUnitType.Star);

                    Grid.SetColumn(PinIconPlace, 1);
                    Grid.SetColumn(TextPlace, 0);
                    return;
                }
                throw new NotImplementedException();
            }
        }
        
        public string Value
        {
            set
            {
                ContentTextBlock.Text = value;
            }
        }

        string title=null;
        public string Title
        {
            set
            {
                TitleLabel.Content = value;
                this.title = value;
            }
            get
            {
                return title;
            }
        }

        public Action Click { get; set; }

        public MapPointControl()
        {
            InitializeComponent();
            ContentTextBorder.Opacity=0;
        }
        
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!IsMenuOpened) Click();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (IsMenuOpened)
            {
                Storyboard sb = Resources["sbShowInfo"] as Storyboard;
                sb.Begin(ContentTextBorder);
            }
            else
            {
                Storyboard sb = Resources["sbHideInfo"] as Storyboard;
                sb.Begin(ContentTextBorder);
            }

            IsMenuOpened = !IsMenuOpened;
        }

        public void Hide()
        {
            if (!IsMenuOpened)
            {
                Storyboard sb = Resources["sbHideInfo"] as Storyboard;
                sb.Begin(ContentTextBorder);
                IsMenuOpened = !IsMenuOpened;
            }
        }

        public void Show()
        {
            if (IsMenuOpened)
            {
                Storyboard sb = Resources["sbShowInfo"] as Storyboard;
                sb.Begin(ContentTextBorder);
                IsMenuOpened = !IsMenuOpened;
            }
        }
    }
}
