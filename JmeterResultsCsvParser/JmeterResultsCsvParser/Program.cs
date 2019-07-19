using CommandLine;
using System;
using System.Collections.Generic;

namespace JmeterResultsCsvParser
{
    public class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<ArgumentOptions>(args)
              .WithParsed<ArgumentOptions>(o =>
              {
                  ProcessFile(o.CsvFilePath != null ? @o.CsvFilePath : @"D:\programs\apache-jmeter-5.0\bin\results\csvresult.csv");
                  ProcessEmails(o.Emails);
              })
             .WithNotParsed<ArgumentOptions>((errs) => Console.WriteLine(errs));
        }

        private static void ProcessFile(string filePath)
        {
            var csvParser = new CsvParser();
            var requestList = csvParser.ParseCsvFile(filePath);
            foreach (var request in requestList)
            {
                Console.WriteLine(request.label);
            }
        }

        private static void ProcessEmails(IEnumerable<string> emails)
        {
            if (emails != null)
            {
                foreach (var email in emails)
                {
                    Console.WriteLine(email);
                }
            }
        }
    }
}
