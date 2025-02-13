using KooliProjekt.Data;
using KooliProjekt.Search;

namespace KooliProjekt.Services
{
    public interface ITodoListService
    {
        Task<PagedResult<TodoList>> List(int page, int pageSize, TodoListsSearch query = null);
        Task<TodoList> Get(int id);
        Task Save(TodoList list);
        Task Delete(int id);    
    }
}