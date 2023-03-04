using System.Data;

namespace ECommerceAPIs.Model
{
    public class Product
    {
        public int id { get; set; }
        public string productname { get; set; }
        public string productpicture { get; set; }
        public int productprice { get; set; }
        public string productdescription { get; set;}

       public Product()
        {

        }
        public Product(int id, string productname, string productpicture, int productprice, string productdescription)
        {
            this.id = id;
            this.productname = productname;
            this.productpicture = productpicture;
            this.productprice = productprice;
            this.productdescription = productdescription;
        }

    }
}
