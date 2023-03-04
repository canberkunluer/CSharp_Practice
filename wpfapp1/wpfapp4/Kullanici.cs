using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp4
{
    class Kullanici
    {
        public int KullaniciId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string KullaniciAd { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public Adres Adres { get; set; }
        public bool Aktif { get; set; }

        public bool SozlesmeOnay { get; set; }
    }
}
