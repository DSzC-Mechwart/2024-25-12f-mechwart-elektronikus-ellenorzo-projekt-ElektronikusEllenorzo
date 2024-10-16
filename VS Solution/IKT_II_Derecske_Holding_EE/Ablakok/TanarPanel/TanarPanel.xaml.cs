using IKT_II_Derecske_Holding_EE.Ablakok.Stilus;
using IKT_II_Derecske_Holding_EE.Ablakok.TanarPanel;
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
        TanarSzerverAdatok szerverAdatok;

        public TanarPanel()
        {
            szerverAdatok = new();
            InitializeComponent();
            TanuloAdatokGrid.ItemsSource = szerverAdatok.Tanulok;
            szerverAdatok.OsztalyJegyekLekerdezve += () =>
            {
                JegyekGrid.ItemsSource = szerverAdatok.TesztJegy;
            };
            szerverAdatok.TantargyakLekerdezve += () =>
            {
                TantargyBox.ItemsSource = szerverAdatok.Tantargyak;
            };
            StatisztikaPanel.Content = new Statisztika();
            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += timer_Tick;
            LiveTime.Start();
            OsztalyokBtn.Background = Szinek.ASPARAGUS;
        }

        private void OsztalyFulGomb(object sender, RoutedEventArgs e)
        {
            TabKonroll.SelectedIndex = 0;
            OsztalyokBtn.Background = Szinek.ASPARAGUS;
            OrarendBtn.Background = SystemColors.ControlBrush;
        }

        private void OrarendFulGomb(object sender, RoutedEventArgs e)
        {
            TabKonroll.SelectedIndex = 1;
            OrarendBtn.Background = Szinek.ASPARAGUS;
            OsztalyokBtn.Background = SystemColors.ControlBrush;
        }
        

        void timer_Tick(object sender, EventArgs e)
        {
            LiveTimeLabel.Content = DateTime.Now.ToString("HH:mm:ss");
        }

        private void KilepesGomb(object sender, RoutedEventArgs e)
        {

        }

        private void UjJegy(object sender, RoutedEventArgs e)
        {
            UjJegyOszlop.Visibility = Visibility.Visible;
            UjJegyBtn.IsEnabled = false;
            MegseJegyBtn.Visibility = Visibility.Visible;
            JegyekMenteseBtn.Visibility = Visibility.Visible;
        }

        private void MegseJegy(object sender, RoutedEventArgs e)
        {
            UjJegyOszlop.Visibility = Visibility.Hidden;
            UjJegyBtn.IsEnabled = true;
            MegseJegyBtn.Visibility = Visibility.Hidden;
            JegyekMenteseBtn.Visibility = Visibility.Hidden;
        }

        private void JegyekMentese(object sender, RoutedEventArgs e)
        {
            UjJegyOszlop.Visibility = Visibility.Hidden;
            UjJegyBtn.IsEnabled = true;
            MegseJegyBtn.Visibility = Visibility.Hidden;
            JegyekMenteseBtn.Visibility = Visibility.Hidden;
        }
    }
}
