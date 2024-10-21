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

namespace IKT_II_Derecske_Holding_EE.Ablakok.Tanulo
{
    /// <summary>
    /// Interaction logic for TanuloPanel.xaml
    /// </summary>
    public partial class TanuloPanel : UserControl
    {
        SzerverAdatok szerverAdatok = new();
        MainWindow _mainWindow;
        Button elozoFul = new();
        public TanuloPanel(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
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
    }
}
