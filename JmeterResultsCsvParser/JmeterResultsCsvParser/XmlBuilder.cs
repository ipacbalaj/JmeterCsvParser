using JmeterResultsCsvParser.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace JmeterResultsCsvParser
{
    public class XmlBuilder
    {
        private XElement testSuites = new XElement("testsuites");

        public void AddTestSuite(IEnumerable<RequestTimeAverage> requestTimeAverages)
        {

            XElement testSuite = new XElement("testsuite");

            foreach (var avg in requestTimeAverages)
            {
                var element = new XElement("testcase",
                    new XAttribute("classname", "httpSample"),
                    new XAttribute("name", avg.RequestName),
                    new XAttribute("time", avg.AverageTimeInMilliseconds.ToString()),
                    new XAttribute("failures", avg.NoOfFailedRequests.ToString())
                    );
                testSuite.Add(element);
            }
            testSuites.Add(testSuite);
            Console.WriteLine(testSuites);
        }

        public XElement GetResult()
        {
            return testSuites;
        }
    }
}
