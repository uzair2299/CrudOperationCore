
using CrudOperationCore.Pagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperationCore.ViewModel
{
    public class UserViewModel
    {

        public UserViewModel()
        {
            ProvincesList = new List<SelectListItem>();
            //CitiesList = new List<SelectListItem>();
        }
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [Display(Name = "User Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your father name")]
        [Display(Name = "Father Name")]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "Please enter your contact #")]
        [Display(Name = "Contact # ")]
        public string ContactNo { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Please enter your valid Email address")]
        [Display(Name = "User Email")]
        public string Email { get; set; }

        [Display(Name = "Home Address")]
        public string HomeAddress { get; set; }

        [Display(Name = "Residentail Address")]
        public string ResidentailAddress { get; set; }

        [Display(Name = "Profile Image")]
        public IFormFile ProfileImage { get; set; }
        public String ProfileImagePath { get; set; }

        [Display(Name="Provice")]
        [Required(ErrorMessage = "Please select your provice")]
        public string SelectedProvince { get; set; }
        public List<SelectListItem> ProvincesList { get; set; }


        [Display(Name = "Is School Attend")]
        [Required(ErrorMessage = "Please specify your school status")]

        public bool? IsAttendSchool { get; set; }


        [Display(Name = "City")]
        [Required(ErrorMessage = "Please select your city")]

        public string SelectedCity { get; set; }
        public IEnumerable<SelectListItem> CitiesList { get; set; }

    }
}
