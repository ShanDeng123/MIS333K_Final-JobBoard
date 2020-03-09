
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sp19team23finalproject.DAL;
using sp19team23finalproject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace sp19team23finalproject.Controllers
{

    public enum PositionDuration { FT, I, All }

    public class HomeController : Controller
    {
        //set variable for current time that users can change
        public static DateTime current_time { get; set; }

        private AppDbContext _db;


        public HomeController(AppDbContext context)
        {
            _db = context;
        }

        [Authorize]
        public ActionResult Index(string UserSearchString)
        {
            if (User.IsInRole("CSO"))
            {
                var query = from u in _db.Users
                            where u.GradDate != null 
                            select u;

                if (UserSearchString != null)
                {
                    query = query.Where(u => u.FirstName.Contains(UserSearchString) || u.LastName.Contains(UserSearchString));
                }

                List<AppUser> userQuery = query.Include(u => u.Major).ToList();

                ViewBag.AllUserCount = _db.Users.Count();
                ViewBag.SelectedUserCount = userQuery.Count();
                return View(userQuery.OrderByDescending(u => u.PositionType).ThenBy(u => u.LastName).ThenBy(u => u.FirstName));
                //return RedirectToAction("Index", "Seed");

            }

            else
            {
                var query = from u in _db.Users
                            where u.GradDate != null && u.ActiveStatus
                            select u;

                if (UserSearchString != null)
                {
                    query = query.Where(u => u.FirstName.Contains(UserSearchString) || u.LastName.Contains(UserSearchString));
                }

                List<AppUser> userQuery = query.Include(u => u.Major).ToList();

                ViewBag.AllUserCount = _db.Users.Count();
                ViewBag.SelectedUserCount = userQuery.Count();
                return View(userQuery.OrderByDescending(u => u.PositionType).ThenBy(u => u.LastName).ThenBy(u => u.FirstName));
                //return RedirectToAction("Index", "Seed");
            }




        }

        [Authorize(Roles = "CSO")]
        public ActionResult ViewRecruiter()
        {
            var query = from u in _db.Users
                        where u.Company != null
                        select u;


            List<AppUser> userQuery = query.Include(u => u.Company).ToList();

            ViewBag.AllUserCount = _db.Users.Count();
            ViewBag.SelectedUserCount = userQuery.Count();

            return View(userQuery);
            //return RedirectToAction("Index", "Seed");
        }

        [Authorize(Roles = "CSO")]
        public ActionResult ViewCSO()
        {
            var query = from u in _db.Users
                        where ((u.Company == null) && (u.Major == null))
                        select u;


            List<AppUser> userQuery = query.ToList();

            ViewBag.AllUserCount = _db.Users.Count();
            ViewBag.SelectedUserCount = userQuery.Count();

            return View(userQuery);
            //return RedirectToAction("Index", "Seed");
        }

        //GET: ChangeTime
        public ActionResult ChangeTime()
        {
            ViewBag.timerightnow = current_time;
            return View();
        }
        //POST: ChangeTime
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangeTime (DateTime enterred_time)
        {
            current_time = enterred_time;
            ViewBag.timerightnow = enterred_time;
            return View();
        }


        //GET: Details (for Student Profiles)
        public IActionResult Details(string id)
        {
            if (id == "")
            {
                return NotFound();
            }

            //update this statement to have an include clause to get the order details
            //and showing information
            AppUser student = _db.Users.Include(c => c.Major).FirstOrDefault(b => b.Id == id);

            if (student == null) //student does not exist in database
            {
                return View("Error", new String[] { "Student not found in database" });
            }

            //if code gets this far, all is well
            return View(student);



        }

        //GET: Details (for Recruiter Profiles)
        public IActionResult DetailsRecruiter(string id)
        {
            if (id == "")
            {
                return NotFound();
            }

            //update this statement to have an include clause to get the order details
            //and showing information
            AppUser rec = _db.Users.Include(c => c.Company).FirstOrDefault(b => b.Id == id);

            if (rec == null) //student does not exist in database
            {
                return View("Error", new String[] { "Student not found in database" });
            }

            //if code gets this far, all is well
            return View(rec);

        }

        //GET: Details (for Recruiter Profiles)
        public IActionResult DetailsCSO(string id)
        {
            if (id == "")
            {
                return NotFound();
            }

            //update this statement to have an include clause to get the order details
            //and showing information
            AppUser cso = _db.Users.FirstOrDefault(b => b.Id == id);

            if (cso == null) //student does not exist in database
            {
                return View("Error", new String[] { "Student not found in database" });
            }

            //if code gets this far, all is well
            return View(cso);



        }





        public SelectList GetAllMajors()
        {
            List<Major> majors = _db.Majors.ToList();

            //convert list to select list
            //MajorID and MajorName are names of the properties on the Major class
            //MajorID is the Primary Key 
            SelectList AllMajors = new SelectList(majors.OrderBy(m => m.MajorID), "MajorID", "MajorName");

            //return the select list
            return AllMajors;

        }


        /*public ActionResult Index(string UserSearchString)
        {
            return View();
        }
        */


            //return RedirectToAction("Index", "Seed");
       

        public ActionResult StudentDetailedSearch()
        {
            ViewBag.Majors = GetAllMajors();
            return View();
        }

        public ActionResult DisplaySearchResults(string SearchName, decimal SearchGPA, int[] SelectedMajors, int SearchAGrad, int SearchBGrad, PositionDuration PType)
        {
            var query = from b in _db.Users
                        where b.GradDate != null && b.ActiveStatus
                        select b;

            if (!string.IsNullOrEmpty(SearchName))

            {
                query = query.Where(b => b.LastName.Contains(SearchName) || b.FirstName.Contains(SearchName));

            }

            if (SelectedMajors.Any())

            {
                //Not Sure How to make this work
                query = query.Where(b => SelectedMajors.Contains(b.Major.MajorID));

            }
            
            if (SearchGPA != default(decimal))

            {
                query = query.Where(b => b.GPA >= SearchGPA);

            }

            if (SearchAGrad != default(int))
            {
                //DateTime sDate = SearchDate ?? new DateTime(1900, 1, 1);

                query = query.Where(b => b.GradDate >= SearchAGrad);
            }

            if (SearchBGrad != default(int))
            {
    
                query = query.Where(b => b.GradDate <= SearchBGrad);
            }

            switch (PType)
            {
                case PositionDuration.FT:
                    query = query.Where(b => b.PositionType == PositionDuration.FT);
                    break;
                case PositionDuration.I:
                    query = query.Where(b => b.PositionType == PositionDuration.I);
                    break;
                case PositionDuration.All:
                    break;
            }

            List<AppUser> userQuery = query.Include(b => b.Major).ToList();

            ViewBag.AllBookCount = _db.Users.Count();
            ViewBag.SelectedBookCount = userQuery.Count();

            //ViewBag.AllGenres = GetAllGenres();

            return View("Index", userQuery.OrderByDescending(b => b.PositionType).ThenBy(b => b.LastName).ThenBy(b => b.FirstName));
        }


    }

            
        



}

