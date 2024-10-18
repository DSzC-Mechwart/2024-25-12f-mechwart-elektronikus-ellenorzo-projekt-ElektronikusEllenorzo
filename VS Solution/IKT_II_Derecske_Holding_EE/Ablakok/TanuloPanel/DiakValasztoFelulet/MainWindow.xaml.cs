using System.ComponentModel;
using System.Windows;

namespace LoginInterface
{
    public partial class DiakValasztoFelulet : Window, INotifyPropertyChanged
    {
        private string _userName = "Szabó Balázs";

        public event PropertyChangedEventHandler PropertyChanged;

        public string UserName
        {
            get => _userName;
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged(nameof(UserName));
                }
            }
        }

        public DiakValasztoFelulet()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
