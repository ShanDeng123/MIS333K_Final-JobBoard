using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

//TODO: Change these using statements to match your project
using sp19team23finalproject.DAL;
using sp19team23finalproject.Models;

//TODO: Change this namespace to match your project
namespace sp19team23finalproject.Seeding
{
    //add identity data
    public static class SeedIdentity
    {
        public static async Task AddAdmin(IServiceProvider serviceProvider)
        {
            AppDbContext _db = serviceProvider.GetRequiredService<AppDbContext>();
            UserManager<AppUser> _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            RoleManager<IdentityRole> _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            //TODO: Add the needed roles
            //if role doesn't exist, add it
            if (await _roleManager.RoleExistsAsync("CSO") == false)
            {
                await _roleManager.CreateAsync(new IdentityRole("CSO"));
            }

            if (await _roleManager.RoleExistsAsync("Recruiter") == false)
            {
                await _roleManager.CreateAsync(new IdentityRole("Recruiter"));
            }

            if (await _roleManager.RoleExistsAsync("Student") == false)
            {
                await _roleManager.CreateAsync(new IdentityRole("Student"));
            }

            //check to see if the manager has been added
            AppUser b1 = _db.Users.FirstOrDefault(u => u.Email == "ra@aoo.com");

            if (b1 == null)
            {

                b1 = new AppUser();
                b1.UserName = "ra@aoo.com";
                b1.Email = "ra@aoo.com";
                b1.FirstName = "Allen";
                b1.LastName = "Rogers";
                b1.ActiveStatus = true;


                var result = await _userManager.CreateAsync(b1, "3wCynC");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user cannot be added - " + result.ToString());
                }
                _db.SaveChanges();
                b1 = _db.Users.FirstOrDefault(u => u.UserName == "ra@aoo.com");
            }

            if (await _userManager.IsInRoleAsync(b1, "CSO") == false)
            {
                await _userManager.AddToRoleAsync(b1, "CSO");
            }

            _db.SaveChanges();


            AppUser b2 = _db.Users.FirstOrDefault(u => u.Email == "rwood@voyager.net");

            if (b2 == null)
            {

                b2 = new AppUser();
                b2.UserName = "rwood@voyager.net";
                b2.Email = "rwood@voyager.net";
                b2.FirstName = "Reagan";
                b2.LastName = "Wood";
                b2.ActiveStatus = true;


                var result = await _userManager.CreateAsync(b2, "Pbon0r");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user cannot be added - " + result.ToString());
                }
                _db.SaveChanges();
                b2 = _db.Users.FirstOrDefault(u => u.UserName == "rwood@voyager.net");
            }

            if (await _userManager.IsInRoleAsync(b2, "CSO") == false)
            {
                await _userManager.AddToRoleAsync(b2, "CSO");
            }

            _db.SaveChanges();


            AppUser b3 = _db.Users.FirstOrDefault(u => u.Email == "westj@pioneer.net");

            if (b3 == null)
            {

                b3 = new AppUser();
                b3.UserName = "westj@pioneer.net";
                b3.Email = "westj@pioneer.net";
                b3.FirstName = "Jake";
                b3.LastName = "West";
                b3.ActiveStatus = true;


                var result = await _userManager.CreateAsync(b3, "jW5fPP");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user cannot be added - " + result.ToString());
                }
                _db.SaveChanges();
                b3 = _db.Users.FirstOrDefault(u => u.UserName == "westj@pioneer.net");
            }

            if (await _userManager.IsInRoleAsync(b3, "CSO") == false)
            {
                await _userManager.AddToRoleAsync(b3, "CSO");
            }

            _db.SaveChanges();


            AppUser b4 = _db.Users.FirstOrDefault(u => u.Email == "liz@ggmail.com");

            if (b4 == null)
            {

                b4 = new AppUser();
                b4.UserName = "liz@ggmail.com";
                b4.Email = "liz@ggmail.com";
                b4.FirstName = "Elizabeth";
                b4.LastName = "Markham";
                b4.ActiveStatus = true;


                var result = await _userManager.CreateAsync(b4, "0QyilL");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user cannot be added - " + result.ToString());
                }
                _db.SaveChanges();
                b4 = _db.Users.FirstOrDefault(u => u.UserName == "liz@ggmail.com");
            }

            if (await _userManager.IsInRoleAsync(b4, "CSO") == false)
            {
                await _userManager.AddToRoleAsync(b4, "CSO");
            }

            _db.SaveChanges();


            AppUser b5 = _db.Users.FirstOrDefault(u => u.Email == "chaley@thug.com");

            if (b5 == null)
            {

                b5 = new AppUser();
                b5.UserName = "chaley@thug.com";
                b5.Email = "chaley@thug.com";
                b5.FirstName = "Charles";
                b5.LastName = "Haley";
                b5.ActiveStatus = true;


                var result = await _userManager.CreateAsync(b5, "atLm6W");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user cannot be added - " + result.ToString());
                }
                _db.SaveChanges();
                b5 = _db.Users.FirstOrDefault(u => u.UserName == "chaley@thug.com");
            }

            if (await _userManager.IsInRoleAsync(b5, "CSO") == false)
            {
                await _userManager.AddToRoleAsync(b5, "CSO");
            }

            _db.SaveChanges();

        }

    }
}