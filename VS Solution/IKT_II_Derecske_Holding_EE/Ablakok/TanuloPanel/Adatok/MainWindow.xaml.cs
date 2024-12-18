using System;
using System.ComponentModel;
using System.Windows;

namespace LoginInterface
{
    public partial class Adatok : Window, INotifyPropertyChanged
    {
        public Adatok()
        {
            InitializeComponent();
            DataContext = this;
        }

        private string _userName = "Szabó Balázs";
        private DateTime _birthDate = new DateTime(2007, 1, 1);
        private string _birthPlace = "Debrecen";
        private string _mothersName = "Szabó Ilona";
        private string _dormitory = "Nincs";

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

        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                if (_birthDate != value)
                {
                    _birthDate = value;
                    OnPropertyChanged(nameof(BirthDate));
                }
            }
        }

        public string BirthPlace
        {
            get => _birthPlace;
            set
            {
                if (_birthPlace != value)
                {
                    _birthPlace = value;
                    OnPropertyChanged(nameof(BirthPlace));
                }
            }
        }

        public string MothersName
        {
            get => _mothersName;
            set
            {
                if (_mothersName != value)
                {
                    _mothersName = value;
                    OnPropertyChanged(nameof(MothersName));
                }
            }
        }

        public string Dormitory
        {
            get => _dormitory;
            set
            {
                if (_dormitory != value)
                {
                    _dormitory = value;
                    OnPropertyChanged(nameof(Dormitory));
                }
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnEditButtonClick(object sender, RoutedEventArgs e)
        {
            bool isReadOnly = AddressTextBox.IsReadOnly;

            AddressTextBox.IsReadOnly = !isReadOnly;
            BirthDatePicker.IsEnabled = !isReadOnly; 
            BirthPlaceTextBox.IsReadOnly = !isReadOnly;
            MothersNameTextBox.IsReadOnly = !isReadOnly;
            DormitoryTextBox.IsReadOnly = !isReadOnly;
            ClassTextBox.IsReadOnly = !isReadOnly;
            SpecializationTextBox.IsReadOnly = !isReadOnly;

            SaveButton.IsEnabled = !isReadOnly;
            UndoButton.IsEnabled = !isReadOnly;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
