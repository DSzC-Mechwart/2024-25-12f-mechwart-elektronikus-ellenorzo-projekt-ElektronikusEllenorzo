using IKT_II_Derecske_Holding_EE.Ablakok.Stilus;
using IKT_II_Derecske_Holding_EE.API_Data;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        Dictionary<int, int> modosultAdatokIndex = new(); // 1-hozzaad, 2-torol, 3-modosul

        public AdminPanel(MainWindow mw)
        {
            szerverAdatok = new AdminAdatok();
            InitializeComponent();
            szerverAdatok.OsztalyokLekerdezve += () =>
            {
                OsztalyokGrid.ItemsSource = szerverAdatok.Osztalyok;
                szerverAdatok.Osztalyok.CollectionChanged += Lista_Modosult;
            };
            szerverAdatok.TanarokLekerdezve += () =>
            {
                TanarokGrid.ItemsSource = szerverAdatok.Tanarok;
                szerverAdatok.Tanarok.CollectionChanged += Lista_Modosult;
            };
            szerverAdatok.TanorakLekerdezve += () =>
            {
                TanorakGrid.ItemsSource = szerverAdatok.Tanorak;
                szerverAdatok.Tanorak.CollectionChanged += Lista_Modosult;
            };
            szerverAdatok.SzakokLekerdezve += () =>
            {
                SzakokGrid.ItemsSource = szerverAdatok.Szakok;
                szerverAdatok.Szakok.CollectionChanged += Lista_Modosult;
            };
            szerverAdatok.TantargyakLekerdezve += () =>
            {
                TantargyakGrid.ItemsSource = szerverAdatok.Tantargyak;
                szerverAdatok.Tantargyak.CollectionChanged += Lista_Modosult;
            };
            _mw = mw;

            //szerverAdatok.Osztalyok.CollectionChanged += Lista_Modosult;
        }

        private void Lista_Modosult(object? sender, NotifyCollectionChangedEventArgs e)
        {
            AdatMegseBtn.IsEnabled = true;
            AdatMentesBtn.IsEnabled = true;
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                modosultAdatokIndex.TryAdd(e.NewStartingIndex, 1);
            }
        }

        public void OsztalyokFulGomb(object sender, RoutedEventArgs e)
        {
            elozoFul.Background = SystemColors.ControlBrush;
            Button button = sender as Button;
            button.Background = Szinek.ASPARAGUS;
            elozoFul = button;
            ModosultVissza();

            AdminTabs.SelectedIndex = 0;
        }

        public void TanarokFulGomb(object sender, RoutedEventArgs e)
        {
            elozoFul.Background = SystemColors.ControlBrush;
            Button button = sender as Button;
            button.Background = Szinek.ASPARAGUS;
            elozoFul = button;
            ModosultVissza();

            AdminTabs.SelectedIndex = 1;
        }
        public void TanorakFulGomb(object sender, RoutedEventArgs e)
        {
            elozoFul.Background = SystemColors.ControlBrush;
            Button button = sender as Button;
            button.Background = Szinek.ASPARAGUS;
            elozoFul = button;
            ModosultVissza();

            AdminTabs.SelectedIndex = 2;
        }
        public void SzakokFulGomb(object sender, RoutedEventArgs e)
        {
            elozoFul.Background = SystemColors.ControlBrush;
            Button button = sender as Button;
            button.Background = Szinek.ASPARAGUS;
            elozoFul = button;
            ModosultVissza();

            AdminTabs.SelectedIndex = 3;
        }
        public void TantargyakFulGomb(object sender, RoutedEventArgs e)
        {
            elozoFul.Background = SystemColors.ControlBrush;
            Button button = sender as Button;
            button.Background = Szinek.ASPARAGUS;
            elozoFul = button;
            ModosultVissza();


            AdminTabs.SelectedIndex = 4;
        }
        public void OrarendekFulGomb(object sender, RoutedEventArgs e)
        {
            elozoFul.Background = SystemColors.ControlBrush;
            Button button = sender as Button;
            button.Background = Szinek.ASPARAGUS;
            elozoFul = button;
            ModosultVissza();

            AdminTabs.SelectedIndex = 5;
        }

        private void ModosultVissza()
        {
            modosultAdatokIndex.Clear();
            AdatMegseBtn.IsEnabled = false;
            AdatMentesBtn.IsEnabled = false;
        }

        public void Adatok_Mentese(object sender, RoutedEventArgs e)
        {
            int tablaInd = AdminTabs.SelectedIndex;
            switch (tablaInd)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                default:
                    break;
            }
        }

        public void Adatok_Megse(object sender, RoutedEventArgs e)
        {
            ModosultVissza();
            int tablaInd = AdminTabs.SelectedIndex;
            switch (tablaInd)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                default:
                    break;
            }
        }
    }
}
