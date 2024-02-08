using System.Collections.ObjectModel;
using System.ComponentModel;
using Microsoft.Maui.Controls;

namespace TodoListApp.Views
{
    [DesignTimeVisible(false)]
    public partial class TodoListPage : ContentPage
    {
        public ObservableCollection<string> TodoItems { get; } = new ObservableCollection<string>();

        public TodoListPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void AddTodo_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(todoEntry.Text))
            {
                TodoItems.Add(todoEntry.Text);
                todoEntry.Text = string.Empty;
            }
        }
    }
}