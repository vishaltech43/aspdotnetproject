using System.Reflection;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        [Display(Name = "Enter Employee Id")]
        [Required(ErrorMessage = "Please enter the id ")]
        
        public int EmployeeId { get; set; }


        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "The name contain only letters")]
        [Display(Name = "Enter Employee name")]
        [StringLength(12, ErrorMessage = "Name cannot exceed 12 characters")]
        public string Name { get; set; }

        [Display(Name = "Enter Employee Job Title")]
        [Required(ErrorMessage = "Please select employee job title")]
        public string JobTitle { get; set; }

        [Display(Name = "Enter Employee Job Type")]

        [Required(ErrorMessage = "Please select employee job type ")]
        public string EmployeeType { get; set; }

        [Display(Name = "Enter Employee Date of Joining")]
        [DateVaildation(ErrorMessage = "Date of Joining cannot be a future date")]
        public DateTime DateOfJoining { get; set; }

        [Range(1, int.MaxValue,ErrorMessage ="the salary must be greator than 0")]
        public int Salary { get; set; }
    }

    //custom validation for date 
    public class DateVaildation : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime date)
            {
                if(date>DateTime.Now)
                {

                    return new ValidationResult(ErrorMessage);
                }
             
            }
            return ValidationResult.Success;
        }

    }
        
        }
