using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Secifications.Employees;

using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services.FileHandlers;
using Infrastructure.Services.FileHandlers.CSV.Models;

namespace API.Controllers
{
    public class EmployeeController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unitOfWork,

        IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        [Route("getemployees")]
        public async Task<ActionResult<Pagination<EmployeeToReturnDto>>> GetEmployees([FromQuery] EmployeeSpecParams employeeParams)
        {
            var spec = new EmployeeGeneralSpec(employeeParams);
            var countSpec = new EmployeeGeneralSpecCount(employeeParams);
            var totalItems = await _unitOfWork.Repository<Employee>().CountAsync(countSpec);
            var employees = await _unitOfWork.Repository<Employee>().ListAsync(spec);


            var data = _mapper.Map<IReadOnlyList<Employee>, IReadOnlyList<EmployeeToReturnDto>>(employees);
            return Ok(new Pagination<EmployeeToReturnDto>(employeeParams.PageIndex, employeeParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        [Route("getemployee")]

        public async Task<ActionResult<EmployeeToReturnDto>> GetEmployee([FromQuery] int id)
        {
            var spec = new EmployeeGeneralSpec(id);
            var employee = await _unitOfWork.Repository<Employee>().GetEntityWithSpec(spec);
            if (employee == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return _mapper.Map<Employee, EmployeeToReturnDto>(employee);
        }
        [HttpPost]

        public async Task<ActionResult<Employee>> CreateEmployee(EmployeeToCreateDto employeeToCreate)
        {
            var employee = _mapper.Map<EmployeeToCreateDto, Employee>(employeeToCreate);

            _unitOfWork.Repository<Employee>().Add(employee);
            var result = await _unitOfWork.Complete();
            if (result <= 0) return BadRequest(new ApiResponse(400, "Problem creating employee"));
            return Ok(employee);
        }
        [HttpPost]
        [Route("createbatch")]
        public async Task<ActionResult<Pagination<EmployeeToReturnDto>>> CreateFromBatch(IFormFile file)
        {

            List<BatchEmployeeIn> employees = new List<BatchEmployeeIn>();
            var fileDirector = new FileImportDirector<BatchEmployeeIn>(file.OpenReadStream(), Path.GetExtension(file.FileName), new EmployeeCSVMapStrategy());
            employees = fileDirector.GetObjectListFromStream();

            if (employees.Count > 0)
            {
                foreach (var employee in employees)
                {
                    var emplEntity = _mapper.Map<BatchEmployeeIn, Employee>(employee);

                    _unitOfWork.Repository<Employee>().Add(emplEntity);
                }
            }
            var result = await _unitOfWork.Complete();
            if (result <= 0) return BadRequest(new ApiResponse(400, "Problem creating employees"));
            return await GetEmployees(new EmployeeSpecParams());

        }
        [HttpPut("{id}")]
        [Route("updateemployee")]
        public async Task<ActionResult<Employee>> UpdateEmployee([FromQuery] int id, [FromBody] EmployeeToCreateDto employeeToUpdate)
        {
            var employee = await _unitOfWork.Repository<Employee>().GetByIdAsync(id);
            _mapper.Map(employeeToUpdate, employee);
            var employeed = employee;
            _unitOfWork.Repository<Employee>().Update(employee);
            var result = await _unitOfWork.Complete();
            if (result <= 0) return BadRequest(new ApiResponse(400, "Problem updating product"));
            return Ok(employee);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteEmployee([FromQuery] int id)
        {
            var employee = await _unitOfWork.Repository<Employee>().GetByIdAsync(id);
            _unitOfWork.Repository<Employee>().Delete(employee);
            var result = await _unitOfWork.Complete();
            if (result <= 0) return BadRequest(new ApiResponse(400, "Problem deleting product"));
            return Ok();

        }

    }
}