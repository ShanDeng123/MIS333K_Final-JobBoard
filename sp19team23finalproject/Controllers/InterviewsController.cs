using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sp19team23finalproject.DAL;
using sp19team23finalproject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using sp19team23finalproject.Utilities;

namespace sp19team23finalproject.Controllers
{
    public enum InterviewTime { time8, time9, time10, time11, time1, time2, time3, time4 }

    public class InterviewsController : Controller
    {
        private readonly AppDbContext _context;

        public InterviewsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Interviews
        public IActionResult Index()
        {

            List<Interview> interviews = new List<Interview>();
            if (User.IsInRole("CSO"))
            {
                interviews = _context.Interviews.Include(i => i.Company).Include(i => i.Position).ToList(); 
            }
            //update so recruiter can see all interviews
            if (User.IsInRole("Recruiter"))
            {
                //TODO: Figure out why it's not filtering out based on company ID
                //interviews = _context.Interviews.Include(i => i.Company).Where(i => i.Company.AppUsers.Contains(AppUser User)).Include(i => i.Position).ToList();
                interviews = _context.Interviews.Where(i => i.Company.AppUsers.Any(e => e.UserName == User.Identity.Name)).Include(cd => cd.Company).Include(i => i.Position).ToList();
            }
            if (User.IsInRole("Student"))
            {
                
                //List<Position> positions = new List<Position>();
                //positions = _context.Positions.Where(i => i.Applications.Any(a => a.Accepted == true)).ToList();
                //interviews = _context.Interviews.Include(i => i.Student.UserName == User.Identity.Name(i => i.Student.UserName == User.Identity.Name).Include(i => i.Applications.Any(a => a.Accepted == true)).Include(i => i.Position).Include(i => i.Company).ToList();
                
                interviews = _context.Interviews.Include(i => i.Position).Where(p => p.Position.Applications.Any(e => e.Accepted == true)).Where(p => p.Position.Applications.Any(r => r.User.UserName == User.Identity.Name)).Include(c => c.Company).ToList();

            }
            return View(interviews);
        }

        // GET: Interviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Interview interview = await _context.Interviews
                            .Include(c => c.Recruiter).Include(c => c.Student).Include(c => c.Position)
                            .FirstOrDefaultAsync(m => m.InterviewID == id);
            /*
            var interview = await _context.Interviews
                .FirstOrDefaultAsync(m => m.InterviewID == id);

            */
            if (interview == null)
            {
                return NotFound();
            }

            return View(interview);
        }

        // GET: Interviews/Create
        [Authorize(Roles = "Recruiter,CSO")]
        public IActionResult Create()
        {
            ViewBag.AllRecruiters = GetAllRecruiters();
            ViewBag.AllPositions = GetAllPositions();
            ViewBag.AllCompanies = GetAllCompanies();
            ViewBag.AllStudents = GetAllStudents();
            ViewBag.AllTimes = new SelectList(Enum.GetValues(typeof(InterviewTime)));

            return View();
        }

        [Authorize(Roles = "Recruiter,CSO")]
        // POST: Interviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("InterviewID,InterviewDate,InterviewTime,InterviewStatus,InterviewRoom,Recruiter")] Interview interview, string SelectedRecruiter, int SelectedPosition, int SelectedCompany)

        {
            List<Interview> interviews = new List<Interview>();
            interviews = _context.Interviews.ToList();
            foreach (Interview inter in interviews)
            {
                if ((inter.InterviewDate == interview.InterviewDate) && (inter.InterviewTime == interview.InterviewTime) && (inter.InterviewRoom == interview.InterviewRoom))
                {
                    return View("Error");
                }
            }
            AppUser recruiter = _context.AppUsers.Find(SelectedRecruiter);
            interview.Recruiter = recruiter;

            Position position = _context.Positions.Find(SelectedPosition);
            interview.Position = position;

            Company company = _context.Companies.Find(SelectedCompany);
            interview.Company = company;
            
            /*
            Int32 interviewID = 
            List<Interview> interviews = _context.Interviews.Include(i => i.Position).Find(i => i.InterviewID ==).ToList();
            DateTime interviewDate;

            foreach (Interview i in interviews)
            {
                interviewDate = i.InterviewDate;
                DateTime minimumDate = i.Position.Deadline.AddDays(2);
                if (interviewDate < minimumDate)
                {
                    return RedirectToAction("Error");
                }
            }
            */

            if (ModelState.IsValid)
            {
                _context.Add(interview);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.AllRecruiters = GetAllRecruiters();
            ViewBag.AllPositions = GetAllPositions();
            ViewBag.AllCompanies = GetAllCompanies();
            ViewBag.AllStudents = GetAllStudents();
            return View(interview);
        }



        // GET: Interviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Interview interview = _context.Interviews
                .Include(c => c.Position)
                .Include(c => c.Company)
                .Include(c => c.Recruiter).Include(c => c.Student)
                .FirstOrDefault(ord => ord.InterviewID == id);


            if (interview == null)
            {
                return NotFound();
            }
           
            ViewBag.AllStudents = GetAllStudents(interview.InterviewID);
            ViewBag.AllRecruiters = GetAllRecruiters(interview.InterviewID);
            ViewBag.AllCompanies = GetAllCompanies(interview.InterviewID);
            ViewBag.AllPositions = GetAllPositions(interview.InterviewID);
            ViewBag.AllTimes = new SelectList(Enum.GetValues(typeof(InterviewTime)));
            return View(interview);
        }

        // POST: Interviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InterviewID,InterviewDate,InterviewTiime,InterviewStatus,InterviewRoom,Recruiter,Student")] Interview interviewww, string SelectedRecruiter, int SelectedPosition, string SelectedStudent, int SelectedCompany)
        {
            //List<Interview> interviews = new List<Interview>();
            //interviews = _context.Interviews.ToList();
            ////foreach (Interview inter in interviews)
            //{
            //    if ((inter.InterviewDate == interviewww.InterviewDate) && (inter.InterviewTime == interviewww.InterviewTime) && (inter.InterviewRoom == interviewww.InterviewRoom))
            //    {
            //        return View("Error");
            //    }


            //}

            AppUser recruiter = _context.AppUsers.Find(SelectedRecruiter);
            interviewww.Recruiter = recruiter;

            Position position = _context.Positions.Find(SelectedPosition);
            interviewww.Position = position;

            Company company = _context.Companies.Find(SelectedCompany);
            interviewww.Company = company;

            AppUser student = _context.AppUsers.Find(SelectedStudent);
            interviewww.Student = student;

            if (ModelState.IsValid)
            {
                _context.Update(interviewww);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            List<Interview> interviewsss = _context.Interviews.ToList();
            AppUser interviewStatus;

            foreach (Interview i in interviewsss)
            {
                interviewStatus = (i.Student);

                if (interviewStatus != null)
                {

                    String toEmailAddress = (i.Student.Email);
                    String emailSubject = "Interview Confirmation";
                    String emailBody = "Interview Date: " + i.InterviewDate + "Interview Time: " + i.InterviewTime + "Interview Room: " + i.InterviewRoom + "Interview Position: " + i.Position + "Interviewer: " + i.Recruiter;
                    EmailMessaging.SendEmail(toEmailAddress, emailSubject, emailBody);
                }

            }

            ViewBag.AllRecruiters = GetAllRecruiters();
            ViewBag.AllPositions = GetAllPositions();
            ViewBag.AllCompanies = GetAllCompanies();
            ViewBag.AllStudents = GetAllStudents();
            ViewBag.AllTimes = new SelectList(Enum.GetValues(typeof(InterviewTime)));
            return View(interviewww);
        }

        //// GET: Interviews/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var interview = await _context.Interviews
        //        .FirstOrDefaultAsync(m => m.InterviewID == id);
        //    if (interview == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(interview);
        //}

        //// POST: Interviews/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var interview = await _context.Interviews.FindAsync(id);
        //    _context.Interviews.Remove(interview);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool InterviewExists(int id)
        //{
        //    return _context.Interviews.Any(e => e.InterviewID == id);
        //}



        public SelectList GetAllRecruiters()
        {
            if (User.IsInRole("Recruiter"))
            {
                AppUser user = _context.AppUsers.Include(u => u.Company).FirstOrDefault(u => u.UserName == User.Identity.Name);
                Company userCompany = _context.Companies.FirstOrDefault(u => u.CompanyID == user.Company.CompanyID);


                List<AppUser> recruiters = _context.AppUsers.Where(u => u.Major == null && u.Company.CompanyID == userCompany.CompanyID).ToList();

                SelectList AllRecruiters = new SelectList(recruiters, "Id", "FirstName", "LastName");
                return AllRecruiters;
            }
            else
            {
                List<AppUser> recruiters = _context.AppUsers.Where(u => u.Major == null && u.Company == null).ToList();

                SelectList AllRecruiters = new SelectList(recruiters, "Id", "FirstName", "LastName");
                return AllRecruiters;
            }

        }

        public SelectList GetAllRecruiters(Int32 interviewID)
        {
            if (User.IsInRole("Recruiter"))
            {
                List<Interview> interviews = _context.Interviews.Where(i => i.InterviewID == interviewID).ToList();


                AppUser user = _context.AppUsers.Include(u => u.Company).FirstOrDefault(u => u.UserName == User.Identity.Name);
                Company userCompany = _context.Companies.FirstOrDefault(u => u.CompanyID == user.Company.CompanyID);


                List<AppUser> recruiters = _context.AppUsers.Where(u => u.Major == null && u.Company.CompanyID == userCompany.CompanyID).ToList();


                string selectedRecruiter;

                foreach (Interview i in interviews)
                {
                    selectedRecruiter = (i.Recruiter.Id);
                }


                SelectList AllRecruiters = new SelectList(recruiters, "Id", "FirstName", "LastName");
                return AllRecruiters;

            }
            else
            {
                List<AppUser> recruiters = _context.AppUsers.Where(u => u.Major == null && u.Company != null).ToList();


                SelectList AllRecruiters = new SelectList(recruiters, "Id", "FirstName", "LastName");
                return AllRecruiters;
            }

        }

        public SelectList GetAllStudents()
        {

            List<AppUser> students = _context.AppUsers.Where(u => (u.Major != null) && (u.ActiveStatus == true)).ToList();

            SelectList AllStudents = new SelectList(students, "Id", "FirstName", "LastName");
            return AllStudents;

        }

        public SelectList GetAllStudents(Int32 interviewID)
        {
            
            List<AppUser> students = _context.AppUsers.Where(u => u.Major != null).ToList();


            List<Interview> interviews = _context.Interviews.Where(i => i.InterviewID == interviewID).ToList();

            //string selectedStudent;

            //foreach (Interview i in interviews)
            //{
            //    selectedStudent = (i.Student.Id);
            //}

            SelectList AllStudents = new SelectList(students, "Id", "FirstName", "LastName");
            return AllStudents;

        }


        public SelectList GetAllPositions()
        {
            if (User.IsInRole("Recruiter"))
            {
                AppUser user = _context.Users.Include(u => u.Major).FirstOrDefault(u => u.UserName == User.Identity.Name);
                Company userCompany = _context.Companies.FirstOrDefault(u => u.CompanyID == user.Company.CompanyID);

                List<Position> Positions = _context.Positions.Include(p => p.Company).Where(r => r.Deadline < Controllers.HomeController.current_time && r.Company.CompanyID == userCompany.CompanyID).ToList();

                SelectList AllPositions = new SelectList(Positions, "PositionID", "Title");
                return AllPositions;

            }
            else
            {
                List<Position> Positions = _context.Positions.Include(p => p.Company).Where(r => r.Deadline < Controllers.HomeController.current_time).ToList();

                SelectList AllPositions = new SelectList(Positions, "PositionID", "Title");
                return AllPositions;
            }



        }

        public SelectList GetAllPositions(Int32 interviewID)
        {
            if (User.IsInRole("Recruiter"))
            {
                AppUser user = _context.Users.Include(u => u.Major).FirstOrDefault(u => u.UserName == User.Identity.Name);
                Company userCompany = _context.Companies.FirstOrDefault(u => u.CompanyID == user.Company.CompanyID);

                List<Position> Positions = _context.Positions.Include(p => p.Company).Where(r => r.Deadline < Controllers.HomeController.current_time && r.Company.CompanyID == userCompany.CompanyID).ToList();


                List<Interview> interviews = _context.Interviews.Where(i => i.InterviewID == interviewID).ToList();

                List<Int32> selectedPositions = new List<Int32>();

                foreach (Interview i in interviews)
                {
                    selectedPositions.Add(i.InterviewID);
                }
                SelectList AllPositions = new SelectList(Positions, "PositionID", "Title");
                return AllPositions;
            }
            else
            {
                List<Position> Positions = _context.Positions.Include(p => p.Company).Where(r => r.Deadline < Controllers.HomeController.current_time).ToList();
                SelectList AllPositions = new SelectList(Positions, "PositionID", "Title");
                return AllPositions;
            }


        }

        public SelectList GetAllCompanies()
        {
            if (User.IsInRole("Recruiter"))
            {
                AppUser user = _context.AppUsers.Include(u => u.Company).FirstOrDefault(u => u.UserName == User.Identity.Name);
                Company userCompany = _context.Companies.FirstOrDefault(u => u.CompanyID == user.Company.CompanyID);

                List<Company> Companies = _context.Companies.Where(c => c.CompanyID == userCompany.CompanyID).ToList();

                SelectList AllCompanies = new SelectList(Companies, "CompanyID", "CompanyName");
                return AllCompanies;
            }
            else
            {
                List<Company> Companies = _context.Companies.ToList();

                SelectList AllCompanies = new SelectList(Companies, "CompanyID", "CompanyName");
                return AllCompanies;
            }


        }

        public SelectList GetAllCompanies(int interviewID)
        {
            if (User.IsInRole("Recruiter"))
            {
                AppUser user = _context.AppUsers.Include(u => u.Company).FirstOrDefault(u => u.UserName == User.Identity.Name);
                Company userCompany = _context.Companies.FirstOrDefault(u => u.CompanyID == user.Company.CompanyID);

                List<Company> Companies = _context.Companies.Where(c => c.CompanyID == userCompany.CompanyID).ToList();
                List<Interview> interviews = _context.Interviews.Where(i => i.InterviewID == interviewID).ToList();

                List<Int32> selectedCompany = new List<Int32>();

                foreach (Interview i in interviews)
                {
                    selectedCompany.Add(i.InterviewID);
                }

                SelectList AllCompanies = new SelectList(Companies, "CompanyID", "CompanyName");
                return AllCompanies;

            }
            else
            {
                List<Company> Companies = _context.Companies.ToList();
                SelectList AllCompanies = new SelectList(Companies, "CompanyID", "CompanyName");
                return AllCompanies;

            }


        }


    }
}
