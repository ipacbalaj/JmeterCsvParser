using System;
using System.Collections.Generic;
using System.Text;

namespace JmeterResultsCsvParser
{
    public class RequestInfo
    {
        public string timeStamp { get; set; }
        public int elapsed { get; set; }
        public string label { get; set; }
        public int responseCode { get; set; }
        public string responseMessage { get; set; }
        public string threadName { get; set; }
        public string dataType { get; set; }
        public string success { get; set; }
        public string failureMessage { get; set; }
        public int bytes { get; set; }
        public int sentBytes { get; set; }
        public int grpThreads { get; set; }
        public int allThreads { get; set; }
        public int Latency { get; set; }
        public int IdleTime { get; set; }
        public int Connect { get; set; }
    }
}
