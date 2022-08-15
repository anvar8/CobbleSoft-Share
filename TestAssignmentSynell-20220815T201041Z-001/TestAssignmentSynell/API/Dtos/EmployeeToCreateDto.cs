

using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
     public class EmployeeToCreateDto
    {
        
        public string Payroll_Number { get; set; }
        
        public string Forenames { get; set; }
        
        public string Surname { get; set; }

        
        public string Date_of_Birth { get; set; }
        
        public string Telephone { get; set; }
        
        public string Mobile { get; set; }
        
        public string Address { get; set; }
        
        public string Address_2 { get; set; }
        
        public string Postcode { get; set; }
        
        public string EMail_Home { get; set; }
        

        public string Start_Date { get; set; }
    }
  
}

  // public class EmployeeToCreateDto
    // {
    //     [Required]
    //     public string Payroll_Number { get; set; }
    //     [Required]
    //     public string Forenames { get; set; }
    //     [Required]
    //     public string Surname { get; set; }

    //     [Required]
    //     public string Date_of_Birth { get; set; }
    //     [Required]
    //     public string Telephone { get; set; }
    //     [Required]
    //     public string Mobile { get; set; }
    //     [Required]
    //     public string Address { get; set; }
    //     [Required]
    //     public string Address_2 { get; set; }
    //     [Required]
    //     public string Postcode { get; set; }
    //     [Required]
    //     public string EMail_Home { get; set; }
    //     [Required]

    //     public string Start_Date { get; set; }
    // }