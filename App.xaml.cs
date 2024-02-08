using Microsoft.Maui;
using Microsoft.Maui.Controls;
using TodoListApp.Views;
using Application = Microsoft.Maui.Controls.Application;

namespace TodoListApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }
    }
}