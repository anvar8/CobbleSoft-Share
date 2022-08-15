using System.Collections.Generic;
using System.ComponentModel;

namespace mvcclient.Models
{
    public class EmployeeViewModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        // [DisplayName("hello")]
        public IReadOnlyList<Employee> Data { get; set; }
    }
}