using TodoListApp.Models;
using TodoListApp.Services;
using Microsoft.Maui.Controls;
using SQLite;

namespace TodoListApp.Views
{
    /*public class UserRepository
    {
        private readonly SQLiteAsyncConnection _dbConnection;

        public UserRepository(DatabaseService databaseService)
        {
            _dbConnection = databaseService.GetDbConnection();
        }

        public async Task<User> GetUserByUsernameOrEmail(string usernameOrEmail)
        {
            // Check if the usernameOrEmail matches a username or email in the database
            return await _dbConnection.Table<User>()
                                      .FirstOrDefaultAsync(u => u.Username == usernameOrEmail || u.Email == usernameOrEmail);
        }
    }*/
    public partial class LoginPage : ContentPage
    {
        private readonly AuthenticationService authService;

        public LoginPage()
        {
            InitializeComponent();
            authService = new AuthenticationService();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            /*User user = new User
            {
                Username = usernameEntry.Text,
                Password = passwordEntry.Text
            };*/

            if ((usernameEntry.Text != null) && (passwordEntry.Text != null) && (authService != null))
            {  
                    bool isAuthenticated = await authService.AuthenticateUser(usernameEntry.Text, passwordEntry.Text);
                    if (isAuthenticated)
                    {
                        // Navigate to todo list page
                        await Navigation.PushAsync(new TodoListPage());
                        await DisplayAlert("Success", "You have logged in!", "OK");
                }
                    else
                    {
                        await DisplayAlert("Error", "Invalid username or password", "OK");
                    }
            }
            else
            {
                await DisplayAlert("Error", "Invalid username or password", "OK");
            }
        }

        private void OnCreateAccountClicked(object sender, EventArgs e)
        {
            // Navigate to user creation page
            Navigation.PushAsync(new CreateUserPage());
        }
    }
}