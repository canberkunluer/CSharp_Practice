using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp4
{
    class Sehir
    {
        public int SehirID { get; set; }
        public string SehirAd { get; set; }

        public Sehir(int sehirid,string sehirad) 
        {
            this.SehirID = sehirid;
            this.SehirAd = sehirad;
        }
    }
}
