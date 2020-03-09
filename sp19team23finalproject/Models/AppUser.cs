using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using sp19team23finalproject.Controllers;

namespace sp19team23finalproject.Models
{
    public class AppUser : IdentityUser
    {

        //Shared and Student attributes

        //Shared properties
        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }
        
        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        // ask Katie about active status (not in Excel); everyone is active all the time
        [Required(ErrorMessage = "Active Status is required")]
        [Display(Name = "Active Status")]
        public Boolean ActiveStatus { get; set; } = true;

        //student properties
        [DisplayFormat(DataFormatString = "{MM.dd.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }

        //phone and email are already included

        public Major Major { get; set; }
     
        [Display(Name = "Position Type")]
        public PositionDuration? PositionType { get; set; }

        [Display(Name = "Graduation Year")]
        public Int32? GradDate { get; set; }

        [Display(Name = "GPA")]
        public Decimal? GPA { get; set; }

        public List<Application> Applications { get; set; }

        //Recruiters
        public Company Company { get; set; }

        [InverseProperty("Recruiter")]
        public List<Interview> InterviewsGiven { get; set; }

        [InverseProperty("Student")]
        public List<Interview> InterviewsSuffered { get; set; }

        public AppUser()
        {
            if (Applications == null)
            {
                Applications = new List<Application>();
            }

            if (InterviewsGiven == null)
            {
                InterviewsGiven = new List<Interview>();
            }

            if (InterviewsSuffered == null)
            {
                InterviewsSuffered = new List<Interview>();
            }
        }
    }
}
