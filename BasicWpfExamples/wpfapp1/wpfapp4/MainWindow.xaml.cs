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

namespace wpfapp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string ad="", 
            soyad="",
            kullaniciAd="",
            email="",
            sifre="" , 
            acikAdres="",
            adres1="";
        bool aktif =false, sozlesme=false;
        Ulke ulke = null;
        Sehir sehir = null;
       
        
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            btnKaydet.Click += BtnKaydet_Click;
        }
        
        private void BtnKaydet_Click(object sender, RoutedEventArgs e)
        {
            GetDataFromUser();
            Adres adres = new Adres();
            adres.Ulke = ulke;
            adres.Sehir = sehir;
            adres.AcikAdres = acikAdres;

            Kullanici kullanici = new Kullanici();
            kullanici.Ad = ad;
            kullanici.Soyad = soyad;
            kullanici.Adres = adres;
            kullanici.Email = email;
            kullanici.KullaniciAd = kullaniciAd;
            kullanici.Sifre = sifre;
            kullanici.Aktif = aktif;
            kullanici.SozlesmeOnay = sozlesme;
            MessageBox.Show(kullanici.Adres.Sehir.SehirAd);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            cmbUlkeler.ItemsSource = UlkeleriGetir();
            cmbUlkeler.DisplayMemberPath = "UlkeAd";
            cmbUlkeler.SelectedValuePath = "UlkeId";
            cmbSehirler.ItemsSource = SehirleriGetir();
            cmbSehirler.DisplayMemberPath = "SehirAd";
            cmbSehirler.SelectedValuePath = "SehirId";
        }

        List<Ulke> UlkeleriGetir()
        {
            List<Ulke> Ulkeler = new List<Ulke>();
            Ulkeler.Add(new Ulke(1, "Türkiye"));
            Ulkeler.Add(new Ulke(2, "Azerbaycan"));
            Ulkeler.Add(new Ulke(3, "Türkmenistan"));
            return Ulkeler;
        }
        List<Sehir> SehirleriGetir()
        {
            List<Sehir> Sehirler = new List<Sehir>();
            Sehirler.Add(new Sehir(1, "İstanbul"));
            Sehirler.Add(new Sehir(2, "Ankara"));
            Sehirler.Add(new Sehir(3, "Antalya"));
            return Sehirler;
        }
        public void GetDataFromUser()
        {
             ad = txtAd.Text;
             soyad = txtSoyad.Text;
             kullaniciAd = txtKullaniciAd.Text;
             email = txtEmail.Text;
             sifre = txtSifre.Password;
             aktif = (bool)chckAktif.IsChecked ? true : false;
             sozlesme = (bool)chckSozlesme.IsChecked ? true : false;

            //adres bilgilerini al
           
            if(cmbUlkeler.SelectedItem != null)
            {
                ulke = (Ulke)cmbUlkeler.SelectedItem;
            }
            if (cmbSehirler.SelectedItem != null)
            {
                sehir = (Sehir)cmbSehirler.SelectedItem;
            }
            



        }
    }
}
