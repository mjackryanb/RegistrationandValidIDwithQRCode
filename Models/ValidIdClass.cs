using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ValidIdv3.Models
{
    public class ValidIdClass
    {
        [Required(ErrorMessage = "Enter your full name")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Enter your mobile number")]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Enter the date of visit")]
        [Display(Name = "Date of Visit")]
        public DateTime DateofVisit { get; set; }

        [Required(ErrorMessage = "Enter the department for the visit")]
        [Display(Name = "Department")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Enter the purpose of the visit")]
        [Display(Name = "Purpose of the Visit")]
        public string PurposeofVisit { get; set; }

        [Required(ErrorMessage = "Upload your Valid ID picture")]
        [Display(Name = "Upload Valid ID")]
        public string ValidID { get; set; }

        [Required(ErrorMessage = "Upload your selfie picture")]
        [Display(Name = "Upload Selfie")]
        public string Selfie { get; set; }
    }
}