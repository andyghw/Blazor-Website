using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace BackEnd.Controllers
{
    [Produces("application/json")]
    [Route("api/Viewer")]
    public class ViewersController : Controller
    {
        private readonly ViewerService US;
        private readonly SqlConnector Db;

        public ViewersController(ViewerService us, SqlConnector db)
        {
            US = us;
            Db = db;
        }

        [Route("GetLinkedUserInfo")]
        public IActionResult GetLinkedUserInfo(string token)
        {
            string url = "https://api.linkedin.com/v1/people/~:(first-name,email-address)?format=json";
            WebRequest request = WebRequest.Create(url);
            request.Method = "get";
            request.Headers["Authorization"] = "Bearer " + token;
            string res = string.Empty;
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                res = reader.ReadToEnd();
                reader.Close();
            }
            catch (Exception ex)
            {
                res = ex.ToString();
            }
            Debug.WriteLine("================================="+res);
            JObject jObject = JObject.Parse(res);
            User user = new User();
            user.Username = jObject["firstName"].ToString();
            user.Email = jObject["emailAddress"].ToString();
            return Redirect("http://localhost:8000/LinkedInAuth?username="+ user.Username+"&email="+ user.Email);
        }

        [Route("/auth/linkedin/callback")]
        public IActionResult Callback(string code, string state)
        {
            string url = "https://www.linkedin.com/oauth/v2/accessToken?grant_type=authorization_code&code="+ code + "&redirect_uri=http://localhost:5000/auth/linkedin/callback&client_id=78qfdec93jlj2z&client_secret=ta60njw7MCnb6M2J";
            WebRequest request = WebRequest.Create(url);
            request.Method = "post";
            string res = string.Empty;
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                res = reader.ReadToEnd();
                reader.Close();
            }
            catch (Exception ex)
            {
                res = ex.ToString();
            }
            JObject jObject = JObject.Parse(res);
            string token = jObject["access_token"].ToString();
            return Redirect("/api/Viewer/GetLinkedUserInfo?token=" + token);
        }

        [Route("LinkedInLogin")]
        public IActionResult LinkedInLogin()
        {
            string url = "https://www.linkedin.com/oauth/v2/authorization?response_type=code&client_id=78qfdec93jlj2z&redirect_uri=http://localhost:5000/auth/linkedin/callback&state=987654321&scope=r_basicprofile+r_emailaddress";
            return Redirect(url);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<User> Login(string email, string password)
        {
            using (Db)
            {
                await Db.Connection.OpenAsync();
                var result = await US.FindOneAsync(email, password);
                return result;
            }
        }

        [HttpPost]
        [Route("Validate")]
        public async Task<User> Validate(string email, string username)
        {
            using (Db)
            {
                await Db.Connection.OpenAsync();
                var result = await US.FindOneByEUAsync(email, username);
                return result;
            }
        }

        [HttpPost]
        [Route("Register")]
        public async Task Register(string email, string username, string password)
        {
            using (Db)
            {
                await Db.Connection.OpenAsync();
                var user = new User(Db)
                {
                    Email = email,
                    Username = username,
                    Password = password
                };
                await user.InsertAsync();
            }
        }

        [HttpPut]
        [Route("UpdateAccount")]
        public async Task UpdateAccount(string email, string username, string password)
        {
            using (Db)
            {
                await Db.Connection.OpenAsync();
                var user = new User(Db)
                {
                    Email = email,
                    Username= username,
                    Password = password
                };
                await user.UpdateAsync();
            }
        }
    }
}
