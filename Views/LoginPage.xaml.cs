using TodoListApp.Models;
using TodoListApp.Services;
using Microsoft.Maui.Controls;
using SQLite;

namespace TodoListApp.Views
{
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
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Error", "Please enter both username and password", "OK");
                return;
            }

            if (authService == null)
            {
                await DisplayAlert("Error", "Authentication service is not available", "OK");
                return;
            }

            bool isAuthenticated = await authService.AuthenticateUser(username, password);
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

        private void OnCreateAccountClicked(object sender, EventArgs e)
        {
            // Navigate to user creation page
            Navigation.PushAsync(new RegisterPage());
        }
    }
}