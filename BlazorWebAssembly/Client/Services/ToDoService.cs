using BlazorWebAssembly.Client.Services.Enums;
using BlazorWebAssembly.Shared;
using System.Net.Http.Json;

namespace BlazorWebAssembly.Client.Services
{
    public class ToDoService : IToDoService
    {
        private readonly HttpClient _httpClient;

        public ToDoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ToDoItem>> GetAllToDoItems()
        {
            return await _httpClient.GetFromJsonAsync<List<ToDoItem>>("api/ToDo/GetAllToDoItems");
        }

        public async Task CreateToDoItem(ToDoItem toDoItem)
        {
            await _httpClient.PostAsJsonAsync("api/ToDo/CreateNewToDoItem", toDoItem);
        }

        public async Task MarkAsDone(ToDoItem toDoItem)
        {
            await _httpClient.PutAsJsonAsync($"api/ToDo/MarkAsDone/{toDoItem.Id}", toDoItem);
        }

        public async Task MarkAsDeleted(ToDoItem toDoItem)
        {
            await _httpClient.PutAsJsonAsync($"api/ToDo/MarkAsDeleted/{toDoItem.Id}", toDoItem);
        }

        public async Task<List<ToDoItem>> GetAllDoneToDoItems()
        {
            return await _httpClient.GetFromJsonAsync<List<ToDoItem>>("api/ToDo/GetAllDoneToDoItems");
        }

        public async Task<List<ToDoItem>> GetAllDeletedToDoItems()
        {
            return await _httpClient.GetFromJsonAsync<List<ToDoItem>>("api/ToDo/GetAllDeletedToDoItems");
        }

        public async Task DeleteAll(DeleteType deleteType)
        {
            await _httpClient.DeleteAsync($"api/ToDo/DeleteAll/{deleteType}");
        }
    }
}
