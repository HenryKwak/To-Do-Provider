using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoProvider.Models;

namespace ToDoProvider.Repository
{
    public interface IToDoProvider
    {
        Task<IEnumerable<ToDoItemViewModel>> GetToDosAsync();
        Task<ToDoItemViewModel> GetToDoAsync(int id);
        Task AddToDoAsync(ToDoItemViewModel item);
        Task UpdateToDoAsync(ToDoItemViewModel item);
        Task DeleteToDoAsync(int id);
    }
}