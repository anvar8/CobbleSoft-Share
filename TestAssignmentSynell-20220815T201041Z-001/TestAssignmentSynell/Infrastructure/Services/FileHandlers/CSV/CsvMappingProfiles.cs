using CsvHelper.Configuration;
using Infrastructure.Services.FileHandlers.CSV.Models;

namespace Infrastructure.Services.FileHandlers.CSV
{
    public sealed class EmployeeCsvMap : ClassMap<BatchEmployeeIn>
    {
        private const string append = "Personnel_Records.";
        public EmployeeCsvMap()
        {
           
            foreach (var prop in typeof(BatchEmployeeIn).GetProperties())
            {
                Map(typeof(BatchEmployeeIn), prop).Name(append + prop.Name);
            }

        }
    }
}


// Map(m => m.Payroll_Number).Name(append + "Payroll_Number");
// Map(m => m.Forenames).Name(append + "Forenames");
// Map(m => m.Surname).Name(append + "Surname");
// Map(m => m.Date_of_Birth).Name(append + "Date_of_Birth");
// Map(m => m.Telephone).Name(append + "Telephone");
// Map(m => m.Mobile).Name(append + "Mobile");
// Map(m => m.Address).Name(append + "Address");
// Map(m => m.Address_2).Name(append + "Address_2");
// Map(m => m.Postcode).Name(append + "Postcode");
// Map(m => m.EMail_Home).Name(append + "EMail_Home");
// Map(m => m.Start_Date).Name(append + "Start_Date");