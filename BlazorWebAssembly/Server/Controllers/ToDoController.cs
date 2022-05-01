using BlazorWebAssembly.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebAssembly.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private List<ToDoItem> ToDoItems = new List<ToDoItem>
        {
            new ToDoItem { Url = "gotothesupermarket", Title = "Go to the supermarket", Description = "Buy a bread" },
            new ToDoItem { Url = "gototheGym", Title = "Go to the gym", Description = "from 8.00 to 9.00" }
        };

        //[HttpGet("{url}")]
        [HttpGet]
        [Route("{url}")]
        public ActionResult<ToDoItem> GetToDoItemByUrl(string url)
        {
            var toDoItem = ToDoItems.FirstOrDefault(x => x.Url == url);
            if (toDoItem == null)
            {
                return NotFound("Item not found!");
            }
            return Ok(toDoItem);
        }

        [HttpGet]
        public ActionResult<List<ToDoItem>> GetAllToDoItems()
        {
            return Ok(ToDoItems);
        }
    }
}
