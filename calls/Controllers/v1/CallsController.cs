using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using calls.Models;

namespace calls.Controllers
{
    public class CallsController : Controller
    {
        [HttpGet]
        [Route("api/v1/calls/{start}/{end}")]
        public List<TblCallsFull> GetCalls(DateTime start, DateTime end)
        {
            var context = new CallAnalyzerContext();

            var results = context.TblCallsFull
                            .Where(c => c.DateTimeDisconnect > start)
                            .Where(c => c.DateTimeDisconnect < end)
                            .ToList();
            
            return results;
        }

        [HttpGet]
        [Route("api/v1/calls/{start}/{end}/{number}")]
        public List<TblCallsFull> GetCallsByNumber(DateTime start, DateTime end, string number)
        {
            var context = new CallAnalyzerContext();

            var results = context.TblCallsFull
                            .Where(c => c.DateTimeDisconnect > start)
                            .Where(c => c.DateTimeDisconnect < end)
                            .Where(c => c.CallingPartyNumber == number || c.OriginalCalledPartyNumber == number || c.FinalCalledPartyNumber == number)
                            .ToList();

            return results;
        }

        [HttpGet]
        [Route("api/v1/calls/{start}/{end}/summary")]
        public ProgramSummary Summary(DateTime start, DateTime end)
        {
            var context = new CallAnalyzerContext();
            ProgramSummary s = new ProgramSummary();

            var results = context.TblCallsFull
                            .Where(c => c.DateTimeDisconnect > start)
                            .Where(c => c.DateTimeDisconnect < end);

            foreach (var c in results)
            {
                if (c.CallingPartyNumber == "" || c.CallingPartyNumber.Length > 4)
                {
                    s.FromOutside.Calls++;
                    s.FromOutside.Minutes += Convert.ToDecimal(c.Duration);
                    if (c.FinalCalledPartyNumber == "8888")
                        s.FromOutside.Unanswered++;
                    else
                        s.FromOutside.Answered++;
                }
                else
                {
                    switch (c.CallingPartyNumber.Substring(0, 1))
                    {
                        case "8":
                            s.FromLSNJ.Calls++;
                            s.FromLSNJ.Minutes += Convert.ToDecimal(c.Duration);
                            if (c.FinalCalledPartyNumber == "8888")
                                s.FromLSNJ.Unanswered++;
                            else
                                s.FromLSNJ.Answered++;
                            break;
                        case "6":
                            s.FromSJLS.Calls++;
                            s.FromSJLS.Minutes += Convert.ToDecimal(c.Duration);
                            if (c.FinalCalledPartyNumber == "8888")
                                s.FromSJLS.Unanswered++;
                            else
                                s.FromSJLS.Answered++;
                            break;
                        case "5":
                            s.FromLSNWJ.Calls++;
                            s.FromLSNWJ.Minutes += Convert.ToDecimal(c.Duration);
                            if (c.FinalCalledPartyNumber == "8888")
                                s.FromLSNWJ.Unanswered++;
                            else
                                s.FromLSNWJ.Answered++;
                            break;
                        case "4":
                            s.FromENLS.Calls++;
                            s.FromENLS.Minutes += Convert.ToDecimal(c.Duration);
                            if (c.FinalCalledPartyNumber == "8888")
                                s.FromENLS.Unanswered++;
                            else
                                s.FromENLS.Answered++;
                            break;
                        case "3":
                            s.FromNNJLS.Calls++;
                            s.FromNNJLS.Minutes += Convert.ToDecimal(c.Duration);
                            if (c.FinalCalledPartyNumber == "8888")
                                s.FromNNJLS.Unanswered++;
                            else
                                s.FromNNJLS.Answered++;
                            break;
                        case "2":
                            s.FromCJLS.Calls++;
                            s.FromCJLS.Minutes += Convert.ToDecimal(c.Duration);
                            if (c.FinalCalledPartyNumber == "8888")
                                s.FromCJLS.Unanswered++;
                            else
                                s.FromCJLS.Answered++;
                            break;
                        default:
                            s.FromOutside.Calls++;
                            s.FromOutside.Minutes += Convert.ToDecimal(c.Duration);
                            if (c.FinalCalledPartyNumber == "8888")
                                s.FromOutside.Unanswered++;
                            else
                                s.FromOutside.Answered++;
                            break;
                    }
                }
            }

            return s;
        }

        [HttpGet]
        [Route("api/v1/calls/{start}/{end}/{number}/summary")]
        public ProgramSummary SummaryByNumber(DateTime start, DateTime end, string number)
        {
            var context = new CallAnalyzerContext();
            ProgramSummary s = new ProgramSummary();

            var results = context.TblCallsFull
                            .Where(c => c.DateTimeDisconnect > start)
                            .Where(c => c.DateTimeDisconnect < end)
                            .Where(c => c.CallingPartyNumber == number || c.OriginalCalledPartyNumber == number || c.FinalCalledPartyNumber == number);

            foreach (var c in results)
            {
                if (c.CallingPartyNumber == "" || c.CallingPartyNumber.Length > 4)
                {
                    s.FromOutside.Calls++;
                    s.FromOutside.Minutes += Convert.ToDecimal(c.Duration);
                    if (c.FinalCalledPartyNumber == "8888")
                        s.FromOutside.Unanswered++;
                    else
                        s.FromOutside.Answered++;
                }
                else
                {
                    switch (c.CallingPartyNumber.Substring(0, 1))
                    {
                        case "8":
                            s.FromLSNJ.Calls++;
                            s.FromLSNJ.Minutes += Convert.ToDecimal(c.Duration);
                            if (c.FinalCalledPartyNumber == "8888")
                                s.FromLSNJ.Unanswered++;
                            else
                                s.FromLSNJ.Answered++;
                            break;
                        case "6":
                            s.FromSJLS.Calls++;
                            s.FromSJLS.Minutes += Convert.ToDecimal(c.Duration);
                            if (c.FinalCalledPartyNumber == "8888")
                                s.FromSJLS.Unanswered++;
                            else
                                s.FromSJLS.Answered++;
                            break;
                        case "5":
                            s.FromLSNWJ.Calls++;
                            s.FromLSNWJ.Minutes += Convert.ToDecimal(c.Duration);
                            if (c.FinalCalledPartyNumber == "8888")
                                s.FromLSNWJ.Unanswered++;
                            else
                                s.FromLSNWJ.Answered++;
                            break;
                        case "4":
                            s.FromENLS.Calls++;
                            s.FromENLS.Minutes += Convert.ToDecimal(c.Duration);
                            if (c.FinalCalledPartyNumber == "8888")
                                s.FromENLS.Unanswered++;
                            else
                                s.FromENLS.Answered++;
                            break;
                        case "3":
                            s.FromNNJLS.Calls++;
                            s.FromNNJLS.Minutes += Convert.ToDecimal(c.Duration);
                            if (c.FinalCalledPartyNumber == "8888")
                                s.FromNNJLS.Unanswered++;
                            else
                                s.FromNNJLS.Answered++;
                            break;
                        case "2":
                            s.FromCJLS.Calls++;
                            s.FromCJLS.Minutes += Convert.ToDecimal(c.Duration);
                            if (c.FinalCalledPartyNumber == "8888")
                                s.FromCJLS.Unanswered++;
                            else
                                s.FromCJLS.Answered++;
                            break;
                        default:
                            s.FromOutside.Calls++;
                            s.FromOutside.Minutes += Convert.ToDecimal(c.Duration);
                            if (c.FinalCalledPartyNumber == "8888")
                                s.FromOutside.Unanswered++;
                            else
                                s.FromOutside.Answered++;
                            break;
                    }
                }
            }

            return s;
        }

    }
}
