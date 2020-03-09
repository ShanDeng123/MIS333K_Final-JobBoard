using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sp19team23finalproject.Models;
using sp19team23finalproject.DAL;

namespace sp19team23finalproject.Controllers
{
    public class SeedController : Controller
    {
        private AppDbContext _db;

        public SeedController(AppDbContext context)
        {
            _db = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SeedMajors()
        {
            try
            {
                Seeding.SeedMajors.SeedAllMajors(_db);
            }
            catch (NotSupportedException ex)
            {
                return View("Error", new String[] { "The majors have already been added", ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return View("Error", new String[] { "There was an error adding majors to the database", ex.Message });
            }

            return View("Confirm");
        }

        public IActionResult SeedCompanies()
        {
            try
            {
                Seeding.SeedCompanies.SeedAllCompanies(_db);
            }
            catch (NotSupportedException ex)
            {
                return View("Error", new String[] { "The comapanies have already been added", ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return View("Error", new String[] { "There was an error adding companies to the database", ex.Message });
            }

            return View("Confirm");
        }

        public IActionResult SeedPositions()
        {
            try
            {
                Seeding.SeedNewPositions.SeedAllPositionsNew(_db);
            }
            catch (NotSupportedException ex)
            {
                return View("Error", new String[] { "The positions have already been added", ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return View("Error", new String[] { "There was an error adding positions to the database", ex.Message });
            }

            return View("Confirm");
        }

        public IActionResult SeedInterviews()
        {
            try
            {
                Seeding.SeedInterviews.SeedAllInterviews(_db);
            }
            catch (NotSupportedException ex)
            {
                return View("Error", new String[] { "The interviews have already been added", ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return View("Error", new String[] { "There was an error adding interviews to the database", ex.Message });
            }

            return View("Confirm");
        }

        public IActionResult SeedApplications()
        {
            try
            {
                Seeding.SeedApplications.SeedAllApplications(_db);
            }
            catch (NotSupportedException ex)
            {
                return View("Error", new String[] { "The applications have already been added", ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return View("Error", new String[] { "There was an error adding applications to the database", ex.Message });
            }

            return View("Confirm");
        }
    }
}
   