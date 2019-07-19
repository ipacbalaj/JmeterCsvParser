using JmeterResultsCsvParser.Guards;
using JmeterResultsCsvParser.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JmeterResultsCsvParser
{
    public class ThresholdGuard : IGuard
    {
        private readonly double thresholdInMilliseconds;
        private readonly IEnumerable<RequestTimeAverage> input;

        public ThresholdGuard(double thresholdInMilliseconds, IEnumerable<RequestTimeAverage> input)
        {
            this.thresholdInMilliseconds = thresholdInMilliseconds;
            this.input = input;
        }

        public bool Check()
        {
            foreach (var avg in input)
            {
                if (avg.AverageTimeInMilliseconds > this.thresholdInMilliseconds)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
