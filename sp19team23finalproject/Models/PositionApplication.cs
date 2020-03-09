using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sp19team23finalproject.Models
{
    public class PositionApplication
    {
        public int PositionApplicationID { get; set; }

        public Position Position { get; set; }
        public Application Application { get; set; }
    }
}
