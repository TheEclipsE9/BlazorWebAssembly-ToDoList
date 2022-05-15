using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebAssembly.Shared
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public bool IsDone { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
    }
}
