using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace seleniumwin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            btnrun.Click += Btnrun_Click;
        }

        private void Btnrun_Click(object sender, EventArgs e)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.google.com/";
            //https://www.google.com/search?q=cihanozhan
            var searchBox = driver.FindElement(By.Name("q"));
            Thread.Sleep(TimeSpan.FromSeconds(5));
            if (searchBox !=null)
            {
                searchBox.SendKeys("Canberk");
                searchBox.SendKeys(OpenQA.Selenium.Keys.Enter);
            }
            Thread.Sleep(TimeSpan.FromSeconds(5));
            driver.Quit();


        }
    }
}
