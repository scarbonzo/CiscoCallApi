using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calls.Models
{
    public class ProgramSummary
    {
        public CallSummary FromLSNJ { get; set; }
        public CallSummary FromLSNWJ { get; set; }
        public CallSummary FromCJLS { get; set; }
        public CallSummary FromSJLS { get; set; }
        public CallSummary FromENLS { get; set; }
        public CallSummary FromNNJLS { get; set; }
        public CallSummary FromOutside { get; set; }
        public CallSummary Total
        {
            get
            {
                CallSummary temp = new CallSummary();

                temp.Calls = FromLSNJ.Calls + FromLSNWJ.Calls + FromCJLS.Calls + FromSJLS.Calls + FromENLS.Calls + FromNNJLS.Calls + FromOutside.Calls;
                temp.Minutes = FromLSNJ.Minutes + FromLSNWJ.Minutes + FromCJLS.Minutes + FromSJLS.Minutes + FromENLS.Minutes + FromNNJLS.Minutes + FromOutside.Minutes;
                temp.Answered = FromLSNJ.Answered + FromLSNWJ.Answered + FromCJLS.Answered + FromSJLS.Answered + FromENLS.Answered + FromNNJLS.Answered + FromOutside.Answered;
                temp.Unanswered = FromLSNJ.Unanswered + FromLSNWJ.Unanswered + FromCJLS.Unanswered + FromSJLS.Unanswered + FromENLS.Unanswered + FromNNJLS.Unanswered + FromOutside.Unanswered;

                return temp;
            }
        }

        public ProgramSummary()
        {
            FromLSNJ = new CallSummary();
            FromLSNWJ = new CallSummary();
            FromCJLS = new CallSummary();
            FromSJLS = new CallSummary();
            FromENLS = new CallSummary();
            FromNNJLS = new CallSummary();
            FromOutside = new CallSummary();
        }
    }
}
