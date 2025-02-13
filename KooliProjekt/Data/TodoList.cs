namespace KooliProjekt.Data
{
    public class TodoList
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public IList<TodoItem> Items { get; set; }
    
        public TodoList()
        {
            Items = new List<TodoItem>();
        }
    }
}