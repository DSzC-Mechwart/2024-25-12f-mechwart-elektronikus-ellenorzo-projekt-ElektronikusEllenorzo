using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Chalk
{
    internal class MainVM
    {
        public ObservableCollection<Tanulo> Tanulok { get; set; }

        public MainVM() {
            Tanulok = new ObservableCollection<Tanulo>();
            try
            {

                using (StreamReader sr = new StreamReader("Tanulok.txt"))
                {

                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var sor = line.Split(";");
                        Tanulok.Add(new Tanulo(sor[0], sor[1], DateOnly.Parse(sor[2]), sor[3], sor[4], DateOnly.Parse(sor[5]), sor[6], sor[7], bool.Parse(sor[8]), sor[9]));
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
