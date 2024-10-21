using IKT_II_Derecske_Holding_EE.Ablakok.AdminPanel;
using IKT_II_Derecske_Holding_EE.Ablakok.Login;
using IKT_II_Derecske_Holding_EE.Ablakok.Tanar;
using IKT_II_Derecske_Holding_EE.Ablakok.Tanulo;
using IKT_II_Derecske_Holding_EE.Models;
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
                OurWindow.Content = new LoginPanel(this);
            };

            TanarBtn.Click += (sender, e) =>
            {
                OurWindow.Content = new TanarPanel(this, new() { Nev="Mátyás", P_Hash="", P_Salt="", ID = 99 } );
            };

            TanuloBtn.Click += (sender, e) =>
            {
                OurWindow.Content = new TanuloPanel(this);
            };

        }

        public void ChangeTo(int scene, object? parameter)
        {
            switch (scene)
            {
                case 0:
                    OurWindow.Content = new LoginPanel(this);
                    break;
                case 1:
                    OurWindow.Content = new TanuloPanel(this);
                    break;
                case 2:
                    if (parameter != null)
                    {
                        var tanar = parameter as Tanar;
                        OurWindow.Content = new TanarPanel(this, tanar);
                    }
                    break;
                case 3:
                    OurWindow.Content = new AdminPanel(this);
                    break;
                default:
                    break;
            }
        }
    }
}