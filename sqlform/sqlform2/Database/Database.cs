
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace sqlform2.Database
{
    internal class Database
    {
        public static string GetCOnnectionString
        {
             get
            {
                return "Data Source =.; Initial Catalog = Northwind; Integrated Security = SSPI";
            }
        }
    }
}
