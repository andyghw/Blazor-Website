using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace BackEnd.Models
{
    public class Comment
    {
        public int commentID { get; set; }
        public string username { get; set; }
        public string movieName { get; set; }
        public DateTime createDate { get; set; }
        public string text { get; set; }
        public double rating { get; set; }

        [JsonIgnore]
        public SqlConnector Db { get; set; }

        public Comment(SqlConnector db = null)
        {
            Db = db;
        }

        public async Task InsertAsync()
        {
            var cmd = Db.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO comments (username, moviename, createDate, text, rating) VALUES (@username, @moviename, @date, @text, @rate);";
            BindUserParams(cmd);
            await cmd.ExecuteNonQueryAsync();
        }
        public async Task UpdateTextAsync()
        {
            var cmd = Db.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE comments SET createDate = @date, text = @text WHERE viewerName=@username, movieName = @moviename;";
            BindUserParams(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task UpdateRatingAsync()
        {
            var cmd = Db.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE comments SET rating = @rate WHERE viewerName=@username, movieName = @moviename;";
            BindUserParams(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        private void BindUserParams(MySqlCommand cmd)

        {
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@moviename", movieName);
            cmd.Parameters.AddWithValue("@date", createDate);
            cmd.Parameters.AddWithValue("@text", text);
            cmd.Parameters.AddWithValue("@rate", rating);
        }
    }
}

