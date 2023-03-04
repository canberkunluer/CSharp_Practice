using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Net;
using ToDosAPI.Models;


namespace ToDosAPI.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class ToDoListController : ControllerBase 
    {
        Database.ToDoListDAL todolistdal = new Database.ToDoListDAL();
        [HttpGet]
        public List<ToDoList> Get()   // GET methoduyla beraber listemizi çekiyoruz
        {
            return todolistdal.GetSql();
        }
        [HttpGet("{id}")]
        public List<ToDoList> Get(int id)  // GET methodunu kullanarak sadece o id'ye karşılık gelen veriyi çekiyoruz
        {
            return todolistdal.GetSql(id);
        }
        [HttpPost]
        public void Post(ToDoList todo)  //todo listesine POST methoduyla beraber yeni bir veri kaydediyoruz.
        {
           todolistdal.Add(todo.Id,todo.todo,todo.status);
        }
        [HttpPut]
        public void Put(ToDoList todo) // idye karşılık gelen listedeki verileri güncellemek için kullanır
        {
            todolistdal.Update(todo.Id, todo.todo, todo.status);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)  //Listede id'ye karşılık geleni siler
        {
                todolistdal.Delete(id);
        }
      

      

    }
}
