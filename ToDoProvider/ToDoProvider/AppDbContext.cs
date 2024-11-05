  using Microsoft.EntityFrameworkCore;
using ToDoProvider.Models;

namespace ToDoProvider
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ToDoItemViewModel> ToDoItems { get; set; }
    }
}
