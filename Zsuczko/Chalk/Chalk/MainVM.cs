using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Chalk
{
    internal class MainVM : INotifyPropertyChanged
    {
        public ObservableCollection<Tanulo> Tanulok { get; set; }

        public MainVM() {
            Tanulok = new ObservableCollection<Tanulo>();
            try
            {

                using (StreamReader sr = new StreamReader("Tanulok.csv"))
                {

                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var sor = line.Split(";");
                        Tanulok.Add(new Tanulo(sor[0], sor[1], sor[2], DateOnly.Parse(sor[3]), sor[4], sor[5], DateOnly.Parse(sor[6]), sor[7], sor[8], bool.Parse(sor[9]), sor[10]));
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
