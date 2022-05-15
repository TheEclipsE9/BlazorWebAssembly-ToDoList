using BlazorWebAssembly.Shared;

namespace BlazorWebAssembly.Client.Services
{
    public interface IToDoService
    {
        Task<List<ToDoItem>> GetAllToDoItems();
        Task<List<ToDoItem>> GetAllDoneToDoItems();
        Task<List<ToDoItem>> GetAllDeletedToDoItems();
        Task CreateToDoItem(ToDoItem toDoItem);
        Task MarkAsDone(ToDoItem toDoItem);
        Task MarkAsDeleted(ToDoItem toDoItem);
    }
}
