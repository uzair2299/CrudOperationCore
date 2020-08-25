
using CrudOperationCore.Models;
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
            Genders = new List<Gender>();
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

        /// <summary>
        /// I used a nullable bool for the WillAttend property. I did this so that I could apply the
        /// Required validation attribute.If I had used a regular bool , the value I received through model binding could be
        /// only true or false , and I would not be able to tell whether the user had selected a value.A nullable bool has
        /// three possible values: true , false , and null . The browser sends a null value if the user has not selected a
        /// value, and this causes the Required attribute to report a validation error.
        /// </summary>
        [Display(Name = "Is School Attend")]
        [Required(ErrorMessage = "Please specify your school status")]

        public bool? IsAttendSchool { get; set; }


        [Display(Name = "City")]
        [Required(ErrorMessage = "Please select your city")]

        public string SelectedCity { get; set; }
        public IEnumerable<SelectListItem> CitiesList { get; set; }
        [Display(Name = "Gender")]
        public int SelectedGender { get; set; }
      
        public List<Gender> Genders { get; set; }

    }
}
