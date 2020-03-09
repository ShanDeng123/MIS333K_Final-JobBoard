using System;
using System.ComponentModel.DataAnnotations;

namespace sp19team23finalproject.Models
{
    public class PositionMajor
    {
        //ApplicationID
        [Display(Name = "PositionMajor ID")]
        public Int32 PositionMajorID { get; set; }

        public Position Position { get; set; }
        public Major Major { get; set; }
    }
}
