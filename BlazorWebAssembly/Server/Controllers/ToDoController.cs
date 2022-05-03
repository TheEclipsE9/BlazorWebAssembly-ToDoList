using BlazorWebAssembly.Server.Data;
using BlazorWebAssembly.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebAssembly.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoListContext _dbContext;

        public ToDoController(ToDoListContext dbContext)
        {
            _dbContext = dbContext;
        }

        //[HttpGet("{url}")]
        [HttpGet]
        [Route("{url}")]
        public ActionResult<ToDoItem> GetToDoItemByUrl(string url)
        {
            var toDoItem = _dbContext.ToDoItems.FirstOrDefault(x => x.Url == url);
            if (toDoItem == null)
            {
                return NotFound("Item not found!");
            }
            return Ok(toDoItem);
        }

        [HttpGet]
        public ActionResult<List<ToDoItem>> GetAllToDoItems()
        {
            return Ok(_dbContext.ToDoItems);
        }
    }
}
