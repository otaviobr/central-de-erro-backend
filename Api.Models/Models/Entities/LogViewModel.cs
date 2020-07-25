using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    public class LogViewModel
    {
        public int Id { get; set; }
        public string Level { get; set; }
        public int Frequency { get; set; }
        public string Description { get; set; }
    }
}
