using BlazorWebAssembly.Shared;

namespace BlazorWebAssembly.Client.Services
{
    public interface IToDoService
    {
        Task<ToDoItem> GetToDoItemByUrl(string url);
        Task<List<ToDoItem>> GetAllToDoItems();
    }
}
