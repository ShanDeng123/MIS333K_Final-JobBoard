using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using sp19team23finalproject.DAL;
using sp19team23finalproject.Models;

namespace sp19team23finalproject.Seeding
{
	public static class SeedRecruiters
	{
		public static async Task AddRecruiters(IServiceProvider serviceProvider)
		{
			AppDbContext _db = serviceProvider.GetRequiredService<AppDbContext>();
			UserManager<AppUser> _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
			RoleManager<IdentityRole> _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

			AppUser b1 = _db.Users.FirstOrDefault(u => u.Email == "michelle@example.com") ;

			if (b1 == null)
			{

				b1 = new AppUser();
				b1.UserName = "michelle@example.com";
				b1.Email = "michelle@example.com";
				b1.FirstName = "Michelle";
				b1.LastName = "Banks";
				b1.ActiveStatus = true;
				b1.Company = _db.Companies.FirstOrDefault(m => m.CompanyName == "Accenture");


				var result = await _userManager.CreateAsync(b1, "jVb0Z6");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b1 = _db.Users.FirstOrDefault(u => u.UserName == "michelle@example.com");
			}

			if (await _userManager.IsInRoleAsync(b1,"Recruiter") == false)
			{
				await _userManager.AddToRoleAsync(b1,"Recruiter");
			}

			_db.SaveChanges();


			AppUser b2 = _db.Users.FirstOrDefault(u => u.Email == "toddy@aool.com") ;

			if (b2 == null)
			{

				b2 = new AppUser();
				b2.UserName = "toddy@aool.com";
				b2.Email = "toddy@aool.com";
				b2.FirstName = "Todd";
				b2.LastName = "Jacobs";
				b2.ActiveStatus = true;
				b2.Company = _db.Companies.FirstOrDefault(m => m.CompanyName == "Accenture");


				var result = await _userManager.CreateAsync(b2, "1PnrBV");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b2 = _db.Users.FirstOrDefault(u => u.UserName == "toddy@aool.com");
			}

			if (await _userManager.IsInRoleAsync(b2,"Recruiter") == false)
			{
				await _userManager.AddToRoleAsync(b2,"Recruiter");
			}

			_db.SaveChanges();


			AppUser b3 = _db.Users.FirstOrDefault(u => u.Email == "elowe@netscrape.net") ;

			if (b3 == null)
			{

				b3 = new AppUser();
				b3.UserName = "elowe@netscrape.net";
				b3.Email = "elowe@netscrape.net";
				b3.FirstName = "Ernest";
				b3.LastName = "Lowe";
				b3.ActiveStatus = true;
				b3.Company = _db.Companies.FirstOrDefault(m => m.CompanyName == "Shell");


				var result = await _userManager.CreateAsync(b3, "v3n5AV");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b3 = _db.Users.FirstOrDefault(u => u.UserName == "elowe@netscrape.net");
			}

			if (await _userManager.IsInRoleAsync(b3,"Recruiter") == false)
			{
				await _userManager.AddToRoleAsync(b3,"Recruiter");
			}

			_db.SaveChanges();


			AppUser b4 = _db.Users.FirstOrDefault(u => u.Email == "mclarence@aool.com") ;

			if (b4 == null)
			{

				b4 = new AppUser();
				b4.UserName = "mclarence@aool.com";
				b4.Email = "mclarence@aool.com";
				b4.FirstName = "Clarence";
				b4.LastName = "Martin";
				b4.ActiveStatus = true;
				b4.Company = _db.Companies.FirstOrDefault(m => m.CompanyName == "Deloitte");


				var result = await _userManager.CreateAsync(b4, "zBLq3S");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b4 = _db.Users.FirstOrDefault(u => u.UserName == "mclarence@aool.com");
			}

			if (await _userManager.IsInRoleAsync(b4,"Recruiter") == false)
			{
				await _userManager.AddToRoleAsync(b4,"Recruiter");
			}

			_db.SaveChanges();


			AppUser b5 = _db.Users.FirstOrDefault(u => u.Email == "nelson.Kelly@aool.com") ;

			if (b5 == null)
			{

				b5 = new AppUser();
				b5.UserName = "nelson.Kelly@aool.com";
				b5.Email = "nelson.Kelly@aool.com";
				b5.FirstName = "Kelly";
				b5.LastName = "Nelson";
				b5.ActiveStatus = true;
				b5.Company = _db.Companies.FirstOrDefault(m => m.CompanyName == "Deloitte");


				var result = await _userManager.CreateAsync(b5, "FSb8rA");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b5 = _db.Users.FirstOrDefault(u => u.UserName == "nelson.Kelly@aool.com");
			}

			if (await _userManager.IsInRoleAsync(b5,"Recruiter") == false)
			{
				await _userManager.AddToRoleAsync(b5,"Recruiter");
			}

			_db.SaveChanges();


			AppUser b6 = _db.Users.FirstOrDefault(u => u.Email == "megrhodes@freezing.co.uk") ;

			if (b6 == null)
			{

				b6 = new AppUser();
				b6.UserName = "megrhodes@freezing.co.uk";
				b6.Email = "megrhodes@freezing.co.uk";
				b6.FirstName = "Megan";
				b6.LastName = "Rhodes";
				b6.ActiveStatus = true;
				b6.Company = _db.Companies.FirstOrDefault(m => m.CompanyName == "Deloitte");


				var result = await _userManager.CreateAsync(b6, "1xVfHp");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b6 = _db.Users.FirstOrDefault(u => u.UserName == "megrhodes@freezing.co.uk");
			}

			if (await _userManager.IsInRoleAsync(b6,"Recruiter") == false)
			{
				await _userManager.AddToRoleAsync(b6,"Recruiter");
			}

			_db.SaveChanges();


			AppUser b7 = _db.Users.FirstOrDefault(u => u.Email == "sheff44@ggmail.com") ;

			if (b7 == null)
			{

				b7 = new AppUser();
				b7.UserName = "sheff44@ggmail.com";
				b7.Email = "sheff44@ggmail.com";
				b7.FirstName = "Martin";
				b7.LastName = "Sheffield";
				b7.ActiveStatus = true;
				b7.Company = _db.Companies.FirstOrDefault(m => m.CompanyName == "Texas Instruments");


				var result = await _userManager.CreateAsync(b7, "4XKLsd");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b7 = _db.Users.FirstOrDefault(u => u.UserName == "sheff44@ggmail.com");
			}

			if (await _userManager.IsInRoleAsync(b7,"Recruiter") == false)
			{
				await _userManager.AddToRoleAsync(b7,"Recruiter");
			}

			_db.SaveChanges();


			AppUser b8 = _db.Users.FirstOrDefault(u => u.Email == "peterstump@hootmail.com") ;

			if (b8 == null)
			{

				b8 = new AppUser();
				b8.UserName = "peterstump@hootmail.com";
				b8.Email = "peterstump@hootmail.com";
				b8.FirstName = "Peter";
				b8.LastName = "Stump";
				b8.ActiveStatus = true;
				b8.Company = _db.Companies.FirstOrDefault(m => m.CompanyName == "Texas Instruments");


				var result = await _userManager.CreateAsync(b8, "1XdmSV");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b8 = _db.Users.FirstOrDefault(u => u.UserName == "peterstump@hootmail.com");
			}

			if (await _userManager.IsInRoleAsync(b8,"Recruiter") == false)
			{
				await _userManager.AddToRoleAsync(b8,"Recruiter");
			}

			_db.SaveChanges();


			AppUser b9 = _db.Users.FirstOrDefault(u => u.Email == "yhuik9.Taylor@aool.com") ;

			if (b9 == null)
			{

				b9 = new AppUser();
				b9.UserName = "yhuik9.Taylor@aool.com";
				b9.Email = "yhuik9.Taylor@aool.com";
				b9.FirstName = "Rachel";
				b9.LastName = "Taylor";
				b9.ActiveStatus = true;
				b9.Company = _db.Companies.FirstOrDefault(m => m.CompanyName == "Hilton Worldwide");


				var result = await _userManager.CreateAsync(b9, "9yhFS3");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b9 = _db.Users.FirstOrDefault(u => u.UserName == "yhuik9.Taylor@aool.com");
			}

			if (await _userManager.IsInRoleAsync(b9,"Recruiter") == false)
			{
				await _userManager.AddToRoleAsync(b9,"Recruiter");
			}

			_db.SaveChanges();


			AppUser b10 = _db.Users.FirstOrDefault(u => u.Email == "tuck33@ggmail.com") ;

			if (b10 == null)
			{

				b10 = new AppUser();
				b10.UserName = "tuck33@ggmail.com";
				b10.Email = "tuck33@ggmail.com";
				b10.FirstName = "Clent";
				b10.LastName = "Tucker";
				b10.ActiveStatus = true;
				b10.Company = _db.Companies.FirstOrDefault(m => m.CompanyName == "Aon");


				var result = await _userManager.CreateAsync(b10, "I6BgsS");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b10 = _db.Users.FirstOrDefault(u => u.UserName == "tuck33@ggmail.com");
			}

			if (await _userManager.IsInRoleAsync(b10,"Recruiter") == false)
			{
				await _userManager.AddToRoleAsync(b10,"Recruiter");
			}

			_db.SaveChanges();


			AppUser b11 = _db.Users.FirstOrDefault(u => u.Email == "taylordjay@aool.com") ;

			if (b11 == null)
			{

				b11 = new AppUser();
				b11.UserName = "taylordjay@aool.com";
				b11.Email = "taylordjay@aool.com";
				b11.FirstName = "Allison";
				b11.LastName = "Taylor";
				b11.ActiveStatus = true;
				b11.Company = _db.Companies.FirstOrDefault(m => m.CompanyName == "Aldlucent");


				var result = await _userManager.CreateAsync(b11, "Vjb1wI");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b11 = _db.Users.FirstOrDefault(u => u.UserName == "taylordjay@aool.com");
			}

			if (await _userManager.IsInRoleAsync(b11,"Recruiter") == false)
			{
				await _userManager.AddToRoleAsync(b11,"Recruiter");
			}

			_db.SaveChanges();


			AppUser b12 = _db.Users.FirstOrDefault(u => u.Email == "jojoe@ggmail.com") ;

			if (b12 == null)
			{

				b12 = new AppUser();
				b12.UserName = "jojoe@ggmail.com";
				b12.Email = "jojoe@ggmail.com";
				b12.FirstName = "Joe";
				b12.LastName = "Nguyen";
				b12.ActiveStatus = true;
				b12.Company = _db.Companies.FirstOrDefault(m => m.CompanyName == "Stream Realty Partners");


				var result = await _userManager.CreateAsync(b12, "xI8Brg");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b12 = _db.Users.FirstOrDefault(u => u.UserName == "jojoe@ggmail.com");
			}

			if (await _userManager.IsInRoleAsync(b12,"Recruiter") == false)
			{
				await _userManager.AddToRoleAsync(b12,"Recruiter");
			}

			_db.SaveChanges();


			AppUser b13 = _db.Users.FirstOrDefault(u => u.Email == "hicks43@ggmail.com") ;

			if (b13 == null)
			{

				b13 = new AppUser();
				b13.UserName = "hicks43@ggmail.com";
				b13.Email = "hicks43@ggmail.com";
				b13.FirstName = "Anthony";
				b13.LastName = "Hicks";
				b13.ActiveStatus = true;
				b13.Company = _db.Companies.FirstOrDefault(m => m.CompanyName == "Microsoft");


				var result = await _userManager.CreateAsync(b13, "s33WOz");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b13 = _db.Users.FirstOrDefault(u => u.UserName == "hicks43@ggmail.com");
			}

			if (await _userManager.IsInRoleAsync(b13,"Recruiter") == false)
			{
				await _userManager.AddToRoleAsync(b13,"Recruiter");
			}

			_db.SaveChanges();


			AppUser b14 = _db.Users.FirstOrDefault(u => u.Email == "orielly@foxnets.com") ;

			if (b14 == null)
			{

				b14 = new AppUser();
				b14.UserName = "orielly@foxnets.com";
				b14.Email = "orielly@foxnets.com";
				b14.FirstName = "Bill";
				b14.LastName = "O'Reilly";
				b14.ActiveStatus = true;
				b14.Company = _db.Companies.FirstOrDefault(m => m.CompanyName == "Microsoft");


				var result = await _userManager.CreateAsync(b14, "pS2OJh");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b14 = _db.Users.FirstOrDefault(u => u.UserName == "orielly@foxnets.com");
			}

			if (await _userManager.IsInRoleAsync(b14,"Recruiter") == false)
			{
				await _userManager.AddToRoleAsync(b14,"Recruiter");
			}

			_db.SaveChanges();


			AppUser b15 = _db.Users.FirstOrDefault(u => u.Email == "louielouie@aool.com") ;

			if (b15 == null)
			{

				b15 = new AppUser();
				b15.UserName = "louielouie@aool.com";
				b15.Email = "louielouie@aool.com";
				b15.FirstName = "Louis";
				b15.LastName = "Winthorpe";
				b15.ActiveStatus = true;
				b15.Company = _db.Companies.FirstOrDefault(m => m.CompanyName == "Microsoft");


				var result = await _userManager.CreateAsync(b15, "fq7yDw");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b15 = _db.Users.FirstOrDefault(u => u.UserName == "louielouie@aool.com");
			}

			if (await _userManager.IsInRoleAsync(b15,"Recruiter") == false)
			{
				await _userManager.AddToRoleAsync(b15,"Recruiter");
			}

			_db.SaveChanges();


			AppUser b16 = _db.Users.FirstOrDefault(u => u.Email == "smartinmartin.Martin@aool.com") ;

			if (b16 == null)
			{

				b16 = new AppUser();
				b16.UserName = "smartinmartin.Martin@aool.com";
				b16.Email = "smartinmartin.Martin@aool.com";
				b16.FirstName = "Gregory";
				b16.LastName = "Martinez";
				b16.ActiveStatus = true;
				b16.Company = _db.Companies.FirstOrDefault(m => m.CompanyName == "Capital One");


				var result = await _userManager.CreateAsync(b16, "1rKkMW");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b16 = _db.Users.FirstOrDefault(u => u.UserName == "smartinmartin.Martin@aool.com");
			}

			if (await _userManager.IsInRoleAsync(b16,"Recruiter") == false)
			{
				await _userManager.AddToRoleAsync(b16,"Recruiter");
			}

			_db.SaveChanges();


			AppUser b17 = _db.Users.FirstOrDefault(u => u.Email == "or@aool.com") ;

			if (b17 == null)
			{

				b17 = new AppUser();
				b17.UserName = "or@aool.com";
				b17.Email = "or@aool.com";
				b17.FirstName = "Anka";
				b17.LastName = "Radkovich";
				b17.ActiveStatus = true;
				b17.Company = _db.Companies.FirstOrDefault(m => m.CompanyName == "Capital One");


				var result = await _userManager.CreateAsync(b17, "8K0cAh");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b17 = _db.Users.FirstOrDefault(u => u.UserName == "or@aool.com");
			}

			if (await _userManager.IsInRoleAsync(b17,"Recruiter") == false)
			{
				await _userManager.AddToRoleAsync(b17,"Recruiter");
			}

			_db.SaveChanges();


			AppUser b18 = _db.Users.FirstOrDefault(u => u.Email == "tanner@ggmail.com") ;

			if (b18 == null)
			{

				b18 = new AppUser();
				b18.UserName = "tanner@ggmail.com";
				b18.Email = "tanner@ggmail.com";
				b18.FirstName = "Jeremy";
				b18.LastName = "Tanner";
				b18.ActiveStatus = true;
				b18.Company = _db.Companies.FirstOrDefault(m => m.CompanyName == "United Airlines");


				var result = await _userManager.CreateAsync(b18, "w9wPff");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b18 = _db.Users.FirstOrDefault(u => u.UserName == "tanner@ggmail.com");
			}

			if (await _userManager.IsInRoleAsync(b18,"Recruiter") == false)
			{
				await _userManager.AddToRoleAsync(b18,"Recruiter");
			}

			_db.SaveChanges();


			AppUser b19 = _db.Users.FirstOrDefault(u => u.Email == "tee_frank@hootmail.com") ;

			if (b19 == null)
			{

				b19 = new AppUser();
				b19.UserName = "tee_frank@hootmail.com";
				b19.Email = "tee_frank@hootmail.com";
				b19.FirstName = "Frank";
				b19.LastName = "Tee";
				b19.ActiveStatus = true;
				b19.Company = _db.Companies.FirstOrDefault(m => m.CompanyName == "Academy Sports & Outdoors");


				var result = await _userManager.CreateAsync(b19, "1EIwbx");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b19 = _db.Users.FirstOrDefault(u => u.UserName == "tee_frank@hootmail.com");
			}

			if (await _userManager.IsInRoleAsync(b19,"Recruiter") == false)
			{
				await _userManager.AddToRoleAsync(b19,"Recruiter");
			}

			_db.SaveChanges();


			AppUser b20 = _db.Users.FirstOrDefault(u => u.Email == "target_spot@example.com") ;

			if (b20 == null)
			{

				b20 = new AppUser();
				b20.UserName = "target_spot@example.com";
				b20.Email = "target_spot@example.com";
				b20.FirstName = "Spot";
				b20.LastName = "Dog";
				b20.ActiveStatus = true;
				b20.Company = _db.Companies.FirstOrDefault(m => m.CompanyName == "Target");


				var result = await _userManager.CreateAsync(b20, "spotthedog");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b20 = _db.Users.FirstOrDefault(u => u.UserName == "target_spot@example.com");
			}

			if (await _userManager.IsInRoleAsync(b20,"Recruiter") == false)
			{
				await _userManager.AddToRoleAsync(b20,"Recruiter");
			}

			_db.SaveChanges();


		}
	}
}
