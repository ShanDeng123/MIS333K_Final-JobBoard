using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace sp19team23finalproject.Models
{
    public class Major
    {
        [Display(Name = "Major ID")]
        public Int32 MajorID { get; set; }

        [Required(ErrorMessage = "Please Include a Major")]
        [Display(Name = "Major")]
        public String MajorName { get; set; }

        public List<AppUser> AppUsers { get; set; }

        [Display(Name = "Applicable Majors")]
        public List<PositionMajor> PositionMajors { get; set; }


        public Major()
        {
            if (AppUsers == null)
            {
                AppUsers = new List<AppUser>();
            }

            if (PositionMajors == null)
            {
                PositionMajors = new List<PositionMajor>();
            }
        }
    }
}
