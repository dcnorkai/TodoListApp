using SQLite;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TodoListApp.Models
{
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public TodoItem()
        {
            // Initialize Title here
            Title = string.Empty; // or any default value
            // Initialize Description here
            Description = string.Empty; // or any default value
        }
    }
}