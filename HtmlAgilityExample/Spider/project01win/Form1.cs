using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace project01win
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            btngetdata.Click += Btngetdata_Click;
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Btngetdata_Click(object sender, EventArgs e)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load("https://www.worldometers.info/coronavirus/country/turkey/");
            var header2 = document.DocumentNode.SelectSingleNode("//h1").InnerText;

            var header = document.DocumentNode.SelectSingleNode("//*[@id=\"maincounter-wrap\"]/h1").InnerText;
            var header3 = document.DocumentNode.SelectSingleNode("//*[@id=\"maincounter-wrap\"]//div[@class='maincounter-number']").InnerText;

            var header4 = document.DocumentNode.SelectSingleNode("//*[@id=\"maincounter-wrap[1]\"]/h1").InnerText;

            // MessageBox.Show(header2.ToString());
            listBox1.Items.Add(header2);
            listBox1.Items.Add(header + header3);

            listBox1.Items.Add(header4);


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
