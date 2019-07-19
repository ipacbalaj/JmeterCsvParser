using JmeterResultsCsvParser.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace JmeterResultsCsvParser.Guards
{
    public class RequestStatusGuard : IGuard
    {
        private readonly IEnumerable<RequestInfo> input;

        public RequestStatusGuard(IEnumerable<RequestInfo> input)
        {
            this.input = input;
        }
        public bool Check()
        {
            foreach (var request in input)
            {
                if (request.responseCode != StatusCodes.SUCCESS)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
