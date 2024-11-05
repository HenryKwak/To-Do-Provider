using ToDoProvider.Repository;

namespace ToDoProvider.Repository
{
    public class ToDoProviderFactory
    {
        private readonly AppDbContext _context;

        public ToDoProviderFactory(AppDbContext context)
        {
            _context = context;
        }

        public IToDoProvider GetProvider(string providerType)
        {
            return providerType switch
            {
                "Database" => new DatabaseToDoProvider(_context),
                "InMemory" => new InMemoryToDoProvider(),
                _ => throw new ArgumentException("Invalid provider type")
            };
        }
    }
}