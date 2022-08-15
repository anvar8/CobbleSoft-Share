
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Core.Interfaces;
using CsvHelper;


namespace Infrastructure.Services.FileHandlers.CSV
{
    public class CSVFileHandler<T> : FileService<T>
    {
        private readonly IStrategy _strategy;

        public CSVFileHandler(IStrategy strategy)
        {
            _strategy = strategy;
        }
        public CSVFileHandler()
        {

        }
        public override List<T> StreamToObjectList(Stream stream)
        {
            List<T> items;
            using (var reader = new StreamReader(stream))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                if (_strategy != null)
                {
                    _strategy.Config(false, csv);
                }

                items = csv.GetRecords<T>().ToList();
                reader.Close();
            }

            return items;
        }
    }
}