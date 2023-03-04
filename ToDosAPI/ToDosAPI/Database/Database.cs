namespace ToDosAPI.Database
{
    public class Database
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