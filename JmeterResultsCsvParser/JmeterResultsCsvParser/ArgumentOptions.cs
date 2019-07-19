using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace JmeterResultsCsvParser
{
    public class ArgumentOptions
    {
        [Option('s', "sourcepath", Required = true, HelpText = "Source Csv File Path")]
        public string CsvFilePath { get; set; }

        [Option('d', "destinationPath", Required = true, HelpText = "Result XML file path")]
        public string XmlResultFilePath { get; set; }

        [Option('t', "threshold", Required = false, HelpText = "Threshold Value")]
        public int ThresholdValue { get; set; }

        [Option("failure", Required = false, HelpText = "Should Check for failures")]
        public bool ShouldCheckForFailure { get; set; }
    }
}
