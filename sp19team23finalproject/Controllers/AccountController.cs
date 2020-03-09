using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sp19team23finalproject.DAL;
using sp19team23finalproject.Models;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using sp19team23finalproject.Controllers;

namespace sp19team23finalproject.Controllers
{
    ////create new authorization to only allow anonymous; used for registration
    //public class AllowAnonymousOnlyAttribute : ActionFilterAttribute
    //{
    //    private AppDbContext _db;
    //    HttpContext _httpcontext = new HttpContext(your parameters)
    //    public override void OnActionExecuting(ActionExecutingContext filterContext)
    //    {
    //        bool user_in = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
    //        if (_db.Users.User != null)

    //        {
    //            if (User.IsInRole("Recruiter") || User.IsInRole("Student") || User.IsInRole("Doctor"))
    //            {
    //                RedirecttoAction("/Home/Index");

    //            }
    //        }
    //        base.OnActionExecuting(filterContext);
    //    }
    //}

    public class AccountController : Controller
    {
        private SignInManager<AppUser> _signInManager;
        private UserManager<AppUser> _userManager;
        private PasswordValidator<AppUser> _passwordValidator;
        private AppDbContext _db;

        public AccountController(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signIn)
        {
            _db = context;
            _userManager = userManager;
            _signInManager = signIn;
            //user manager only has one password validator
            _passwordValidator = (PasswordValidator<AppUser>)userManager.PasswordValidators.FirstOrDefault();
        }



        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated) //user has been redirected here from a page they're not authorized to see
            {
                return View("Error", new string[] { "Access Denied" });
            }
            _signInManager.SignOutAsync(); //this removes any old cookies hanging around
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            //checks if user has an active status
            if (result.Succeeded)
            {
                return Redirect(returnUrl ?? "/");
               

            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
        }


        //
        // GET: /Account/Register
        //[AllowAnonymousOnly]
        public ActionResult Register()
        {
            ViewBag.YourEnums = new SelectList(Enum.GetValues(typeof(PositionDuration)));
            ViewBag.AllMajors = GetAllMajors();
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model, int SelectedMajor, int SelectedPositionType)
        {

            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {

                    //TODO: Add the rest of the user fields here
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Birthday = model.Birthday,
                    ActiveStatus = true,
                    PositionType = model.PositionType,
                    GradDate = model.GradDate,
                    GPA = model.GPA,
                    Major = _db.Majors.Find(SelectedMajor),


                };
                //DONT USE THIS CODE!!
                //if (SelectedPositionType == 0)
                //{
                //    PositionDuration position_type = PositionDuration.FT;
                //    user.PositionType = position_type;
                //}
                //else
                //{
                //    PositionDuration position_type = PositionDuration.I;
                //    user.PositionType = position_type;
                //}

                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //TODO: Add user to desired role. This example adds the user to the customer role
                    await _userManager.AddToRoleAsync(user, "Student");

                    Microsoft.AspNetCore.Identity.SignInResult result2 = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            ViewBag.YourEnums = new SelectList(Enum.GetValues(typeof(PositionDuration)));
            ViewBag.AllMajors = GetAllMajors();
            return View(model);
        }


        //Create code begins
        //Create student, recruiter, and cso

        //GET: Account/CreateStudent - only CSO
        [Authorize(Roles = "CSO")]
        public ActionResult CreateStudent()
        {
            ViewBag.YourEnums = new SelectList(Enum.GetValues(typeof(PositionDuration)));
            ViewBag.AllMajors = GetAllMajors();
            return View();
        }

        // POST: /Account/CreateStudent - Register View Model
        [HttpPost]
        [Authorize(Roles = "CSO")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateStudent(RegisterViewModel model, int SelectedMajor, int SelectedPositionType)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    //TODO: Add the rest of the user fields here
                    UserName = model.Email,
                    Email = model.Email,
                    ActiveStatus = true,
                    FirstName = model.FirstName,
                    PositionType = model.PositionType,
                    LastName = model.LastName,
                    Birthday = model.Birthday,
                    Major = _db.Majors.Find(SelectedMajor),

                    GradDate = model.GradDate,
                    GPA = model.GPA,


                };
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //TODO: Add user to desired role. This example adds the user to the customer role
                    await _userManager.AddToRoleAsync(user, "Student");

                    //Microsoft.AspNetCore.Identity.SignInResult result2 = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            ViewBag.YourEnums = new SelectList(Enum.GetValues(typeof(PositionDuration)));
            ViewBag.AllMajors = GetAllMajors();
            return View(model);
        }




        //GET: Account/CreateRecruiter - only CSO
        [Authorize(Roles = "CSO")]
        public ActionResult CreateRecruiter()
        {
            ViewBag.AllCompanies = GetAllCompanies();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "CSO")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateRecruiter(RecRegisterViewModel model, int SelectedCompany)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    //TODO: Add the rest of the user fields here
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Company = _db.Companies.Find(SelectedCompany),


                };
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //TODO: Add user to desired role. This example adds the user to the customer role
                    await _userManager.AddToRoleAsync(user, "Recruiter");

                    //Microsoft.AspNetCore.Identity.SignInResult result2 = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            ViewBag.AllCompanies = GetAllCompanies();
            return View(model);
        }



        //GET: Account/CreateCSO - only CSO
        [Authorize(Roles = "CSO")]
        public ActionResult CreateCSO()
        {

            return View();
        }

        // POST: /Account/CreateRecruiter
        [HttpPost]
        [Authorize(Roles = "CSO")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateCSO(CSORegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    //TODO: Add the rest of the user fields here
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,


                };
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //TODO: Add user to desired role. This example adds the user to the customer role
                    await _userManager.AddToRoleAsync(user, "CSO");

                    Microsoft.AspNetCore.Identity.SignInResult result2 = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        //end of create code


        //GET: Account/Index
        public ActionResult Index()
        {
            IndexViewModel ivm = new IndexViewModel();

            //get user info
            String id = User.Identity.Name;
            AppUser user = _db.Users.FirstOrDefault(u => u.UserName == id);

            //populate the view model
            ivm.Email = user.Email;
            ivm.HasPassword = true;
            ivm.UserID = user.Id;
            ivm.UserName = user.UserName;


            return View(ivm);
        }



        //Logic for change password
        // GET: /Account/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            AppUser userLoggedIn = await _userManager.FindByNameAsync(User.Identity.Name);
            var result = await _userManager.ChangePasswordAsync(userLoggedIn, model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(userLoggedIn, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
            AddErrors(result);
            return View(model);
        }

        //GET:/Account/AccessDenied
        public ActionResult AccessDenied(String ReturnURL)
        {
            return View("Error", new string[] { "Access is denied" });
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }



        //Edit code below
        //Edit Student,Recruiter,and CSO code

        // GET: /Account/EditStudent
        //[Authorize]
        public async Task<IActionResult> EditStudent(string id)
        {
            if (id == "")
            {
                return NotFound();
            }

            AppUser student = await _db.Users.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            ViewBag.AllMajors = GetAllMajors();
            return View(student);

        }


        //edit
        //POST: /Account/EditStudent
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditStudent(string id, [Bind("FirstName, LastName, Email, GPA, GradDate, ActiveStatus")] AppUser user, int SelectedMajor, PositionDuration SelectedType)
        {
            if (ModelState.IsValid)
            {
                //if edit own file
                //string username = User.Identity.Name;


                AppUser edit_user = _db.Users.Find(id);

                Major major = _db.Majors.Find(SelectedMajor);
                user.Major = major;

                if (SelectedType == PositionDuration.FT)
                {
                    edit_user.PositionType = PositionDuration.FT;
                    _db.SaveChanges();
                }
                if (SelectedType == PositionDuration.I)
                {
                    edit_user.PositionType = PositionDuration.I;
                    _db.SaveChanges();
                }

                edit_user.FirstName = user.FirstName;
                edit_user.LastName = user.LastName;
                edit_user.Email = user.Email;
                edit_user.GPA = user.GPA;
                edit_user.GradDate = user.GradDate;
                //edit_user.PositionType = SelectedType;
                edit_user.ActiveStatus = user.ActiveStatus;
                edit_user.Major = user.Major;

                _db.Entry(edit_user).State = EntityState.Modified;

                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(user);

        }


            


        // GET: /Account/EditRecruiter
        [Authorize]
        public async Task<IActionResult> EditRecruiter(string id)
        {
            if (id == "")
            {
                return NotFound();
            }

            AppUser rec = await _db.Users.FindAsync(id);
            if (rec == null)
            {
                return NotFound();
            }

            ViewBag.AllCompanies = GetAllCompanies();
            return View(rec);

        }

        //POST: /Account/EditRecruiter
        [Authorize(Roles = "Recruiter,CSO")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRecruiter(string id, [Bind("Id,FirstName,LastName,Email,ActiveStatus,Company")] AppUser appUser, int SelectedCompany)
        {
            if (ModelState.IsValid)
            {
                //if edit own file
                //string username = User.Identity.Name;


                AppUser edit_rec = await _db.Users.FindAsync(id);

                Company company = _db.Companies.Find(SelectedCompany);
                appUser.Company = company;

                edit_rec.FirstName = appUser.FirstName;
                edit_rec.LastName = appUser.LastName;
                edit_rec.Email = appUser.Email;
                edit_rec.UserName = appUser.Email;
                edit_rec.ActiveStatus = appUser.ActiveStatus;

                edit_rec.Company = appUser.Company;

                _db.Entry(edit_rec).State = EntityState.Modified;

                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(appUser);
        }


        // GET: /Account/EditCSO
        [Authorize]
        public async Task<IActionResult> EditCSO (string id)
        {
            if (id == "")
            {
                return NotFound();
            }

            AppUser cso = await _db.Users.FindAsync(id);
            if (cso == null)
            {
                return NotFound();
            }
                
            return View(cso);

        }


        //POST: /Account/EditCSO
        [Authorize(Roles = "CSO")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCSO(string id, [Bind("Id,FirstName,LastName,ActiveStatus,Email")] AppUser appUser)
        {
            if (id != appUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                AppUser edit_cso = await _db.Users.FindAsync(id);


                edit_cso.FirstName = appUser.FirstName;
                edit_cso.LastName = appUser.LastName;
                edit_cso.ActiveStatus = appUser.ActiveStatus;
                edit_cso.Email = appUser.Email;
                edit_cso.UserName = appUser.Email;


                _db.Entry(edit_cso).State = EntityState.Modified;

                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(appUser);
        }

        //Edit code ends


        // see if that position exists
        private bool PositionExists(int id)
        {
            return _db.Positions.Any(e => e.PositionID == id);
        }

        //see if that appuser exists
        private bool appUserExists(string id)
        {
            return _db.AppUsers.Any(e => e.Id == id);
        }

        //get all majors select list
        private SelectList GetAllMajors()
        {
            //get a list of all courses from the database
            List<Major> AllMajors = _db.Majors.ToList();

            //convert this to a select list
            //note that CourseID and CourseName are the names of fields in the Course model class
            SelectList majors = new SelectList(AllMajors, "MajorID", "MajorName");

            //return the select list
            return majors;

        }

        //get all companies select list
        private SelectList GetAllCompanies()
        {
            //get a list of all courses from the database
            List<Company> AllCompanies = _db.Companies.ToList();

            //convert this to a select list
            //note that CourseID and CourseName are the names of fields in the Course model class
            SelectList companies = new SelectList(AllCompanies, "CompanyID", "CompanyName");

            //return the select list
            return companies;

        }


    }
    }



