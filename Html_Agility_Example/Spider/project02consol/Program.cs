using HtmlAgilityPack;
using project02consol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project02Console
{
    internal class Program
    {
        //1
        private static string dolarTitleXPath = "//div[@class='dovizBar mBot20']//a[1]//span[1]//span[1]";
        private static string dolarAlisXPath = "//div[@class='dovizBar mBot20']//a[1]//span[2]//span[2]";
        private static string dolarSatisXPath = "//div[@class='dovizBar mBot20']//a[1]//span[3]//span[2]";

        private static string euroTitleXPath = "//div[@class='dovizBar mBot20']//a[2]//span[1]//span[1]";
        private static string euroAlisXPath = "//div[@class='dovizBar mBot20']//a[2]//span[2]//span[2]";
        private static string euroSatisXPath = "//div[@class='dovizBar mBot20']//a[2]//span[3]//span[2]";

        private static string sterlinTitleXPath = "//div[@class='dovizBar mBot20']//a[3]//span[1]//span[1]";
        private static string sterlinAlisXPath = "//div[@class='dovizBar mBot20']//a[3]//span[2]//span[2]";
        private static string sterlinSatisXPath = "//div[@class='dovizBar mBot20']//a[3]//span[3]//span[2]";

        //2
        private static string dovizXPath = "//div[@class='dovizBar mBot20']//a";
        static void Main(string[] args)
        {
            List<Bigpara> list = new List<Bigpara>();
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://bigpara.hurriyet.com.tr/doviz/");


            #region part 01
            //var dolarTitle = doc.DocumentNode.SelectSingleNode(dolarTitleXPath).InnerText;
            //var dolarAlis = doc.DocumentNode.SelectSingleNode(dolarAlisXPath).InnerText;
            //var dolarSatis = doc.DocumentNode.SelectSingleNode(dolarSatisXPath).InnerText;

            //var euroTitle = doc.DocumentNode.SelectSingleNode(euroTitleXPath).InnerText;
            //var euroAlis = doc.DocumentNode.SelectSingleNode(euroAlisXPath).InnerText;
            //var euroSatis = doc.DocumentNode.SelectSingleNode(euroSatisXPath).InnerText;

            //var sterlinTitle = doc.DocumentNode.SelectSingleNode(sterlinTitleXPath).InnerText;
            //var sterlinAlis = doc.DocumentNode.SelectSingleNode(sterlinAlisXPath).InnerText;
            //var sterlinSatis = doc.DocumentNode.SelectSingleNode(sterlinSatisXPath).InnerText;

            //list.Add(new Bigpara()
            //{
            //    AlisFiyat = dolarAlis,
            //    SatisFiyat = dolarSatis,
            //    DovisTur = dolarTitle
            //});

            //list.Add(new Bigpara()
            //{
            //    AlisFiyat = euroAlis,
            //    SatisFiyat = euroSatis,
            //    DovisTur = euroTitle
            //});

            //list.Add(new Bigpara()
            //{
            //    AlisFiyat = sterlinAlis,
            //    SatisFiyat = sterlinSatis,
            //    DovisTur = sterlinTitle
            //});

            //foreach (var pere in list)
            //{
            //    Console.WriteLine(pere.DovisTur + " " + pere.AlisFiyat + " " + pere.SatisFiyat);
            //}

            #endregion

            #region part 02 
            var dovizTotal = doc.DocumentNode.SelectNodes(dovizXPath);

            foreach (var doviz in dovizTotal)
            {
                var dovizTitle = doviz.SelectSingleNode(".//span[1]//span[1]").InnerText;
                var dovizAlis = doviz.SelectSingleNode (".//span[2]//span[2]").InnerText;
                var dovizSatis = doviz.SelectSingleNode(".//span[3]//span[2]").InnerText;
                list.Add(new Bigpara()
                {
                    AlisFiyat = dovizAlis,
                    SatisFiyat = dovizSatis,
                    DovisTur  = dovizTitle
                });

            }
            foreach (var pere in list)
            {
                Console.WriteLine($"Döviz Tür : {pere.DovisTur} , Alış Fiyat : {pere.AlisFiyat} , Satış Fiyat : {pere.SatisFiyat}");
            }

            Console.ReadLine();


            #endregion




        }
    }
}