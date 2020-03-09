using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sp19team23finalproject.Models
{
    public class Industry
    {
        //IndustryID
        [Display(Name = "Industry ID")]
        public Int32 IndustryID { get; set; }

        //Name
        [Display(Name = "Industry Name")]
        public String IndustryName { get; set; }


       //check this
       public List<Company> Companies { get; set; }

        public Industry()
        {
            if (Companies == null)
            {
                Companies = new List<Company>();
            }
        }
    }
}
