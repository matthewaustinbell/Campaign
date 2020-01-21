using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace camp.aign.Models
{
    public class APIQuestion
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string Difficulty { get; set; }
        public string Question { get; set; }
        public string correct_answer { get; set; }
        public List<string> incorrect_answers { get; set; }
    }
}
