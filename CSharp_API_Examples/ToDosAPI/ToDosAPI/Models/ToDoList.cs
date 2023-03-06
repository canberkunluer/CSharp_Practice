namespace ToDosAPI.Models
{
    public class ToDoList
    {
        public int Id { get; set; }
        public string todo { get; set; }
        public Boolean status { get; set; }

        public ToDoList()
        {

        }
        public ToDoList(int ıd, string todo, bool status)
        {
            Id = ıd;
            this.todo = todo;
            this.status = status;
        }
    }
}
