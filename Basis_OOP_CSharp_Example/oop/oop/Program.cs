using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {

        
       var result = Topla(5, 2);
        Console.WriteLine(Convert.ToInt32(result));
        
        Console.WriteLine(GetAccountName(2));
        Console.WriteLine(isValid("Canberk@"));
    }


    static bool isValid (string mail)
    {
        bool isValid = default(bool);
        if (mail.Contains("@"))
        {
            isValid = true;
        }
        return isValid;
    }
    static string GetAccountName(int accountID)
    {
        string accountname = string.Empty;
        switch (accountID)
        {
            case 1:
                accountname = "Canberk"
;                break;
                case 2:
                accountname = "Berken";
                break;
            default:
                accountname = "Belirsiz";
                break;
        }
        return accountname;
    }
  static void Bosluk (int satirsayisi)
    {
        for (int i = 0; i < satirsayisi; i++)
        {
            Console.WriteLine(Environment.NewLine);
        }
        
    }
    static int Topla(int a,int b) 
         {
       int sonuc=  a + b; 
         
        return sonuc;
    }
    static void Beklet()
    {
        Console.ReadLine();
    }
    static void Yaz()
    {
        string metin = Console.ReadLine();
        Console.WriteLine("Merhaba" + metin ); }


}