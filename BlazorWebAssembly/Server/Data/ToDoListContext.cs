using BlazorWebAssembly.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAssembly.Server.Data
{
    public class ToDoListContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }

        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options)
        {

        }
    }
}
