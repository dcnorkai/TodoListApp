namespace TodoListApp.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private void OnLoginClicked(object sender, EventArgs e)
    {
        // Navigate to Login page
        Navigation.PushAsync(new LoginPage());
    }

    private void OnRegisterClicked(object sender, EventArgs e)
    {
        // Navigate to registration page
        Navigation.PushAsync(new RegisterPage());
    }
}