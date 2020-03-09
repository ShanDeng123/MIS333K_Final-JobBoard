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
using sp19team23finalproject.Controllers;

namespace sp19team23finalproject.Controllers
{

    public class PositionsController : Controller
    {
        private readonly AppDbContext _context;

        public PositionsController(AppDbContext context)
        {
            _context = context;
        }
        /*
        // GET: Positions
        public async Task<IActionResult> Index()
        {
            //join position and company and major table so view can show company associated with position
            var dbPosition = _context.Positions.Include(cd => cd.Company).ThenInclude(cd => cd.Positions)
            .ThenInclude(cd => cd.PositionMajors).ThenInclude(cd => cd.Major);
            //var db_2Position = _context.Positions.Include(cd => cd.PositionMajors).ThenInclude(cd => cd.Major);
            //var dbPosition_Final = dbPosition.Include(cd => cd.db_2Position);

            return View(await dbPosition.ToListAsync());
        }
        */

        /*// GET: position Home search
        public ActionResult Index(String PositionSearchString)
        {
            var dbPositions = _context.Positions.Include(b => b.Company).ThenInclude(b => b.Positions)
            .ThenInclude(b => b.PositionMajors).ThenInclude(b => b.Major);

            var query = from b in dbPositions
                        select b;

            if (PositionSearchString != null)
            {
                query = query.Where(b => b.Title.Contains(PositionSearchString) || b.Description.Contains(PositionSearchString));
                List<Position> SelectedPositions = query.Include(b => b.PositionMajors).ToList();
                ViewBag.AllPositionCount = _context.Positions.Count();
                ViewBag.SelectedPositionCount = SelectedPositions.Count();
                return View(SelectedPositions.OrderByDescending(b => b.Title));
            }
            else
            {
                List<Position> SelectedPositions = query.Include(b => b.PositionMajors).ToList();
                ViewBag.AllPositionCount = _context.Positions.Count();
                ViewBag.SelectedPositionCount = SelectedPositions.Count();
                return View(SelectedPositions.OrderByDescending(b => b.Title));
            }
        }*/

        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Recruiter")) {
                var dbPositions = _context.Positions.Where(r => r.Company.AppUsers.Any(e => e.UserName == User.Identity.Name)).Include(b => b.Company).ThenInclude(b => b.Positions)
            .ThenInclude(b => b.PositionMajors).ThenInclude(b => b.Major);

                var query = from b in dbPositions
                            select b;

                List<Position> SelectedPositions = query.Include(b => b.PositionMajors).ToList();
                ViewBag.AllPositionCount = _context.Positions.Count();
                ViewBag.SelectedPositionCount = SelectedPositions.Count();

                return View(await dbPositions.OrderBy(b => b.Deadline).ThenBy(b=>b.Title).ThenBy(b=>b.Company).ThenBy(b=>b.PositionType).ToListAsync());

            }

            else
            {
                var dbPositions = _context.Positions.Where(b => b.Deadline > Controllers.HomeController.current_time)
            .Include(b => b.Company).ThenInclude(b => b.Positions)
            .ThenInclude(b => b.PositionMajors).ThenInclude(b => b.Major);

                var query = from b in dbPositions
                            select b;

                List<Position> SelectedPositions = query.Include(b => b.PositionMajors).ToList();
                ViewBag.AllPositionCount = _context.Positions.Where(b => b.Deadline > Controllers.HomeController.current_time).Count();
                ViewBag.SelectedPositionCount = SelectedPositions.Count();

                return View(await dbPositions.OrderBy(b => b.Deadline).ThenBy(b => b.Title).ThenBy(b => b.Company).ThenBy(b => b.PositionType).ToListAsync());

            }

        }



        //create detailed search action
        //create major viewbag
        public ActionResult DetailedSearch()
        {
            ViewBag.AllMajors = GetAllMajors();
            return View();
        }

        public SelectList GetAllMajors()
        {
            List<Major> majors = _context.Majors.ToList();
            
            var item = majors.First(x => x.MajorName == "All Majors");
            majors.Remove(item);

            Major SelectNone = new Major() { MajorID = 0, MajorName = "All Majors" };
            majors.Add(SelectNone);

            SelectList AllMajors = new SelectList(majors.OrderBy(m => m.MajorID), "MajorID", "MajorName");

            return AllMajors;
        }

        public ActionResult DisplaySearchResults(PositionDuration SelectedPositionType, 
            string CompanyName, string Industry, string LocationSearch, int SelectedMajor)
        {
            var dbPositions = _context.Positions.Include(b => b.Company).ThenInclude(b => b.Positions)
            .ThenInclude(b => b.PositionMajors).ThenInclude(b => b.Major);

            ViewBag.AllPositionCount = _context.Positions.Count();

            var query = from b in dbPositions
                        select b;

            if (LocationSearch != null && LocationSearch != "")
            { query = query.Where(b => b.Location.Contains(LocationSearch)); }

            if (CompanyName != null && CompanyName != "")
            { query = query.Where(b => b.Company.CompanyName.Contains(CompanyName)); }

            if (Industry != null && Industry != "")
            { query = query.Where(b => b.Company.Industry.Contains(Industry)); }


            if (SelectedMajor != 0)
            {
                //PositionMajor SearchedMajor = _context.PositionMajors.Find(SelectedMajor);
                query = query.Where(b => b.PositionMajors.Any(p => p.Major.MajorID == SelectedMajor));
            }

            switch (SelectedPositionType)
            {
                case PositionDuration.FT:
                    query = query.Where(b => b.PositionType == PositionDuration.FT);
                    break;
                case PositionDuration.I:
                    query = query.Where(b => b.PositionType == PositionDuration.I);
                    break;
            }
            if (User.IsInRole("Student"))
            {
                query = query.Where(b => b.Deadline > Controllers.HomeController.current_time);
                ViewBag.AllPositionCount = _context.Positions.Where(b => b.Deadline > Controllers.HomeController.current_time).Count();
            }

            List<Position> SelectedPositions = query.Include(b => b.PositionMajors).ToList();
            ViewBag.SelectedPositionCount = SelectedPositions.Count();

            return View("Index", SelectedPositions.OrderBy(b => b.Deadline).ThenBy(b => b.Title).ThenBy(b => b.Company).ThenBy(b => b.PositionType));
        }


        // GET: Positions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Position position = await _context.Positions
                .Include(c => c.Company).Include(c => c.PositionMajors).ThenInclude(c => c.Major)
                .FirstOrDefaultAsync(m => m.PositionID == id);

            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }

        //GET: Position/Apply
        public IActionResult Apply()
        {
            ViewBag.AllCompanies = GetAllCompanies();
            ViewBag.YourEnums = new SelectList(Enum.GetValues(typeof(PositionDuration)));
            return View();
        }

        // POST: Positions/Apply
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Apply([Bind("PositionID,Title,PositionType,Location,Deadline,Description,Company")] Position position,int SelectedCompany )
        {
            if (ModelState.IsValid)
            {
                _context.Add(position);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.YourCompanies = new SelectList(Enum.GetValues(typeof(PositionDuration)));
            ViewBag.AllCompanies = GetAllCompanies();
            return View(position);
        }



        [Authorize (Roles = "CSO,Recruiter")]
        // GET: Positions/Create
        public IActionResult Create()
        {
            ViewBag.AllMajors = GetMultiMajors();
            ViewBag.AllCompanies = GetAllCompanies();
            ViewBag.YourCompanies = new SelectList(Enum.GetValues(typeof(PositionDuration)));
            return View();
        }

        // POST: Positions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CSO,Recruiter")]
        public IActionResult Create([Bind("PositionID,Title,PositionType,Location,Deadline,Company,Description")] Position position, int SelectedCompany, int[] SelectedMajors)
        {
            //find company
            Company pos_company = _context.Companies.Find(SelectedCompany);
            position.Company = pos_company;


            if (ModelState.IsValid)
            {
                _context.Add(position);
                _context.SaveChanges();

                //add navigational data
                Position dbPosition = _context.Positions.FirstOrDefault(c => c.PositionID == position.PositionID);

                //loop through the selected movies

                if (SelectedMajors == null || SelectedMajors.Length == 0)
                {
                    PositionMajor cd = new PositionMajor();
                    cd.Position = dbPosition;
                    cd.Major = _context.Majors.Find(7);
                    _context.PositionMajors.Add(cd);
                    _context.SaveChanges();
                }
                else
                {
                    foreach (int d in SelectedMajors)
                    {
                        //find the movie specified by the int
                        Major maj = _context.Majors.Find(d);

                        //create a new instance of the bridge table class
                        PositionMajor cd = new PositionMajor();
                        cd.Position = dbPosition;
                        cd.Major = maj;

                        //add the new record to the database
                        _context.PositionMajors.Add(cd);
                        _context.SaveChanges();
                    }
                }
                return RedirectToAction(nameof(Index));

            }
            ViewBag.YourCompanies = new SelectList(Enum.GetValues(typeof(PositionDuration)));
            ViewBag.AllMajors = GetMultiMajors();
            ViewBag.AllCompanies = GetAllCompanies();
            return View(position);
        }

        // GET: Positions/Edit/5
        [Authorize(Roles = "CSO,Recruiter")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Position position = _context.Positions
                .Include(c => c.Company)
                .FirstOrDefault(ord => ord.PositionID == id);

            if (position == null)
            {
                return NotFound();
            }
            ViewBag.YourCompanies = new SelectList(Enum.GetValues(typeof(PositionDuration)));
            ViewBag.AllMajors = GetMultiMajors(position.PositionID);
            ViewBag.AllCompanies = GetAllCompanies();
            return View(position);
        }



        // POST: Positions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CSO,Recruiter")]
        public async Task<IActionResult> Edit(int id, [Bind("PositionID,Title,PositionType,Location,Deadline,Description")] Position position, int SelectedCompany, int[] SelectedMajors)
        {
            //find company
            //Company pos_company = _context.Companies.Find(SelectedCompany);
            //position.Company = pos_company;

            if (ModelState.IsValid)
            {
                Company pos_company= _context.Companies.Find(SelectedCompany);
                position.Company = pos_company;
                //add navigational data
                Position dbPosition = _context.Positions.Include(cd => cd.PositionMajors).ThenInclude(cd => cd.Major).FirstOrDefault(c => c.PositionID == position.PositionID);

                //list of majors to remove
                List<PositionMajor> MajorsToRemove = new List<PositionMajor>();

                //find majors that should no longer be there
                foreach (PositionMajor pm in dbPosition.PositionMajors)
                {
                    if (SelectedMajors.Contains(pm.Major.MajorID) == false)
                    {
                        MajorsToRemove.Add(pm);
                    }
                }

                //remove majors from above list
                foreach (PositionMajor pm in MajorsToRemove)
                {
                    _context.PositionMajors.Remove(pm);
                    _context.SaveChanges();
                }

                //add majors not already there
                foreach (int i in SelectedMajors)
                {
                    if (dbPosition.PositionMajors.Any(d => d.Major.MajorID == i) == false)
                    {
                        PositionMajor pm = new PositionMajor();
                        pm.Major = _context.Majors.Find(i);
                        pm.Position = dbPosition;

                        //add new instance to database
                        _context.PositionMajors.Add(pm);
                        _context.SaveChanges();
                    }
                }

                //update scalar properties
                dbPosition.Title = position.Title;
                dbPosition.PositionType = position.PositionType;
                dbPosition.Location = position.Location;
                dbPosition.Deadline = position.Deadline;
                dbPosition.Description = position.Description;
                dbPosition.Company = position.Company;
                //add new instance to database
                _context.Positions.Update(dbPosition);
                _context.SaveChanges();


                return RedirectToAction(nameof(Index));

            }

            ViewBag.YourCompanies = new SelectList(Enum.GetValues(typeof(PositionDuration)));
            ViewBag.AllMajors = GetMultiMajors(position.PositionID);
            ViewBag.AllCompanies = GetAllCompanies();
            return View(position);
        }
        //GET: PickStudents to be interviewed
        public async Task<IActionResult> PickStudents(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Position position = await _context.Positions.FindAsync(id);
            if (position == null)
            {
                return NotFound();
            }
            //Populate the ViewBag with the list of departments
            //Existing departments should be highlighted
            List<AppUser> AppStudents = _context.AppUsers.Where(s => s.Applications.Any(a => a.Position.PositionID == id)).ToList();
            ViewBag.Applied = AppStudents;
            ViewBag.AllStudents = GetAllStudents();
            return View(position);

        }


        //POST: PickStudent
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CSO,Recruiter")]
        public IActionResult PickStudents(int id, Position position, int[] SelectedStudents)

        {

            if (ModelState.IsValid)
            {
                foreach (int stud in SelectedStudents)
                {
                    AppUser accepted_student = _context.AppUsers.Find(stud);
                    if (accepted_student.Applications.Any(a => a.Position.PositionID == id))
                    {
                        Application app = (sp19team23finalproject.Models.Application)_context.Applications.Where(c => c.User.UserName == accepted_student.UserName).Where(c => c.Position.PositionID == id);
                        app.Accepted = true;
                        _context.SaveChanges();
                    }
                    Application new_app = new Application();
                    new_app.Position = _context.Positions.Find(id);
                    new_app.User = accepted_student;
                    new_app.Accepted = true;
                    _context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }

            }
            List<AppUser> AppStudents = _context.AppUsers.Where(s => s.Applications.Any(a => a.Position.PositionID == id)).ToList();
            ViewBag.Applied = AppStudents;
            ViewBag.AllStudents = GetAllStudents();
            return View(_context.Positions.Find(id));
        }




        private bool PositionExists(int id)
        {
            return _context.Positions.Any(e => e.PositionID == id);
        }


        //get all companies select list
        private SelectList GetAllCompanies()
        {
            //get a list of all courses from the database
            List<Company> AllCompanies = _context.Companies.ToList();

            //convert this to a select list
            //note that CourseID and CourseName are the names of fields in the Course model class
            SelectList companies = new SelectList(AllCompanies, "CompanyID", "CompanyName");

            //return the select list
            return companies;

        }

        //get all majors select list
        private MultiSelectList GetMultiMajors()
        {
            //get a list of all courses from the database
            List<Major> AllMajors = _context.Majors.ToList();


            //convert this to a select list
            //note that CourseID and CourseName are the names of fields in the Course model class
            MultiSelectList majors = new MultiSelectList(AllMajors, "MajorID", "MajorName");

            //return the select list
            return majors;

        }

        //get all majors select list overloaded for edits
        private MultiSelectList GetMultiMajors(int majorID)
        {
            //get a list of all courses from the database
            List<Major> AllMajors = _context.Majors.ToList();

            //get list of majors for this position
            List<PositionMajor> positionMajors = _context.PositionMajors.Where(cd => cd.Position.PositionID == majorID).ToList();

            //loop through list to convert to a list of integers
            List<Int32> selectedMajors = new List<Int32>();

            foreach (PositionMajor pm in positionMajors)
            {
                selectedMajors.Add(pm.Major.MajorID);
            }

            //convert this to a select list
            //note that CourseID and CourseName are the names of fields in the Course model class
            MultiSelectList majors = new MultiSelectList(AllMajors, "MajorID", "MajorName", selectedMajors);

            //return the select list
            return majors;

        }

        public MultiSelectList GetAllStudents()
        {

            List<AppUser> students = _context.AppUsers.Where(u => (u.Major != null) && (u.ActiveStatus)).ToList();

            MultiSelectList AllStudents = new MultiSelectList(students, "Id", "FirstName", "LastName");
            return AllStudents;

        }



        ////get all students that applied for a certain position
        //private IActionResult GetAppliedStudents(int posID)
        //{
        //    List<AppUser> AppStudents = _context.AppUsers.Where(s => s.Applications.Any(a => a.Position.PositionID == posID)).ToList();
        //}

        //// GET: Positions/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var position = await _context.Positions
        //        .FirstOrDefaultAsync(m => m.PositionID == id);
        //    if (position == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(position);
        //}


        //// POST: Positions/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var position = await _context.Positions.FindAsync(id);
        //    _context.Positions.Remove(position);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}


    }
}
