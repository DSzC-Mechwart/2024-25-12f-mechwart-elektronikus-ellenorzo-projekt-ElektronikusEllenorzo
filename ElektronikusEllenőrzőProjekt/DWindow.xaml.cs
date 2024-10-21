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
    /// Interaction logic for DWindow.xaml
    /// </summary>
    public partial class DWindow : Window
    {
        public DWindow()
        {
            InitializeComponent();
        }

        private void cBevitel_Click(object sender, RoutedEventArgs e)
        {
            dBevitel win = new dBevitel();
            win.Show();
        }
    }
}
