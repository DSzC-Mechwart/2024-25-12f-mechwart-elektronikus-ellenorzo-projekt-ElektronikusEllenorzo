using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ElektronikusEllenőrzőProjekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void david_Click(object sender, RoutedEventArgs e)
        {
            DWindow dw = new DWindow();
            dw.Show();
        }

        private void kende_Click(object sender, RoutedEventArgs e)
        {
            KWindow kw = new KWindow();
            kw.Show();
        }

        private void kristof_Click(object sender, RoutedEventArgs e)
        {
            HWindow hw = new HWindow();
            hw.Show();
        }
    }
}