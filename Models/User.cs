using SQLite;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TodoListApp.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }
        [Unique]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        [Unique]
        public string Email { get; set; }
        public DateTime DateCreated { get; set; }

        public User()
        {
            // Initialize Username here
            Username = string.Empty; // or any default value
            // Initialize Password here
            Password = string.Empty; // or any default value
            // Initialize Salt here
            Salt = string.Empty; // or any default value
            // Initialize Email here
            Email = string.Empty; // or any default value
            // Initialize DateCreated here
            DateCreated = DateTime.Now; // or any default value
        }
    }
}