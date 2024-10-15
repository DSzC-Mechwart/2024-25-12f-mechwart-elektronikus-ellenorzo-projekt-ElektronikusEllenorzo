using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using IKT_II_Derecske_Holding_EE.Models;
using IKT_II_Derecske_Holding_EE.API_Data;
using IKT_II_Derecske_Holding_EE.Ablakok.Stilus;
using System.Collections.ObjectModel;

namespace IKT_II_Derecske_Holding_EE.Ablakok.Login
{
    /// <summary>
    /// Interaction logic for LoginPanel.xaml
    /// </summary>
    public partial class LoginPanel : UserControl
    {
        SzerverAdatok SzerverAdatok;
        TanarSzerverAdatok TanarSzerverAdatok;
        public LoginPanel()
        {
            SzerverAdatok = new SzerverAdatok();
            TanarSzerverAdatok = new TanarSzerverAdatok();
            InitializeComponent();
            elsoBtn.Click += (s, e) => { tabs.SelectedIndex = 0; };
            masodikBtn.Click += (s, e) => { tabs.SelectedIndex = 1; };
            TanarSzerverAdatok.TanulokLekerdezve += () => { TestGrid.ItemsSource = TanarSzerverAdatok.Tanulok; };
            TanarSzerverAdatok.OsztalyJegyekLekerdezve += () =>
            {
                jegyekNew.ItemsSource = TanarSzerverAdatok.TesztJegy;
            };
            /*TanarSzerverAdatok.OsztalyJegyekLekerdezve += () => {
                List<TanuloJegyek> haviJegyek = new List<TanuloJegyek>();

                foreach (var tanulo in TanarSzerverAdatok.Tanulok)
                {
                    TanuloJegyek tanuloJegyek = new TanuloJegyek();
                    List<ObservableCollection<Jegy>> jegyHavonta = [];
                    tanuloJegyek.TanuloNev = tanulo.Nev;
                    tanuloJegyek.Oktober = new(TanarSzerverAdatok.OsztalyJegyek.Where(x => x.Tanulo_ID == tanulo.ID).ToList());
                    /*jegyHavonta.Add(tanuloJegyek.Januar);
                    jegyHavonta.Add(tanuloJegyek.Februar);
                    jegyHavonta.Add(tanuloJegyek.Marcius);
                    jegyHavonta.Add(tanuloJegyek.Aprilis);
                    jegyHavonta.Add(tanuloJegyek.Majus);
                    jegyHavonta.Add(tanuloJegyek.Junius);
                    jegyHavonta.Add([]);
                    jegyHavonta.Add([]);
                    jegyHavonta.Add(tanuloJegyek.Szeptember);
                    jegyHavonta.Add(tanuloJegyek.Oktober);
                    jegyHavonta.Add(tanuloJegyek.November);
                    jegyHavonta.Add(tanuloJegyek.December);
                    MessageBox.Show($"{jegyHavonta.Count}");
                    List<Jegy> jegyei = TanarSzerverAdatok.OsztalyJegyek.Where(x => x.Tanulo_ID == tanulo.ID).ToList();
                    var havonta = jegyei.GroupBy(x => x.Datum.Month).ToDictionary(x => x.Key, g => g.ToList());
                    MessageBox.Show($"{havonta[10].Count()}");
                    for ( int i = 9; i < 13; i++ )
                    {
                        if (havonta.ContainsKey(i))
                        {
                            var now = havonta[i].ToList();
                            jegyHavonta[i - 1] = new(now);
                            continue;
                        }
                        jegyHavonta[i - 1] = [];
                    }
                    for (int i = 1; i < 7; i++)
                    {
                        if (havonta.ContainsKey(i))
                        {
                            var now = havonta[i].ToList();
                            jegyHavonta[i - 1] = new(now);
                            continue;
                        }
                        jegyHavonta[i - 1] = [];
                    }
                    haviJegyek.Add(tanuloJegyek);
                }
                JegyekGrid.ItemsSource = haviJegyek;
            };*/
        }

    }
}
