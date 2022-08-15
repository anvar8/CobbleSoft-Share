

using System.Threading.Tasks;
using Core.Interfaces;
using CsvHelper;
using Infrastructure.Services.FileHandlers.CSV;

namespace Infrastructure.Services.FileHandlers
{
    public class EmployeeCSVMapStrategy : IStrategy
    {


        public void Config(bool needReturn, object data)
        {
            if (data != null)
            {
                var csv = data as CsvReader;
                csv.Context.RegisterClassMap<EmployeeCsvMap>();
            }
      

        }

        public object ReturnFromConfig(object data)
        {
            throw new System.NotImplementedException();
        }
    }
}