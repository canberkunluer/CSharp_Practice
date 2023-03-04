using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlform2.Business
{
    
    internal class Shipper
    {
        public int ShipperID { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }

        public Shipper ()
        {

        }
        public Shipper(int shipperID,string companyName, string phone)
        {
            ShipperID = shipperID;
            CompanyName = companyName;
            Phone = phone;
        }


    }
}
