using System.Windows;

namespace LoginInterface
{
    public partial class Orarend : Window
    {
        public string UserName { get; set; }

        public Orarend()
        {
            InitializeComponent();
            UserName = "Szabó Balázs";
            DataContext = this;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
