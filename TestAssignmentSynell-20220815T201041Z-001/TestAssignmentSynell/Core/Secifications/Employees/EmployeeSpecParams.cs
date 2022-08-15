namespace Core.Secifications.Employees
{
    public class EmployeeSpecParams
    {
        private const int MaxPageSize = 50;
        public int PageIndex {get; set;} = 1; 
        private int _pageSize = 10; //backing private field for evaluation in PageSize property in setter method
        public int PageSize {
            get => _pageSize; 
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
 
        public bool Sort {get; set;}
        public SortDirectionEnum SortDirection {get; set;}
        public string SortingProp {get; set;}
        private string _search; //backing field to modify it in property
        public string Search {
            get => _search; 
            set {
                if (!string.IsNullOrEmpty(value)) {
                    _search = value; 
                } else {
                    _search = "";
                }
            }
        }
    }
}