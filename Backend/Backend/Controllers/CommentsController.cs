using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/Comments")]
    public class CommentsController : Controller
    {
        private readonly CommentsService CS;
        private readonly SqlConnector Db;

        public CommentsController(CommentsService cs, SqlConnector db)
        {
            CS = cs;
            Db = db;
        }

        [Route("GetCommentsByVAndM/{viewerName, movieName}")]
        public async Task<List<Comment>> GetCommentsByViewerAndMovie(string viewerName, string movieName)
        {
            using (Db)
            {
                await Db.Connection.OpenAsync();
                return await CS.GetCommentsByUserAndMovie(viewerName, movieName);
            }
        }

        [Route("GetCommentsByV/{viewerName}")]
        public async Task<List<Comment>> GetCommentsByViewer(string viewerName)
        {
            using (Db)
            {
                await Db.Connection.OpenAsync();
                return await CS.FindOneAsync(viewerName);
            }
        }

        [Route("GetCommentsByM/{movieName}")]
        public async Task<List<Comment>> GetCommentsByMovie(string movieName)
        {
            using (Db)
            {
                await Db.Connection.OpenAsync();
                return await CS.GetCommentsByMovieName(movieName);
            }
        }

        [HttpPost]
        [Route("AddComment")]
        public async Task AddComment([FromBody]Comment comment)
        {
            using (Db)
            {
                await Db.Connection.OpenAsync();
                await CS.CreateComment(comment);
            }
        }

        [HttpDelete]
        [Route("DeleteComment/{commentID}")]
        public async Task DeleteComment(int commentID)
        {
            using (Db)
            {
                await Db.Connection.OpenAsync();
                User v = new User(Db)
                {
                    ID = 1,
                    Username = "andyghw",
                    Password = "19950116",
                    Email = "guo.hanw@husky.neu.edu",
                };
                await CS.DeleteComment(commentID);
            }
        }
    }
}
