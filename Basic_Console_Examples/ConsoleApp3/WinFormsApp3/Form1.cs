using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Net;
using System.Threading;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using Ionic.Zip;
namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            label5.Enabled = false;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
           
           
            using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
            {
                zip.AddFile("C:\\Users\\Z004PUCC\\source\\repos\\ConsoleApp3\\WinFormsApp3\\deneme.txt");
                zip.Save("C:\\Users\\Z004PUCC\\source\\repos\\ConsoleApp3\\WinFormsApp3\\deneme.zip");
            }
            Thread th1 = new Thread(Doldur02);
            th1.Start();
            
            Thread th = new Thread(Doldur01);
            th.Start();

            //   Doldur01();


        }
        private void Doldur01()
        {
            Thread.Sleep(3000);

            for (int i = 0; i < 100000001; i++)
            {
                progressBar2.Value = i / 1000000;
                
            }
            label5.Enabled = true;
            label5.Text = "İşlem tamamlandı";

        }
        private void Doldur02()
        {
            
            for (int i = 0; i < 100000001; i++)
            {
                progressBar1.Value = ( i / 1000000)/200000;
            }
            
            label6.Text = "Sıkıştırılıyor....";
            

        }
      

    }
}