using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace JmeterResultsCsvParser
{
    public class ArgumentOptions
    {
        [Option('e', "emails", Required = false, HelpText = "List of emails to send resuts to.")]
        public IEnumerable<string> Emails { get; set; }
        [Option('p', "path", Required = true, HelpText = "Csv File Path")]
        public string CsvFilePath { get; set; }
    }
}
