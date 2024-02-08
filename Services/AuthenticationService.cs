using SQLite;
using TodoListApp.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using BCrypt.Net;

namespace TodoListApp.Services
{
    public class AuthenticationService
    {
        private readonly DatabaseService _databaseService;
        private readonly UserRepository _userRepository;

        public AuthenticationService()
        {
            _databaseService = new DatabaseService();
            _userRepository = new UserRepository(_databaseService);
        }

        public async Task<bool> AuthenticateUser(string username, string password)
        {
            // Retrieve the user from the database based on the provided username or email
            var user = await _userRepository.GetUserByUsername(username);
            //User user = null;

            if (user != null)
            {
                // Hash the provided password using the same salt as stored in the database
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, user.Password);

                // Compare the hashed password with the hashed password retrieved from the database
                if (hashedPassword == user.Password)
                {
                    // Authentication successful
                    return true;
                }
            }

            // Authentication failed
            return false;
        }

        public static bool IsValidEmail(string email)
        {
            // Define a regular expression pattern for validating email addresses
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            // Check if the email matches the pattern
            return Regex.IsMatch(email, pattern);
        }

        public async Task<bool> IsUserNameUnique(string userName)
        {
            
            // Check if the UserName already exists in the database
            var existingUser = await _databaseService._dbConnection.Table<User>().Where(u => u.Username == userName).FirstOrDefaultAsync();
            return existingUser == null; // Return true if UserName is unique, false otherwise
        }

        public async Task<bool> IsEmailUnique(string email)
        {
            // Check if the Email already exists in the database
            var existingUser = await _databaseService._dbConnection.Table<User>().Where(u => u.Email == email).FirstOrDefaultAsync();
            return existingUser == null; // Return true if Email is unique, false otherwise
        }

        public async Task<int> CreateUser(User user)
        {
            // Implement user creation logic here (e.g., save to database)
            if (user.Email == null || user.Username == null || user.Password == null)
            {
                return (-1); //Error: Email, username, and password are required.
            }

            if (!IsValidEmail(user.Email))
            {
                return (-2); //Error: Invalid email format.
            }

            if (user.Password.Length < 8)
            {
                return (-3); //Error: Password must be at least 8 characters long.
            }

            if (!(await IsUserNameUnique(user.Username) && await IsEmailUnique(user.Email)))
            {
                return (-4); //Error: UserName and Email must be unique
            }

            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password, salt);
            user.Salt = salt;
            user.Password = hashedPassword;

            int result = await _databaseService._dbConnection.InsertAsync(user);

            if (result < 0)
            {
                return (-5); //Error: Failed to insert user into the database.
            }

            return (result); //Success
        }
    }
}
 