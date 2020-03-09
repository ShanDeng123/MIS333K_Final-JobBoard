using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using sp19team23finalproject.Controllers;

namespace sp19team23finalproject.Models
{

    public class Interview
    {
        [Display(Name = "Interview ID")]
        public Int32 InterviewID { get; set; }

        [Required(ErrorMessage = "Please include an Interview Date")]
        [Display(Name = "Interview Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime InterviewDate { get; set; }

        [Display(Name = "Interview Time")]
        public InterviewTime InterviewTime { get; set; }

        //ask Katie if we need this
        [Display(Name = "Interview Status")]
        public Boolean InterviewStatus { get; set; }

        [Display(Name = "Interview Room")]
        public Int32 InterviewRoom { get; set; }

        //Interviewer
        public AppUser Recruiter { get; set; }

        public AppUser Student { get; set; }

        public Position Position { get; set; }

        //TODO: remove company after we show Katie
        public Company Company { get; set; }

    }
}
