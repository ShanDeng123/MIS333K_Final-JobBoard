using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sp19team23finalproject.DAL;
using sp19team23finalproject.Models;
using Microsoft.AspNetCore.Authorization;
using sp19team23finalproject.Utilities;


namespace sp19team23finalproject.Controllers
{
    public class ApplicationsController : Controller
    {
        private readonly AppDbContext _context;

        public ApplicationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Applications
        public async Task<IActionResult> Index()
        {
            List<Application> applications = new List<Application>();
            if (User.IsInRole("Recruiter"))
            {
                //TODO: might need to fix this so can see all applications for recruiter's company
                applications = _context.Applications.Include(p=>p.User).Where(e=>e.Status==true).Where(i => i.Position.Company.AppUsers.Any(e => e.UserName == User.Identity.Name)).Include(cd => cd.Position).ThenInclude(cd => cd.Company).ToList();
            }
            if (User.IsInRole("CSO"))
            {
                applications = _context.Applications.Include(p => p.User).Include(cd => cd.Position).ThenInclude(cd => cd.Company).ToList();
            }
            if (User.IsInRole("Student"))
            {
                applications = _context.Applications.Include(p => p.User).Where(a => a.User.UserName == User.Identity.Name).Include(cd => cd.Position).ThenInclude(cd => cd.Company).Include(cd => cd.User).ToList();
            }

            return View(applications);
        }

        // GET: Applications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications
                .FirstOrDefaultAsync(m => m.ApplicationID == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        [Authorize(Roles = "Student")]
        // GET: Applications/Create
        public IActionResult Create()
        {
            ViewBag.AllPositions = GetAllPositions();
            return View();
        }


        [Authorize(Roles = "Recruiter,CSO")]
        // GET: Applications/Create for Recruiter and CSO
        public IActionResult CreateStudent()
        {
            ViewBag.AllPositions = GetAllPositions();
            ViewBag.AllStudents = GetAllStudents();
            return View();
        }


        [Authorize(Roles = "Student")]
        // POST: Applications/Create for students
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicationID,Status,User")] Application application, int SelectedPosition)
        {
            application.ApplicationNumber = Utilities.GenerateApplicationNumber.GetNextApplicationNumber(_context);

            Position position = _context.Positions.Find(SelectedPosition);
            application.Position = position;

            application.Status = true;

            String id = User.Identity.Name;
            AppUser appuser = _context.AppUsers.FirstOrDefault(u => u.UserName == id);
            application.User = appuser;
            
            if (_context.Applications.Any(r => r.Position.PositionID == application.Position.PositionID && r.User.Id == application.User.Id))
            {
                return View("Error");
            }

            if (ModelState.IsValid)
            {
                _context.Add(application);
                await _context.SaveChangesAsync();  
                return RedirectToAction(nameof(Index));
            }
            ViewBag.AllPositions = GetAllPositions();
            return View(application);
        }


        [Authorize(Roles = "Recruiter,CSO")]
        // POST: Applications/Create for recruiters/CSO
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStudent([Bind("ApplicationID,Status,Accepted")] Application application, int SelectedPosition, string SelectedStudent)
        {
            application.ApplicationNumber = Utilities.GenerateApplicationNumber.GetNextApplicationNumber(_context);

            Position position = _context.Positions.Find(SelectedPosition);
            application.Position = position;

            application.Status = true;

            AppUser student = _context.AppUsers.Find(SelectedStudent);
            application.User = student;

            if (ModelState.IsValid)
            {
                _context.Add(application);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.AllPositions = GetAllPositions();
            ViewBag.AllStudents = GetAllStudents();
            return View(application);
        }





        // GET: Applications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }

            /*if (_context.Applications.Find(id).Position.Deadline > Controllers.HomeController.current_time)
            {
                return View("Error");
            }
            */

            return View(application);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicationID,Status,Accepted")] Application application)
        {

            if (id != application.ApplicationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(application);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationExists(application.ApplicationID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));

            }

            List<Application> applications = _context.Applications.ToList();
            bool applicationAccepted;

            foreach (Application a in applications)
            {
                applicationAccepted = (a.Accepted);

                if (applicationAccepted == true)
                {
                    String toEmailAddress = (a.User.Email);
                    String emailSubject = "Sign up for Interview";
                    String emailBody = "Please signup for an interview on the Interviews page";
                    EmailMessaging.SendEmail(toEmailAddress, emailSubject, emailBody);
                }

            }
            return View(application);
        }
        /*
        // GET: Applications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications
                .FirstOrDefaultAsync(m => m.ApplicationID == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var application = await _context.Applications.FindAsync(id);
            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        */
        private bool ApplicationExists(int id)
        {
            return _context.Applications.Any(e => e.ApplicationID == id);
        }

        public SelectList GetAllPositions()
        {

            if (User.IsInRole("Student"))
            {
                AppUser user = _context.Users.Include(u => u.Major).FirstOrDefault(u => u.UserName == User.Identity.Name);
                string userMajor = user.Major.MajorName;
                PositionDuration? pos_dur = user.PositionType;

                //TODO: fix so that student can't apply for position they already applied for (at the end of this)
                //code I tried: r.Applications.Any(p => p.User.UserName != user.UserName)
                List<Position> Positions = _context.Positions.Where(r => r.Deadline > Controllers.HomeController.current_time && r.PositionMajors.Any(p => p.Major.MajorName == userMajor) && r.PositionType == pos_dur).ToList();

                SelectList AllPositions = new SelectList(Positions, "PositionID", "Title");
                return AllPositions;
            }

            if (User.IsInRole("Recruiter"))
            {
                AppUser user = _context.Users.Include(u => u.Company).FirstOrDefault(u => u.UserName == User.Identity.Name);
                string userCompany = user.Company.CompanyName;


                //List<Position> Positions = _context.Positions.Where(r => r.Deadline > Controllers.HomeController.current_time ).ToList();
                List<Position> Positions = _context.Positions.Where(r => (r.Company.AppUsers.Any(e => e.UserName == User.Identity.Name)) && (r.Deadline > Controllers.HomeController.current_time)).ToList();
                SelectList AllPositions = new SelectList(Positions, "PositionID", "Title"); 
                return AllPositions;
            }

            else
            {
                List<Position> Positions = _context.Positions.Where(r => r.Deadline > Controllers.HomeController.current_time).ToList();

                SelectList AllPositions = new SelectList(Positions, "PositionID", "Title");
                return AllPositions;
            }




        }

        public SelectList GetAllStudents()
        {

            List<AppUser> students = _context.AppUsers.Where(u => (u.Major != null) && (u.ActiveStatus)).ToList();

            SelectList AllStudents = new SelectList(students, "Id", "FirstName", "LastName");
            return AllStudents;

        }




    }
}
