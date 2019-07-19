using CommandLine;
using JmeterResultsCsvParser.Guards;
using JmeterResultsCsvParser.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JmeterResultsCsvParser
{
    public class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<ArgumentOptions>(args)
              .WithParsed<ArgumentOptions>(o =>
              {
                  var requests = GetRequests(o.CsvFilePath);
                  var averages = GetRequestAverages(requests);
                  SaveAveragesToXml(averages, o.XmlResultFilePath);

                  if (o.ThresholdValue != 0)
                  {
                      var thresholdGuard = new ThresholdGuard(o.ThresholdValue, averages);
                      if (!thresholdGuard.Check())
                      {
                          throw new Exception("Threshold value");
                      }
                  }

                  if (o.ShouldCheckForFailure)
                  {
                      var failureGuard = new RequestStatusGuard(requests);
                      if (failureGuard.Check())
                      {
                          throw new Exception("Failed Requests");
                      }
                  }
              })
             .WithNotParsed<ArgumentOptions>((errs) => Console.WriteLine(errs));

            //var avgs = GetRequestAverages(@"D:\programs\apache-jmeter-5.0\bin\results\csvresult.csv");
            //SaveAveragesToXml(avgs, @"D:\programs\apache-jmeter-5.0\bin\results\resultu.xml");
        }

        private static IEnumerable<RequestInfo> GetRequests(string filePath)
        {
            var csvParser = new CsvParser();
            var requestList = csvParser.ParseCsvFile(filePath);

            return requestList;
        }

        private static IEnumerable<RequestTimeAverage> GetRequestAverages(IEnumerable<RequestInfo> requestList)
        {
            var resultsProcessor = new ResultsProcessor();
            var averages = resultsProcessor.GetAverageTimesPerRequest(requestList.ToList());

            foreach (var avg in averages)
            {
                Console.WriteLine(avg.RequestName + " has average :" + avg.AverageTimeInMilliseconds);
            }

            return averages;
        }

        private static void SaveAveragesToXml(IEnumerable<RequestTimeAverage> averages, string resultFilePath)
        {
            var xmlBuilder = new XmlBuilder();
            xmlBuilder.AddTestSuite(averages);
            xmlBuilder.GetResult().Save(resultFilePath);
        }

    }
}
