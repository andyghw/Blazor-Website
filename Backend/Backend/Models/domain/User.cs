using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace BackEnd.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<Comment> comments { get; set; }


        [JsonIgnore]
        public SqlConnector Db { get; set; }

        public User()
        {
            comments = new List<Comment>();
        }

        public User(SqlConnector db = null)
        {
            Db = db;
            comments = new List<Comment>();
        }

        public async Task InsertAsync()
        {
            var cmd = Db.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO users (username, password,email) VALUES (@username, @password, @email);";
            BindUserParams(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task UpdateAsync()
        {
            var cmd = Db.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE users SET username=@username, password = @password, email = @email WHERE email = @email;";
            BindUserParams(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        private void BindUserParams(MySqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@username", Username);
            cmd.Parameters.AddWithValue("@password", Password);
            cmd.Parameters.AddWithValue("@email", Email);
        }
    }
}
