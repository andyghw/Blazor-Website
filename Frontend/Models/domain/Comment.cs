using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Models.domain
{
    public class Comment
    {
        public int commentID { get; set; }
        public string username { get; set; }
        public string movieName { get; set; }
        public DateTime createDate { get; set; }
        public string text { get; set; }
        public double rating { get; set; }
    }
}
