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
using System.Windows.Threading;

namespace IKT_II_Derecske_Holding_EE.Ablakok.Tanar
{
    /// <summary>
    /// Interaction logic for TanarPanel.xaml
    /// </summary>
    public partial class TanarPanel : UserControl
    {
        TanarSzerverAdatok szerverAdatok = new();

        public TanarPanel()
        {
            InitializeComponent();
            TanuloAdatokGrid.ItemsSource = szerverAdatok.Tanulok;
            //TanuloJegyekGrid.ItemsSource = szerverAdatok.Jegyek;
            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += timer_Tick;
            LiveTime.Start();
        }

        private void OsztalyFulGomb(object sender, RoutedEventArgs e)
        {
            TabKonroll.SelectedIndex = 0;
        }

        private void OrarendFulGomb(object sender, RoutedEventArgs e)
        {
            TabKonroll.SelectedIndex = 1;

        }
        

        void timer_Tick(object sender, EventArgs e)
        {
            LiveTimeLabel.Content = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
