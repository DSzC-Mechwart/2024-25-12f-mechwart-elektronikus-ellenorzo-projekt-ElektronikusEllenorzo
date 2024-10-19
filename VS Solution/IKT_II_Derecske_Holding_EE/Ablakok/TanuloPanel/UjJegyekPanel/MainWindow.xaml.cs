using System.Windows;

namespace JegyekPanel
{
    public partial class MainWindow : Window
    {
        public string UserName { get; set; } = "Felhasználó";

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
