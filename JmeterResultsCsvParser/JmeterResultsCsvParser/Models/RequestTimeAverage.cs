using System;
using System.Collections.Generic;
using System.Text;

namespace JmeterResultsCsvParser.Models
{
    public class RequestTimeAverage
    {
        public string RequestName { get; set; }
        public double AverageTimeInMilliseconds { get; set; }
        public int NoOfFailedRequests { get; set; }
    }
}
