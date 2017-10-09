using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calls.Models
{
    public class CallSummary
    {
        public int Calls { get; set; }
        public decimal Minutes { get; set; }
        public int Answered { get; set; }
        public int Unanswered { get; set; }

        public CallSummary()
        {
            Calls = 0;
            Minutes = 0.0m;
            Answered = 0;
            Unanswered = 0;
        }
    }
}
