using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Movie
    {
        public string titleID { get; set; }
        public string title { get; set; }
        public string region { get; set; }
        public string language { get; set; }
        public string type { get; set; }
        public bool isAdult { get; set; }
        public int birthYear { get; set; }
        public string discription { get; set; }
        public string director { get; set; }
        public List<string> actors { get; set; }
        public List<Comment> comments { get; set; }
        public double rating { get; set; }
    }
}
