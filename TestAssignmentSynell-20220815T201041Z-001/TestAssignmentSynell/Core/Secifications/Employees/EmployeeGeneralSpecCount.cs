using Core.Entities;

namespace Core.Secifications.Employees
{
    public class EmployeeGeneralSpecCount : BaseSpecification<Employee>
    {
             public EmployeeGeneralSpecCount(EmployeeSpecParams employeeParams)

      : base(x =>
           string.IsNullOrEmpty(employeeParams.Search) ||
           x.Forenames.ToLower().Contains(employeeParams.Search.ToLower()) ||
           x.Surname.ToLower().Contains(employeeParams.Search.ToLower()) ||
           x.Telephone.ToLower().Contains(employeeParams.Search.ToLower()) ||
           x.Address.ToLower().Contains(employeeParams.Search.ToLower()) ||
           x.Address_2.ToLower().Contains(employeeParams.Search.ToLower()) ||
           x.EMail_Home.ToLower().Contains(employeeParams.Search.ToLower()) ||
           x.Postcode.ToLower().Contains(employeeParams.Search.ToLower()) 
           && true
           ) {}
    }
}