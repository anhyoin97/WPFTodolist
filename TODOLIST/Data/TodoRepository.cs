using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.SqlClient;
using TODOLIST.Models;

namespace TODOLIST.Data
{
    public class TodoRepository
    {
        private readonly string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=TodoListDB;Integrated Security=True;TrustServerCertificate=True;";

        public void AddTodo(string title) {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var command = new SqlCommand("INSERT INTO Todos (Title, IsDone) VALUES (@title, 0)", connection);
            command.Parameters.AddWithValue("@title", title);
            command.ExecuteNonQuery(); 
        }

        public List<TodoItem> GetTodos()
        {
            var todos = new List<TodoItem>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var command = new SqlCommand("SELECT Id, Title, IsDone FROM Todos", connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                todos.Add(new TodoItem
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    IsDone = reader.GetBoolean(2)
                });
            }

            return todos;
        }
    }
}
