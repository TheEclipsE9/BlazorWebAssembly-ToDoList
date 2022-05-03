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
            var result = await _httpClient.GetAsync($"api/ToDo/{url}");

            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var message = await result.Content.ReadAsStringAsync();
                Console.WriteLine(message);
                return new ToDoItem { Title = message, Description = message };
            }
            else
            {
                return await result.Content.ReadFromJsonAsync<ToDoItem>();
            }
        }

        public async Task<List<ToDoItem>> GetAllToDoItems()
        {
            return await _httpClient.GetFromJsonAsync<List<ToDoItem>>("api/ToDo");
        }

        public async Task CreateToDoItem(ToDoItem toDoItem)
        {
            await _httpClient.PostAsJsonAsync("api/ToDo", toDoItem);
        }
    }
}
