using calls.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace calls.Controllers.v2
{
    public class CallsController : Controller
    {
        CallAnalyzerContext context = new CallAnalyzerContext();

        [HttpGet]
        [Route("api/v2/calls")]

        public string About()
        {
            return "Use [HttpPost] to access this endpoint. Valid parameters are: start [DateTime], end [DateTime], number [string], device [string] cause [string], skip [int], take [int]";
        }

        [HttpGet]
        [Route("api/v2/calls/{id}")]
        public TblCallsFull GetCall(int id)
        {
            return context.TblCallsFull.Find(id);
        }

        [HttpPost]
        [Route("api/v2/calls")]
        public List<TblCallsFull> GetCalls(DateTime? start, DateTime? end, string number, string device, string cause, int skip = 0, int take = 10)
        {
            try
            {
                var calls = context.TblCallsFull.AsQueryable();

                if (start != null)
                {
                    calls = calls.Where(c => c.DateTimeDisconnect > start);
                }

                if (end != null)
                {
                    calls = calls.Where(c => c.DateTimeDisconnect < end);
                }

                if (number != null)
                {
                    calls = calls.Where(c => c.CallingPartyNumber == number || c.OriginalCalledPartyNumber == number || c.FinalCalledPartyNumber == number);
                }

                if (device != null)
                {
                    calls = calls.Where(c => c.OrigDeviceName == device || c.DestDeviceName == device);
                }

                if (cause != null)
                {
                    calls = calls.Where(c => c.OrigCauseValue == cause || c.DestCauseValue == cause);
                }

                return calls
                    .Skip(skip)
                    .Take(take)
                    .ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
