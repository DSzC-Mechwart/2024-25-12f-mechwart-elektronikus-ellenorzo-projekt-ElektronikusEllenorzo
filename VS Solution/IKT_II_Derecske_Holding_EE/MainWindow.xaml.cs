using IKT_II_Derecske_Holding_EE.Ablakok.Login;
using IKT_II_Derecske_Holding_EE.Ablakok.Tanar;
using IKT_II_Derecske_Holding_EE.Ablakok.Tanulo;
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

namespace IKT_II_Derecske_Holding_EE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            LoginBtn.Click += (sender,e) => 
            {
                OurWindow.Content = new LoginPanel();
            };

            TanarBtn.Click += (sender, e) =>
            {
                OurWindow.Content = new TanarPanel();
            };

            TanuloBtn.Click += (sender, e) =>
            {
                OurWindow.Content = new TanuloPanel();
            };

        }
    }
}