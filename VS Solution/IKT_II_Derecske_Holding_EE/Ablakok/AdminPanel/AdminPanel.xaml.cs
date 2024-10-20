using IKT_II_Derecske_Holding_EE.Ablakok.Stilus;
using IKT_II_Derecske_Holding_EE.API_Data;
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

namespace IKT_II_Derecske_Holding_EE.Ablakok.AdminPanel
{
    /// <summary>
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : UserControl
    {
        AdminAdatok szerverAdatok;
        MainWindow _mw;
        Button elozoFul = new();
        public AdminPanel(MainWindow mw)
        {
            szerverAdatok = new AdminAdatok();
            InitializeComponent();
            szerverAdatok.OsztalyokLekerdezve += () =>
            {
                OsztalyokGrid.ItemsSource = szerverAdatok.Osztalyok;
            };
            szerverAdatok.TanarokLekerdezve += () =>
            {
                TanarokGrid.ItemsSource = szerverAdatok.Tanarok;
            };
            szerverAdatok.TanorakLekerdezve += () =>
            {
                TanorakGrid.ItemsSource = szerverAdatok.Tanorak;
            };
            szerverAdatok.SzakokLekerdezve += () =>
            {
                SzakokGrid.ItemsSource = szerverAdatok.Szakok;
            };
            szerverAdatok.TantargyakLekerdezve += () =>
            {
                TantargyakGrid.ItemsSource = szerverAdatok.Tantargyak;
            };
            _mw = mw;
        }

        public void OsztalyokFulGomb(object sender, RoutedEventArgs e)
        {
            elozoFul.Background = SystemColors.ControlBrush;
            Button button = sender as Button;
            button.Background = Szinek.ASPARAGUS;
            elozoFul = button;

            AdminTabs.SelectedIndex = 0;
        }
        public void TanarokFulGomb(object sender, RoutedEventArgs e)
        {
            elozoFul.Background = SystemColors.ControlBrush;
            Button button = sender as Button;
            button.Background = Szinek.ASPARAGUS;
            elozoFul = button;

            AdminTabs.SelectedIndex = 1;
        }
        public void TanorakFulGomb(object sender, RoutedEventArgs e)
        {
            elozoFul.Background = SystemColors.ControlBrush;
            Button button = sender as Button;
            button.Background = Szinek.ASPARAGUS;
            elozoFul = button;

            AdminTabs.SelectedIndex = 2;
        }
        public void SzakokFulGomb(object sender, RoutedEventArgs e)
        {
            elozoFul.Background = SystemColors.ControlBrush;
            Button button = sender as Button;
            button.Background = Szinek.ASPARAGUS;
            elozoFul = button;

            AdminTabs.SelectedIndex = 3;
        }
        public void TantargyakFulGomb(object sender, RoutedEventArgs e)
        {
            elozoFul.Background = SystemColors.ControlBrush;
            Button button = sender as Button;
            button.Background = Szinek.ASPARAGUS;
            elozoFul = button;

            AdminTabs.SelectedIndex = 4;
        }
        public void OrarendekFulGomb(object sender, RoutedEventArgs e)
        {
            elozoFul.Background = SystemColors.ControlBrush;
            Button button = sender as Button;
            button.Background = Szinek.ASPARAGUS;
            elozoFul = button;

            AdminTabs.SelectedIndex = 5;
        }

        public void Adatok_Mentese(object sender, RoutedEventArgs e)
        {
            
        }

        public void Adatok_Megse(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
