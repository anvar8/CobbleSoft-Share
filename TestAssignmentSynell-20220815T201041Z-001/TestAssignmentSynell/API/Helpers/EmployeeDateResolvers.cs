using System;
using System.Globalization;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Infrastructure.Services.FileHandlers.CSV.Models;

namespace API.Helpers
{
    public class EmployeeDobResolver : IValueResolver<BatchEmployeeIn, Employee, DateTime>
    {

        public DateTime Resolve(BatchEmployeeIn source, Employee destination, DateTime destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Date_of_Birth))
            {

                try
                {
                    DateTime dt = DateTime.Parse(DateTime.ParseExact(source.Date_of_Birth, new string[] { "dd/MM/yyyy", "d/M/yyyy" }, CultureInfo.InvariantCulture).ToString("MM/dd/yyyy"));
                    return dt;
                }
                catch
                {
                    return DateTime.Parse(source.Date_of_Birth);
                }


            }
            return DateTime.Now;
        }
    }
    public class EmployeeStartDateResolver : IValueResolver<BatchEmployeeIn, Employee, DateTime>
    {

        public DateTime Resolve(BatchEmployeeIn source, Employee destination, DateTime destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Start_Date))
            {
                try
                {
                    DateTime dt = DateTime.Parse(DateTime.ParseExact(source.Start_Date, new string[] { "dd/MM/yyyy", "d/M/yyyy" }, CultureInfo.InvariantCulture).ToString("MM/dd/yyyy"));
                    // var date = DateTime.Parse(source.Start_Date,new CultureInfo("en-US", true));
                    return dt;
                }
                catch
                {
                    return DateTime.Parse(source.Start_Date);
                }

            }
            return DateTime.Now;
        }
    }
}