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

        public async Task<ToDoItem> GetToDoItemByUrl(string url)
        {
            return await _httpClient.GetFromJsonAsync<ToDoItem>($"api/ToDo/{url}");
        }

        public async Task<List<ToDoItem>> GetAllToDoItems()
        {
            return await _httpClient.GetFromJsonAsync<List<ToDoItem>>("api/ToDo");
        }
    }
}
