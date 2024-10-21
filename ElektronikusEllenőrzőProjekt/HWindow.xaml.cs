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
using System.Windows.Shapes;

namespace ElektronikusEllenőrzőProjekt
{
    /// <summary>
    /// Interaction logic for HWindow.xaml
    /// </summary>
    public partial class HWindow : Window
    {
        public HWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!(String.IsNullOrEmpty(HFN.Text)))
            {
                HBWindow hb = new HBWindow(HFN.Text);
                hb.Show();
                Close();
            }
        }
    }
}
