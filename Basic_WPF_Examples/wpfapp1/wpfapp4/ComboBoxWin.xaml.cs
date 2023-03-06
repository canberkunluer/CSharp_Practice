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

namespace wpfapp4
{
    /// <summary>
    /// Interaction logic for ComboBoxWin.xaml
    /// </summary>
    public partial class ComboBoxWin : Window
    {
        public ComboBoxWin()
        {
            InitializeComponent();
            this.Loaded += ComboBoxWin_Loaded;
            cmbSehirler.SelectionChanged += CmbSehirler_SelectionChanged;
        }

        private void CmbSehirler_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sehir sehir = (Sehir)((ComboBox)sender).SelectedItem;
            MessageBox.Show(sehir.SehirAd + "" + sehir.SehirID);
        }

        private void ComboBoxWin_Loaded(object sender, RoutedEventArgs e)
        {
            List<Sehir> Sehirler = new List<Sehir>();
            Sehirler.Add(new Sehir(1, "Adana"));
            Sehirler.Add(new Sehir(6, "Ankara"));
            Sehirler.Add(new Sehir(25, "Erzurum"));
            Sehirler.Add(new Sehir(34, "İstanbul"));

            cmbSehirler.ItemsSource = Sehirler;
            cmbSehirler.DisplayMemberPath = "SehirAd";
            cmbSehirler.SelectedValuePath = "SehirId";

            

        }
    }
}
