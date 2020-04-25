using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoPWA.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Complete { get; set; }
        public DateTime DueDate { get; set; }
        public String Note { get; set; }
    }
}
