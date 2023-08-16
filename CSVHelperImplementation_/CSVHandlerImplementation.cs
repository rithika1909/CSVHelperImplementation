using CsvHelper;
using CSVHelperImplementation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;

using System.Threading.Tasks;



namespace CSVHelperImplementation
{
    public class CSVHandlerImplement
    {
        public void ImplementCSVHandler()
        {
            string importFilePath = @"D:\CSVHelperImplementation\CSVHelperImplementation_\Import.csv";
            string exportFilePath = @"D:\CSVHelperImplementation\CSVHelperImplementation_\Export.csv";
            using (var reader = new StreamReader(importFilePath))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<AddressData>().ToList();
                    Console.WriteLine("Read Data From CSV");
                    foreach (var data in records)
                    {
                        Console.WriteLine(data.Name + "---" + data.Email + "---" + data.Phone + "---" + data.Country);
                    }
                    using (var writer = new StreamWriter(exportFilePath))
                    {
                        using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                        {
                            csvExport.WriteRecords(records);
                        }
                    }
                }
            }
        }
        public void ImplementCSVHandlerJson()
        {
            string importFilePath = @"D:\CSVHelperImplementation\CSVHelperImplementation_\Import.csv";
            string ExportFilePath = @"D:\CSVHelperImplementation\CSVHelperImplementation_\Export.json";



            using (var reader = new StreamReader(importFilePath))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<AddressData>().ToList();
                    Console.WriteLine("Read data from CSV");
                    foreach (var data in records)
                    {
                        Console.WriteLine(data.Name + "---" + data.Email + "---" + data.Phone + "---" + data.Country);
                    }
                    JsonSerializer serializer = new JsonSerializer();
                    using (var writer = new StreamWriter(ExportFilePath))
                    {
                        using (var csvExport = new JsonTextWriter(writer))
                        {
                            serializer.Serialize(csvExport, records);
                        }
                    }
                }
            }
        }
        public void ImplementJsonToCsv()
        {
            string ImportFilePath = @"D:\CSVHelperImplementation\CSVHelperImplementation_\Export.json";
            string ExportFilePath = @"D:\CSVHelperImplementation\CSVHelperImplementation_\Sample.csv";
            List<AddressData> list = JsonConvert.DeserializeObject<List<AddressData>>(File.ReadAllText(ImportFilePath));
            using (var writer = new StreamWriter(ExportFilePath))
            {
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(list);
                }
            }
        }
    }
}
