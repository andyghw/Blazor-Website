using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Data.Common;

namespace BackEnd.Models
{
    public class ViewerService
    {
        [JsonIgnore]
        public SqlConnector Db { get; set; }

        public ViewerService(SqlConnector db)
        {
            Db = db;
        }

        public async Task<User> FindOneAsync(string email, string password)
        {
            var cmd = Db.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM users WHERE email = @email AND password = @password";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@email",
                DbType = DbType.String,
                Value = email,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@password",
                DbType = DbType.String,
                Value = password,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }

        public async Task<User> FindOneByEUAsync(string email, string username)
        {
            var cmd = Db.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM users WHERE email = @email AND username = @username";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@email",
                DbType = DbType.String,
                Value = email,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@username",
                DbType = DbType.String,
                Value = username,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }

        private async Task<List<User>> ReadAllAsync(DbDataReader reader)
        {
            var users = new List<User>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var user = new User(Db)
                    {
                        ID = await reader.GetFieldValueAsync<int>(0),
                        Username = await reader.GetFieldValueAsync<string>(1),
                        Email = await reader.GetFieldValueAsync<string>(2),
                        Password = await reader.GetFieldValueAsync<string>(3)
                    };
                    users.Add(user);
                }
            }
            return users;
        }

    }
}
