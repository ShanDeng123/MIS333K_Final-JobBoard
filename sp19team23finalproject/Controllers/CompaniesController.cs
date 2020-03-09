using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sp19team23finalproject.DAL;
using sp19team23finalproject.Models;
using sp19team23finalproject.Controllers;

namespace sp19team23finalproject.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly AppDbContext _context;


        public CompaniesController(AppDbContext context)
        {
            _context = context;
        }


        public ActionResult CompanyDetailedSearch()
        {

            return View();
        }


        public ActionResult DisplaySearchResults(string CompanyNameSearch, string LocationSearch, PositionDuration SelectedPositionType, string Industry)
        {
            //var dbCompanies = _context.Companies.Include(b => b.Positions).ThenInclude(b => b.PositionType).Include(b => b.Positions).ThenInclude(b => b.Location).Include(b => b.Industry);
            var dbCompanies = _context.Companies.Include(b => b.Positions);

            var query = from b in dbCompanies
                        select b;

            if (CompanyNameSearch != null && CompanyNameSearch != "")
            { query = query.Where(b => b.CompanyName.Contains(CompanyNameSearch)); }



            if (LocationSearch != null && LocationSearch != "")
            {
                query = query.Where(c => c.Positions.Any(p => p.Location.Contains(LocationSearch)));
            }

           
            if (Industry != null && Industry != "")
            { query = query.Where(b => b.Industry.Contains(Industry)); }



            //saw this on piazza, might work
            if (SelectedPositionType == PositionDuration.I)
            {
                query = query.Where(b => b.Positions.All(p => p.PositionType.Equals(SelectedPositionType))); 
            }
            if (SelectedPositionType == PositionDuration.FT)
            {
                query = query.Where(b => b.Positions.All(p => p.PositionType.Equals(SelectedPositionType)));
            }
            //switch (SelectedPositionType)
            //{
            //    case PositionDuration.FT:
            //        query = query.Where(b => b.Positions.PositionType == PositionDuration.FT);
            //        break;
            //    case PositionDuration.I:
            //        query = query.Where(b => b.Positions.PositionType == PositionDuration.I);
            //        break;
            //}

            List<Company> SelectedCompanies = query.ToList();
            //ViewBag.AllPositionCount = _context.Positions.Count();
            //ViewBag.SelectedPositionCount = SelectedPositions.Count();
            return View("Index", SelectedCompanies);
        }
        
        /*// GET: Companies
        public async Task<IActionResult> Index()
        {
            var dbCompanies = _context.Companies.Include(b => b.Positions);

            var query = from b in dbCompanies
                        select b;

            ViewBag.AllCompanyCount = _context.Companies.Count();

            return View(await dbCompanies.ToListAsync());

        }*/

        // GET: company Home search
       public ActionResult Index(String CompanySearch)
       {
            var dbCompanies = _context.Companies.Include(b => b.Positions);
            var query = from b in dbCompanies
                       select b;

           if (CompanySearch != null)
           {
               query = query.Where(b => b.CompanyName.Contains(CompanySearch) || b.CompanyDescription.Contains(CompanySearch));
               List<Company> SelectedCompanies = query.Include(b => b.Positions).ToList();
               ViewBag.AllCompanyCount = _context.Companies.Count();
               ViewBag.SelectedCompanyCount = SelectedCompanies.Count();
               return View(SelectedCompanies);
           }
           else
           {
               List<Company> SelectedCompanies = query.Include(b => b.Positions).ToList();
               ViewBag.AllCompanyCount = _context.Companies.Count();
               ViewBag.SelectedCompanyCount = SelectedCompanies.Count();
               return View(SelectedCompanies);
           }
       }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Company company = await _context.Companies
                .Include(c => c.Positions).ThenInclude(c => c.Interviews)
                .FirstOrDefaultAsync(m => m.CompanyID == id);


            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyID,CompanyName,Email,CompanyDescription,Industry")] Company company)
        {
            if (ModelState.IsValid)
            {
                _context.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyID,CompanyName,Email,CompanyDescription,Industry")] Company company)
        {
            if (id != company.CompanyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.CompanyID))
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
            return View(company);
        }

        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.CompanyID == id);
        }
    }
}
