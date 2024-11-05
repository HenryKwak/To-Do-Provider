using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoProvider.Models;
using ToDoProvider.Repository;

namespace ToDoProvider.Controllers
{
    [Route("api/todo")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoProviderFactory _providerFactory;

        public ToDoController(ToDoProviderFactory providerFactory)
        {
            _providerFactory = providerFactory;
        }

        private IToDoProvider GetProvider(string providerType)
        {
            return _providerFactory.GetProvider(providerType);
        }

        [HttpGet("GetList")]
        public async Task<ActionResult<IEnumerable<ToDoItemViewModel>>> Get(string providerType)
        {
            var provider = GetProvider(providerType);
            var items = await provider.GetToDosAsync();
            return Ok(items);
        }

        [HttpPost("AddTask")]
        public async Task<ActionResult> Post(string providerType, ToDoItemViewModel item)
        {
            var provider = GetProvider(providerType);
            await provider.AddToDoAsync(item);
            return CreatedAtAction(nameof(Get), new { providerType, id = item.Id }, item);
        }

        [HttpPut("EditTask")]
        public async Task<IActionResult> Put(string providerType, int id, ToDoItemViewModel item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            var provider = GetProvider(providerType);
            await provider.UpdateToDoAsync(item);
            return NoContent();
        }

        [HttpDelete("DeleteTask")]
        public async Task<IActionResult> Delete(string providerType, int id)
        {
            var provider = GetProvider(providerType);
            await provider.DeleteToDoAsync(id);
            return NoContent();
        }

        [HttpGet("SearchTasks")]
        public async Task<ActionResult<IEnumerable<ToDoItemViewModel>>> Search(string providerType, string? query)
        {
            var provider = GetProvider(providerType);
            var items = await provider.GetToDosAsync();
            if (string.IsNullOrWhiteSpace(query))
            {
                return Ok(items);
            }
            var filteredItems = items.Where(t => t.Task.Contains(query, StringComparison.OrdinalIgnoreCase));
            return Ok(filteredItems);
        }
    }
}
