using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JmeterResultsCsvParser
{
    public class CsvParser
    {
        public List<RequestInfo> ParseCsvFile(string fileName)
        {
            var requestList = new List<RequestInfo>();
            using (TextReader reader = File.OpenText(fileName))
            {
                CsvReader csv = new CsvReader(reader);
                csv.Configuration.Delimiter = ",";
                csv.Configuration.MissingFieldFound = null;
                while (csv.Read())
                {

                    RequestInfo record = csv.GetRecord<RequestInfo>();
                    requestList.Add(record);
                }
            }

            return requestList;
        }
    }
}
