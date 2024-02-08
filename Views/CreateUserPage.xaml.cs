using TodoListApp.Models;
using TodoListApp.Services;
using Microsoft.Maui.Controls;

namespace TodoListApp.Views
{
    public partial class CreateUserPage : ContentPage
    {
        private readonly AuthenticationService authService;

        public CreateUserPage()
        {
            InitializeComponent();
            authService = new AuthenticationService();
        }

        private async void OnCreateAccountClicked(object sender, EventArgs e)
        {
            User user = new User
            {
                Username = usernameEntry.Text,
                Password = passwordEntry.Text,
                Email = emailEntry.Text
            };

            int result = await authService.CreateUser(user);

            switch(result)
            {
                case 1: //Success
                    await DisplayAlert("Success", "User created successfully", "OK");
                    break;
                case -1: //Error: Email, username, and password are required.
                    await DisplayAlert("Error", "Email, username, and password are required", "OK");
                    break;
                case -2: //Error: Invalid email format.
                    await DisplayAlert("Error", "Invalid email format.", "OK");
                    break;
                case -3: //Error: Password must be at least 8 characters long.
                    await DisplayAlert("Error", "Password must be at least 8 characters long.", "OK");
                    break;
                case -4: //Error: UserName and Email must be unique
                    await DisplayAlert("Error", "UserName and Email must be unique.", "OK");
                    break;
                case -5: //Error: Failed to insert user into the database.
                    await DisplayAlert("Error", "Failed to insert user into the database.", "OK");
                    break;
            }
        }
    }
}