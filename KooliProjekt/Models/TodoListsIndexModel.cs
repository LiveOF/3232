using KooliProjekt.Data;
using KooliProjekt.Search;

namespace KooliProjekt.Models
{
    public class TodoListsIndexModel
    {
        public TodoListsSearch Search { get; set; }
        public PagedResult<TodoList> Data { get; set; }
    }
}
