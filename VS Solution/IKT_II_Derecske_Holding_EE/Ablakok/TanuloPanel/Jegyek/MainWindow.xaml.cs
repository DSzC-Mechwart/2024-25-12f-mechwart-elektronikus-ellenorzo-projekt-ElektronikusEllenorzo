using System.Collections.ObjectModel;
using System.Windows;

namespace Jegyek
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Student> Students { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Students = new ObservableCollection<Student>();

            DataContext = Students;

            felhasznaloNev.Text = " ";
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }

    public class Student
    {
        public string tantargy { get; set; }
        public string[] honapok { get; set; }
    }
}
