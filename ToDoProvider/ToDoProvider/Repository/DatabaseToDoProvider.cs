using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoProvider.Models;

namespace ToDoProvider.Repository
{
    public class DatabaseToDoProvider : IToDoProvider
    {
        private readonly AppDbContext _context;

        public DatabaseToDoProvider(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ToDoItemViewModel>> GetToDosAsync()
        {
            return await Task.FromResult(_context.ToDoItems.ToList());
        }

        public async Task<ToDoItemViewModel> GetToDoAsync(int id)
        {
            return await Task.FromResult(_context.ToDoItems.SingleOrDefault(t => t.Id == id));
        }

        public async Task AddToDoAsync(ToDoItemViewModel item)
        {
            _context.ToDoItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateToDoAsync(ToDoItemViewModel item)
        {
            var existingItem = _context.ToDoItems.SingleOrDefault(t => t.Id == item.Id);
            if (existingItem != null)
            {
                existingItem.Task = item.Task;
                existingItem.IsCompleted = item.IsCompleted;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteToDoAsync(int id)
        {
            var item = _context.ToDoItems.SingleOrDefault(t => t.Id == id);
            if (item != null)
            {
                _context.ToDoItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}