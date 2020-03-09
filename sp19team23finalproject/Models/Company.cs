using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace sp19team23finalproject.Models
{
    public class Company
    {

        [Display(Name = "Company ID")]
        public Int32 CompanyID { get; set; }

        //Comapny Name
        [Required(ErrorMessage = "Please include a comapny name.")]
        [Display(Name = "Company Name")]
        public String CompanyName { get; set; }

        //Email address
        [Required(ErrorMessage = "Please include an email for this company.")]
        [Display(Name = "Company Email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public String Email { get; set; }

        //Description
        //is description nullable?
        [Display(Name = "Description")]
        public String CompanyDescription { get; set; }

        [Display(Name = "Industry")]
        public String Industry { get; set; }


        public List<AppUser> AppUsers { get; set; }
        public List<Position> Positions { get; set; }
        public List<Interview> Interviews { get; set; }


        public Company()
        {
            if (AppUsers == null)
            {
                AppUsers = new List<AppUser>();
            }

            if (Positions == null)
            {
                Positions = new List<Position>();
            }

            if (Interviews == null)
            {
                Interviews = new List<Interview>();
            }
        }
        
    }
}
