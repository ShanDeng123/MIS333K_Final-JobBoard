using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sp19team23finalproject.DAL;

namespace sp19team23finalproject.Utilities
{
    public class GenerateApplicationNumber
    {
        public static Int32 GetNextApplicationNumber(AppDbContext _context)
        {


            Int32 intMaxApplicationNumber; //the current maximum course number
            Int32 intNextApplicationNumber; //the course number for the next class

            if (_context.Applications.Count() == 0) //there are no courses in the database yet
            {
                intMaxApplicationNumber = 1000; //course numbers start at 3001
            }
            else
            {
                intMaxApplicationNumber = _context.Applications.Max(c => c.ApplicationNumber); //this is the highest number in the database right now
            }

            //add one to the current max to find the next one
            intNextApplicationNumber = intMaxApplicationNumber + 1;

            //return the value
            return intNextApplicationNumber;
        }
    }
}
