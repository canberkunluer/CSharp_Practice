using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace wpfapp3
{
    public class Kullanici
    {
        
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public bool MedeniHal { get; set; }
        public bool Cinsiyet { get; set; }
        public string ResimYol { get; set; }
        public Kullanici() { }
        public Kullanici(
            int id,
            string ad,
            string soyad,
            string email,
            bool? medeniHal,
            bool? cinsiyet,
            string resimYol)
        {
            this.Id = id;
            this.Ad = ad;
            this.Soyad = soyad;
            this.Email = email;
            this.MedeniHal = (bool)medeniHal;
            this.Cinsiyet = (bool)cinsiyet;
            this.ResimYol = resimYol;
        }
         
        
    }
}
