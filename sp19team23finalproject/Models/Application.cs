using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sp19team23finalproject.Models
{
    public class Application
    {
        //ApplicationID
        public Int32 ApplicationID { get; set; }

        [Display(Name = "Application Number")]
        public Int32 ApplicationNumber { get; set; }

        //Status
        [Display(Name = "Application Status")]
        public Boolean Status { get; set; }

        [Display(Name = "Application Accepted")]
        public Boolean Accepted { get; set; }

        public Position Position { get; set; }
        public AppUser User { get; set; }
    }
}
