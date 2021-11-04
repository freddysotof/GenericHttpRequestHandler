using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_GenericHttpHandler.Models
{
    public class CatFact
    {
        public int current_page{ get; set; }
        public string first_page_url { get; set; }
        public string from { get; set; }
        public int last_page { get; set; }
        public string last_page_url { get; set; }
    }
}
