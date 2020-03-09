using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using sp19team23finalproject.Controllers;

//TODO: Change this namespace to match your project
namespace sp19team23finalproject.Models
{
   
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

      

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {

        //TODO:  Add any fields that you need for creating a new user
        //First name is provided as an example
        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "Birthday is required.")]
        [DisplayFormat(DataFormatString = "{MM.dd.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birthday")]
        public DateTime? Birthday { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        [Display(Name = "Location")]
        public String Location { get; set; }

        //[Required(ErrorMessage = "Major is required.")]
        public Major Major { get; set; }

        //[Required(ErrorMessage = "Position Type is required.")]
        [Display(Name = "Position Type")]
        public PositionDuration? PositionType { get; set; }

        [Required(ErrorMessage = "Graudation Date is required.")]
        [DisplayFormat(DataFormatString = "{MM.dd.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Graduation Date")]
        public Int32? GradDate { get; set; }

        [Required(ErrorMessage = "GPA is required.")]
        [Display(Name = "GPA")]
        public Decimal? GPA { get; set; }

        // ask Katie about active status (not in Excel); everyone is active all the time
        [Required(ErrorMessage = "Active Status is required")]
        [Display(Name = "Active Status")]
        public Boolean ActiveStatus { get; set; }

        //NOTE: Here is the property for email
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
      

        //NOTE: Here is the logic for putting in a password
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class RecRegisterViewModel
    {

        //TODO:  Add any fields that you need for creating a new user
        //First name is provided as an example
        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "Active Status is required")]
        [Display(Name = "Active Status")]
        public Boolean ActiveStatus { get; set; }


        //[Required(ErrorMessage = "Major is required.")]
        public Company Company { get; set; }


        //NOTE: Here is the property for email
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //NOTE: Here is the logic for putting in a password
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class CSORegisterViewModel
    {

        //TODO:  Add any fields that you need for creating a new user
        //First name is provided as an example
        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        //NOTE: Here is the property for email
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //NOTE: Here is the logic for putting in a password
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Active Status is required")]
        [Display(Name = "Active Status")]
        public Boolean ActiveStatus { get; set; }

    }


    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class EditViewModel
    {

        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }




        [Required(ErrorMessage = "Birthday is required.")]
        [DisplayFormat(DataFormatString = "{MM.dd.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birthday")]
        public DateTime? Birthday { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        [Display(Name = "Location")]
        public String Location { get; set; }

        //[Required(ErrorMessage = "Major is required.")]
        public Major Major { get; set; }

        //[Required(ErrorMessage = "Position Type is required.")]
        [Display(Name = "Position Type")]
        public PositionDuration? PositionType { get; set; }

        [Required(ErrorMessage = "Graudation Date is required.")]
        [DisplayFormat(DataFormatString = "{MM.dd.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Graduation Date")]
        public Int32? GradDate { get; set; }

        [Required(ErrorMessage = "GPA is required.")]
        [Display(Name = "GPA")]
        public Decimal? GPA { get; set; }

        // ask Katie about active status (not in Excel); everyone is active all the time
        [Required(ErrorMessage = "Active Status is required")]
        [Display(Name = "Active Status")]
        public Boolean ActiveStatus { get; set; }

        //NOTE: Here is the property for email
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //NOTE: Here is the property for phone number
        [Required(ErrorMessage = "Phone number is required")]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        //NOTE: Here is the logic for putting in a password
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

        public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public String UserName { get; set; }
        public String Email { get; set; }
        public String UserID { get; set; }

    }
}
