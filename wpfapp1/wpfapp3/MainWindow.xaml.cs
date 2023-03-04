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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Intrinsics.Arm;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace wpfapp3
{ 
    //IDYI RANDOM OLARAK SAYI ÜRET DEĞİŞTİRİLMEZ YAP
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["NWConnStr"].ConnectionString);
        public MainWindow()
        {
            
            this.Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        private void kaydet_Click(object sender, RoutedEventArgs e)
        {
            VerileriYaz();
            VerileriOku();
        }
        private void goster_Click_1(object sender, RoutedEventArgs e)
        {
            VerileriOku();
        }
        void VerileriYaz()
        {
            string sql = "INSERT INTO Kullanici (ID,Ad,Soyad,Email2,MedeniHal,Cinsiyet,DatePicker,Aktif) VALUES  (" + textBoxId.Text + ",'" + textBoxName.Text + "','" + textBoxSurname.Text + "','" + textBoxEmail.Text + "','" + CheckBoxMedeni.Text + "','" + CheckBoxCinsiyet.Text + "','" + DatePicker.ToString() + "','" + CheckBoxUyelik.IsChecked + "')";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                conn.Open();
                cmd.ExecuteNonQuery();
                // = textBoxName.Text.ToString() + "  İsimli Kayıt Başarıyla Eklendi.";
                labelsonuc.Content = textBoxName.Text.ToString() + "  İsimli Kayıt Başarıyla Eklendi.";
                conn.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        void VerileriOku()
        {
            {
                string CmdString = "SELECT ID, Ad,Soyad,Email2,MedeniHal,Cinsiyet,DatePicker FROM Kullanici;";
                try
                {
                    SqlCommand cmd = new SqlCommand(CmdString, conn);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("");
                    sda.Fill(dt);
                    dg.ItemsSource = dt.DefaultView;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
    }



