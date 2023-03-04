using linqconsol;
using System.Net;
using static System.Net.Mime.MediaTypeNames;
class Program:Kayit
{
    static void Main(string[] args)
    {
        #region Başarılı Öğrenciler
        var Ogrenciler = OgrencileriGetir();
        var BasariliOgrenciler = Ogrenciler.Where(Ogrenci => Ogrenci.Basarili);
        Console.WriteLine("Başarılı öğrenciler");
        foreach (var Ogrenci in BasariliOgrenciler)
        {
            Console.WriteLine("{0}, {1}", Ogrenci.Soyadi, Ogrenci.Adi);
        }
        Console.ReadLine();
        #endregion
        #region 1.Sınıftaki Başarılı Öğrenciler
        //var Ogrenciler = OgrencileriGetir();
        //var BasariliOgrenciler = Ogrenciler.Where(Ogrenci => Ogrenci.Basarili && Ogrenci.Sinif == 1);
        //Console.WriteLine("1. Sınıftaki Başarılı Öğrenciler");
        //foreach (var Ogrenci in BasariliOgrenciler)
        //{
        //    Console.WriteLine("{1}, {0}", Ogrenci.Soyadi, Ogrenci.Adi);
        //}
        //Console.ReadLine();
        #endregion
        #region Ortalaması 55ten Yüksek Öğrenciler
        //var Ogrenciler = OgrencileriGetir();
        //var BasariliOgrenciler = from Ogrenci in Ogrenciler
        //                         where Ogrenci.Basarili
        //                         select Ogrenci;
        //Console.WriteLine("Başarılı Öğrencilerin Notları");
        //foreach (var Ogrenci in BasariliOgrenciler)
        //{
        //    Console.WriteLine("{1} {0}", Ogrenci.Soyadi, Ogrenci.Adi);
        //    foreach (var Notu in Ogrenci.Notlar)
        //    {
        //        Console.Write("{0} ", Notu);
        //    }
        //    Console.WriteLine();
        //}
        //Console.ReadLine();

        #endregion



    }

}