using SQLite;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TodoListApp.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public TodoItem()
        {
            // Initialize Title here
            Title = string.Empty; // or any default value
            // Initialize Description here
            Description = string.Empty; // or any default value
        }
    }
}