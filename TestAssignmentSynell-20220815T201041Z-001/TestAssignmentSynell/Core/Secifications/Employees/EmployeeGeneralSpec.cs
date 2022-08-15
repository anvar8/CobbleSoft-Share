using System;
using System.Reflection;
using Core.Entities;

namespace Core.Secifications.Employees
{
    public class EmployeeGeneralSpec : BaseSpecification<Employee>
    {
        public EmployeeGeneralSpec(EmployeeSpecParams employeeParams)

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
           )
        {
            ApplyPaging(employeeParams.PageSize * (employeeParams.PageIndex - 1), employeeParams.PageSize);
            
            if (employeeParams.Sort && !string.IsNullOrEmpty(employeeParams.SortingProp))
            {
             
                var propertyInfo = typeof(Employee).GetProperty(employeeParams.SortingProp.ToLower(), BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (propertyInfo != null)
                {
                    switch (employeeParams.SortDirection)
                    {
                        case SortDirectionEnum.ASC:
                            //  AddOrderBy(e => propertyInfo.GetValue(e, null));
                             AddOrderBy(e => e.Surname);
                           
                            // break;
                            break;
                        case SortDirectionEnum.DESC:
                            // AddOrderByDescending(e => propertyInfo.GetValue(e, null));   
                             AddOrderByDescending(e => e.Surname);   
                            break;
                        default:
                            AddOrderBy(e => e.Surname);
                            break;
                    }

                }
            } else {
                AddOrderBy(e => e.Surname); 
            }

        }
        public EmployeeGeneralSpec(int id) : base(x => x.Id == id)
        {

        }
        public EmployeeGeneralSpec() {
            
        }
    }

}