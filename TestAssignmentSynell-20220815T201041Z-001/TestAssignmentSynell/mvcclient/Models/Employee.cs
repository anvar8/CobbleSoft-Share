using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace mvcclient.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [DisplayName("Payroll Number")]
        public string Payroll_Number { get; set; }
        [Required]
        [DisplayName("Forenames")]
        public string Forenames { get; set; }
        [DisplayName("Surname")]
        public string Surname { get; set; }
        [DisplayName("Date of birth")]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date_of_Birth { get; set; }
        
        [DisplayName("Telephone")]
        public string Telephone { get; set; }

        [DisplayName("Mobile")]
        public string Mobile { get; set; }

        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("Address 2")]
        public string Address_2 { get; set; }

        [DisplayName("Postcode")]
        public string Postcode { get; set; }

        [DisplayName("Email Home")]
        public string EMail_Home { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Start Date")]
        public DateTime Start_Date { get; set; }

    }
}