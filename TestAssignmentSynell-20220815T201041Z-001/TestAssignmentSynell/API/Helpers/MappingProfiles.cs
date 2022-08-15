using System;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Infrastructure.Services.FileHandlers.CSV.Models;

namespace API.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles() {
            CreateMap<Employee, EmployeeToReturnDto>();

            CreateMap<BatchEmployeeIn, Employee>().ForMember(d => d.Date_of_Birth, o => o.MapFrom<EmployeeDobResolver>()).ForMember(d => d.Start_Date, o => o.MapFrom<EmployeeStartDateResolver>());

            CreateMap<EmployeeToCreateDto, Employee>().ForMember(d => d.Date_of_Birth, o => o.MapFrom(s => DateTime.Parse(s.Date_of_Birth))).ForMember(d => d.Start_Date, o => o.MapFrom(s => DateTime.Parse(s.Start_Date)))
            .ForMember(d => d.Id, opt => opt.Ignore())
         
            .ForMember(d => d.Payroll_Number, opt => opt.Ignore());
        }
    }
}