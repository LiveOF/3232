namespace KooliProjekt.Data
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public bool IsDone { get; set; }

        public TodoList TodoList { get; set; }
        public int TodoListId { get; set; }
    }
}
