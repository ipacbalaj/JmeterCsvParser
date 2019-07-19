using JmeterResultsCsvParser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JmeterResultsCsvParser
{
    public class ResultsProcessor
    {
        public IEnumerable<RequestTimeAverage> GetAverageTimesPerRequest(List<RequestInfo> requests)
        {
            var result = requests.GroupBy(r => r.label).Select(g => new RequestTimeAverage()
            {
                AverageTimeInMilliseconds = g.Average(x => x.elapsed),
                RequestName = g.Key
            });

            return result;
        }
    }
}
