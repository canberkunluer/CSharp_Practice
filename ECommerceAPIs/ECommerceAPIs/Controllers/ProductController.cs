using ECommerceAPIs.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPIs.Controllers
{
    [ApiController]

    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
      public static  List<Product> products = new List<Product>
        {
            new Product{id=1,productname="Acer",productpicture="//DosyaKonumu",productprice=100,productdescription="128GB"},
            new Product{id=2,productname="Macbook",productpicture="//DosyaKonumu",productprice=200,productdescription="256GB"},
            new Product{id=3,productname="Hp",productpicture="//DosyaKonumu",productprice=300,productdescription="512GB"}
        };
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()   // GET methoduyla beraber listemizi çekiyoruz
        {
            return Ok(products);
        }
        [HttpGet("{id:int}", Name = "Get")]

        public ActionResult<IEnumerable<Product>> Get(int id)  // GET methodunu kullanarak sadece o id'ye karşılık gelen veriyi çekiyoruz
        {
            return products.FindAll(x => x.id == id);
        }
        [HttpPost]
        public ActionResult<Product>  Post([FromBody] Product _product)  //todo listesine POST methoduyla beraber yeni bir veri kaydediyoruz.
        {
            products.Add(_product);
            return CreatedAtRoute("Get", new { id = _product.id }, _product);
        }
        [HttpPut("{id:int}")]
        public IEnumerable<Product> Put(int id , [FromBody] Product _product) // idye karşılık gelen listedeki verileri güncellemek için kullanır
        {
            Product productupdate = products.Find(x => x.id==id);
            int index = products.IndexOf(productupdate);
            products[index].id = id;
            products[index].productname = _product.productname;
            products[index].productpicture = _product.productpicture;
            products[index].productprice = _product.productprice;
            products[index].productdescription= _product.productdescription;
            return products;
        }




    }
}
