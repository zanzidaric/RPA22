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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Povezovanje
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Podatki> vsiPodatki = new List<Podatki>();
        CollectionViewSource podatkiViewSource;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            podatkiViewSource =(CollectionViewSource) FindResource("podatkiViewSource");
            StreamReader sr = new StreamReader(@"d:\RPA22\vaja.csv");
            String vrstica = sr.ReadLine();
            while(vrstica!=null)
            {
                string[] p = vrstica.Split(';');//celo vrstico razdelim na podatke
                Podatki po = new Podatki();
                po.Id = int.Parse(p[0]);
                po.Datum = DateTime.Parse(p[1]);
                po.Ime = p[2];
                po.Znesek = double.Parse(p[3]);
                vsiPodatki.Add(po);
                vrstica = sr.ReadLine();
            }
            sr.Close();
            DataContext = this;
            podatkiViewSource.Source = vsiPodatki;
        }
    }
}
