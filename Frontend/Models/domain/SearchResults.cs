using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Models.domain
{
    public class SearchResults
    {
        public List<Movie> Search { get; set; }
        public string totalResults { get; set; }
        public string Response { get; set; }
    }
}
