using Dapper;
using dappertutorial.DAL.Models;
using dappertutorial.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace dappertutorial.DAL
{
    public class TodoDataStore : ITodoDataStore
    {
        private readonly DatabaseConfiguration _config;

        public TodoDataStore(DapperTutorialConfiguration config)
        {
            _config = config.Database;
        }

        public async Task<int> DeleteTodoItem(int id)
        {
            const string query = "DELETE FROM TodoItem WHERE Id = @Id";

            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                return await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<TodoItemDAL>> SelectAllTodoItems()
        {
            string query = "SELECT * FROM TodoItem";

            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                return await connection.QueryAsync<TodoItemDAL>(query);
            }
        }

        public async Task<TodoItemDAL> SelectTodoItem(int id)
        {
            const string query = "SELECT * FROM TodoItem WHERE Id = @Id";

            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                return await connection.QueryFirstAsync<TodoItemDAL>(query, new { Id = id });
            }
        }

        public async Task<int> InsertTodoItem(TodoItem todoItem)
        {
            string query = $@"INSERT INTO TodoItem (
                                {nameof(TodoItem.Description)}, 
                                {nameof(TodoItem.IsComplete)}, 
                                {nameof(TodoItem.Name)}) 
                              VALUES (@Description, @IsComplete, @Name)";

            var parameters = new DynamicParameters(todoItem);

            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                return await connection.ExecuteAsync(query, parameters);
            }

        }

        public async Task<int> UpdateTodoItem(TodoItem todoItem, int id)
        {
            string query = $@"UPDATE TodoItem SET 
                            {nameof(TodoItem.Name)} = @Name,
                            {nameof(TodoItem.Description)} = @Description,
                            {nameof(TodoItem.IsComplete)} = @IsComplete
                            WHERE Id = @Id;";

            var parameters = new DynamicParameters(todoItem);
            parameters.Add("Id", id);

            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                return await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
