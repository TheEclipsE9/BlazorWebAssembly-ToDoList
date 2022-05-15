using BlazorWebAssembly.Server.Data;
using BlazorWebAssembly.Shared;
using Microsoft.AspNetCore.Mvc;
using BlazorWebAssembly.Client.Services.Enums;

namespace BlazorWebAssembly.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoListContext _dbContext;

        public ToDoController(ToDoListContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<List<ToDoItem>> GetAllToDoItems()
        {
            return Ok(_dbContext.ToDoItems.Where(x=>x.IsDone == false && x.IsDeleted == false));
        }
        [HttpGet]
        public ActionResult<List<ToDoItem>> GetAllDoneToDoItems()
        {
            return Ok(_dbContext.ToDoItems.Where(x => x.IsDone == true && x.IsDeleted == false));
        }
        [HttpGet]
        public ActionResult<List<ToDoItem>> GetAllDeletedToDoItems()
        {
            return Ok(_dbContext.ToDoItems.Where(x => x.IsDeleted == true));
        }

        [HttpPost]
        public async Task<ActionResult> CreateNewToDoItem(ToDoItem toDoItem)
        {
            _dbContext.Add(toDoItem);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> MarkAsDone(int id)
        {
            var toDoItem = _dbContext.ToDoItems.FirstOrDefault(x => x.Id == id);
            toDoItem.IsDone = true;
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> MarkAsDeleted(int id)
        {
            var toDoItem = _dbContext.ToDoItems.FirstOrDefault(x => x.Id == id);
            toDoItem.IsDeleted = true;
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("{deletetype}")]
        public async Task<ActionResult> DeleteAll(DeleteType deleteType)
        {
            var toDoItems = new List<ToDoItem>();
            switch (deleteType)
            {
                case DeleteType.IsDeleted:
                    toDoItems = _dbContext.ToDoItems.Where(x=>x.IsDeleted == true).ToList();
                    break;
                case DeleteType.IsDone:
                    toDoItems = _dbContext.ToDoItems.Where(x => x.IsDone == true).ToList();
                    break;
                case DeleteType.All:
                    toDoItems = _dbContext.ToDoItems.ToList();
                    break;
                default:
                    break;
            }

            _dbContext.RemoveRange(toDoItems);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
