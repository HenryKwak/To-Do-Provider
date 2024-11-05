using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoProvider.Models;
using ToDoProvider.Repository;

namespace ToDoProvider.Repository
{
    public class InMemoryToDoProvider : IToDoProvider
    {
        private readonly List<ToDoItemViewModel> _toDoItems = new();

        public Task<IEnumerable<ToDoItemViewModel>> GetToDosAsync()
        {
            return Task.FromResult(_toDoItems.AsEnumerable());
        }

        public Task<ToDoItemViewModel> GetToDoAsync(int id)
        {
            return Task.FromResult(_toDoItems.SingleOrDefault(t => t.Id == id));
        }

        public Task AddToDoAsync(ToDoItemViewModel item)
        {
            _toDoItems.Add(item);
            return Task.CompletedTask;
        }

        public Task UpdateToDoAsync(ToDoItemViewModel item)
        {
            var existingItem = _toDoItems.SingleOrDefault(t => t.Id == item.Id);
            if (existingItem != null)
            {
                existingItem.Task = item.Task;
                existingItem.IsCompleted = item.IsCompleted;
            }
            return Task.CompletedTask;
        }

        public Task DeleteToDoAsync(int id)
        {
            var item = _toDoItems.SingleOrDefault(t => t.Id == id);
            if (item != null)
            {
                _toDoItems.Remove(item);
            }
            return Task.CompletedTask;
        }
    }
}