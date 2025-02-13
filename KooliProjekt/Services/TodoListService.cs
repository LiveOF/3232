using KooliProjekt.Data;
using KooliProjekt.Search;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Services
{
    public class TodoListService : ITodoListService
    {
        private readonly ApplicationDbContext _context;

        public TodoListService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            await _context.TodoLists
                .Where(list => list.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<TodoList> Get(int id)
        {
            return await _context.TodoLists.FindAsync(id);
        }

        public async Task<PagedResult<TodoList>> List(int page, int pageSize, TodoListsSearch search = null)
        {
            var query = _context.TodoLists.AsQueryable();

            search = search ?? new TodoListsSearch();

            if (!string.IsNullOrWhiteSpace(search.Keyword))
            {
                query = query.Where(list => list.Title.Contains(search.Keyword));
            }

            if (search.Done != null)
            {
                query = query.Where(list => list.Items.Any());

                if (search.Done.Value)
                {
                    query = query.Where(list => list.Items.All(item => item.IsDone));
                }
                else
                {
                    query = query.Where(list => list.Items.Any(item => !item.IsDone));
                }
            }

            return await query
                .OrderBy(list => list.Title)
                .GetPagedAsync(page, pageSize);
        }

        public async Task Save(TodoList list)
        {
            if(list.Id == 0)
            {
                _context.TodoLists.Add(list);
            }
            else
            {
                _context.TodoLists.Update(list);
            }

            await _context.SaveChangesAsync();
        }
    }
}
