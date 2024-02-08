using SQLite;
using System.Linq;
using System.Threading.Tasks;
using TodoListApp.Models;

namespace TodoListApp.Services
{
    public class DatabaseService
    {
        public SQLiteAsyncConnection _dbConnection;

        public DatabaseService()
        {
            SetupDatabase();
        }

        private async Task SetupDatabase()
        {
            if (_dbConnection == null)
            {
                string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UserDatabase.db3");
                _dbConnection = new SQLiteAsyncConnection(dbpath);
                await _dbConnection.CreateTableAsync<User>();
            }
        }

        public SQLiteAsyncConnection GetDbConnection()
        {
            return _dbConnection;
        }
    }

    // Data Access Class
    public class UserRepository
    {
        private readonly SQLiteAsyncConnection _dbConnection;

        public UserRepository(DatabaseService databaseService)
        {
            _dbConnection = databaseService.GetDbConnection();
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _dbConnection.Table<User>().FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}