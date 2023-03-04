using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp4
{
    class Ulke
    {

        public int UlkeId { get; set; }
        public string UlkeAd { get; set; }
        public Ulke(int ulkeId,string ulkeAd) 
        {
        this.UlkeId = ulkeId;
        this.UlkeAd = ulkeAd;
        }
    }
}
