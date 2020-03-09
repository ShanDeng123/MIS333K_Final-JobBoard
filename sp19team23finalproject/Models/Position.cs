using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using sp19team23finalproject.Controllers;

namespace sp19team23finalproject.Models
{
    public class Position
    {

        [Display(Name = "Position ID")]
        public Int32 PositionID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [Display(Name = "Title")]
        public String Title { get; set; }

        [Display(Name = "Position Type")]
        public PositionDuration PositionType { get; set; }

        public Company Company { get; set; }

        [Required(ErrorMessage = "Location is required")]
        [Display(Name = "Location")]
        public String Location { get; set; }

        [Required(ErrorMessage = "Deadline is required")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Deadline")]
        public DateTime Deadline { get; set; }

        [Display(Name = "Description")]
        public String Description { get; set; }

        public List<Application> Applications { get; set; }

        public List<Interview> Interviews { get; set; }

        //bridge table with majors
        [Display(Name = "Applicable Majors")]
        public List<PositionMajor> PositionMajors { get; set; }

        public Position()
        {
            if (Applications == null)
            {
                Applications = new List<Application>();
            }

            if (Interviews == null)
            {
                Interviews = new List<Interview>();
            }

            if (PositionMajors == null)
            {
                PositionMajors = new List<PositionMajor>();
            }
        }

    }

}
