using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace BackEnd.Models
{
    public class CommentsService
    {
        [JsonIgnore]
        public SqlConnector Db { get; set; }

        public CommentsService(SqlConnector db)
        {
            Db = db;
        }

        public async Task<List<Comment>> FindOneAsync(string viewerName)
        {
            var cmd = Db.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM comments WHERE username = @username ORDER BY createDate DESC";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@username",
                DbType = DbType.String,
                Value = viewerName,
            });
          
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result;
        }

        public async Task<List<Comment>> GetCommentsByMovieName(string movieName)
        {
            var cmd = Db.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM comments WHERE movieName = @moviename ORDER BY createDate DESC";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@moviename",
                DbType = DbType.String,
                Value = movieName,
            });

            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result;
        }

        public async Task<List<Comment>> GetCommentsByUserAndMovie (string viewerName, string movieName)
        {
            var cmd = Db.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM comments WHERE username = @username AND movieName = @moviename ORDER BY createDate DESC";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@username",
                DbType = DbType.String,
                Value = viewerName,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@username",
                DbType = DbType.String,
                Value = viewerName,
            });

            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result;
        }

        public async Task CreateComment(Comment comment)
        {
            MySqlConnection conn = Db.Connection;
            var cmd = conn.CreateCommand() as MySqlCommand;
            //Transaction
            using (IDbTransaction tran = conn.BeginTransaction())
            {
                try
                {
                    // your code
                    cmd.CommandText = @"INSERT INTO comments (username, movieName, createDate, text, rating) VALUES (@viewername, @moviename, @createdate, @text, @rating)";
                    cmd.Parameters.AddWithValue("@viewername", comment.username);
                    cmd.Parameters.AddWithValue("@moviename", comment.movieName);
                    cmd.Parameters.AddWithValue("@createdate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@text", comment.text);
                    cmd.Parameters.AddWithValue("@rating", comment.rating);
                    await cmd.ExecuteNonQueryAsync();
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        public async Task DeleteComment(int commentID)
        {
            MySqlConnection conn = Db.Connection;
            var cmd = conn.CreateCommand() as MySqlCommand;
            //Transaction
            using (IDbTransaction tran = conn.BeginTransaction())
            {
                try
                {
                    // your code
                    cmd.CommandText = @"DELETE FROM comments WHERE commentID = @commentID";
                    cmd.Parameters.AddWithValue("@commentID", commentID);
                    await cmd.ExecuteNonQueryAsync();
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        private async Task<List<Comment>> ReadAllAsync(DbDataReader reader)
        {
            var comments = new List<Comment>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var comment = new Comment(Db)
                    {
                        commentID=await reader.GetFieldValueAsync<int>(0),
                        username = await reader.GetFieldValueAsync<string>(1),
                        movieName = await reader.GetFieldValueAsync<string>(2),
                        createDate = await reader.GetFieldValueAsync<DateTime>(3),
                        text = await reader.GetFieldValueAsync<string>(4),
                        rating = await reader.GetFieldValueAsync<double>(5)
                    };
                    comments.Add(comment);
                }
            }
            return comments;
        }
    }
}
