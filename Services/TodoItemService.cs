using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoListApp.Models;

public class TodoItemService
{
    private readonly SQLiteAsyncConnection _dbConnection;

    public TodoItemService(SQLiteAsyncConnection dbConnection)
    {
        _dbConnection = dbConnection;
        _dbConnection.CreateTableAsync<TodoItem>().Wait(); // Create table if it doesn't exist
    }

    public async Task<List<TodoItem>> GetAllTodoItemsAsync()
    {
        return await _dbConnection.Table<TodoItem>().ToListAsync();
    }

    public async Task AddTodoItemAsync(TodoItem todoItem)
    {
        await _dbConnection.InsertAsync(todoItem);
    }

    // Implement methods for updating, deleting, etc. as needed
}