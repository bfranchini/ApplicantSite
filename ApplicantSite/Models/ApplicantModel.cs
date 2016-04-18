using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApplicantSite.Models
{
    public class ApplicantModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Zip")]
        [RegularExpression(@"^[0-9]+$")]
        public string ZipCode { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[0-9]+$")]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Salary Required")]
        public string SalaryRequired { get; set; }

        [Required]
        [Display(Name = "Expertise Level")]
        public string Level_of_Expertise { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$")]
        [Display(Name = "Years of Experience")]
        public int YearsOfExperience { get; set; }

        [Required]
        [Display(Name = "Education Level")]
        public string EducationLevel { get; set; }
        public Nullable<bool> GoodRecruit { get; set; }

        public List<SelectListItem> ExpertiseLevels
        {
            get
            {
                return new List<SelectListItem>{
                new SelectListItem { Text = "Jr", Value=ExpertiseLevel.Jr.ToString()},
                new SelectListItem {Text = "Staff", Value = ExpertiseLevel.Staff.ToString() },
                new SelectListItem { Text = "Sr", Value = ExpertiseLevel.Sr.ToString()},
                new SelectListItem {Text = "Supervisor", Value=ExpertiseLevel.Supervisor.ToString() }};
            }
        }
    }

    public enum ExpertiseLevel
    {
        Jr, 
        Staff,
        Sr,
        Supervisor
    }
}