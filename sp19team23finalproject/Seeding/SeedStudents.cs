using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using sp19team23finalproject.DAL;
using sp19team23finalproject.Models;
using sp19team23finalproject.Controllers;

namespace sp19team23finalproject.Seeding
{
	public static class SeedStudents
	{
		public static async Task AddStudents(IServiceProvider serviceProvider)
		{
			AppDbContext _db = serviceProvider.GetRequiredService<AppDbContext>();
			UserManager<AppUser> _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
			RoleManager<IdentityRole> _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

			AppUser b1 = _db.Users.FirstOrDefault(u => u.Email == "Austin") ;

			if (b1 == null)
			{

				b1 = new AppUser();
				b1.UserName = "cbaker@example.com";
				b1.Email = "cbaker@example.com";
				b1.FirstName = "Christopher";
				b1.LastName = "Baker";
				b1.ActiveStatus = true;
				b1.Birthday = new DateTime (1997,8,2);
				b1.GradDate = 2019;
				b1.GPA = 3.91m;
				b1.PositionType = PositionDuration.FT;
				b1.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "MIS");


				var result = await _userManager.CreateAsync(b1, "bookworm");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b1 = _db.Users.FirstOrDefault(u => u.UserName == "cbaker@example.com");
			}

			if (await _userManager.IsInRoleAsync(b1,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b1,"Student");
			}

			_db.SaveChanges();


			AppUser b2 = _db.Users.FirstOrDefault(u => u.Email == "Austin") ;

			if (b2 == null)
			{

				b2 = new AppUser();
				b2.UserName = "banker@longhorn.net";
				b2.Email = "banker@longhorn.net";
				b2.FirstName = "Michelle";
				b2.LastName = "Banks";
				b2.ActiveStatus = true;
				b2.Birthday = new DateTime (1996,11,18);
				b2.GradDate = 2020;
				b2.GPA = 3.52m;
				b2.PositionType = PositionDuration.I;
				b2.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "International Business");


				var result = await _userManager.CreateAsync(b2, "aclfest2017");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b2 = _db.Users.FirstOrDefault(u => u.UserName == "banker@longhorn.net");
			}

			if (await _userManager.IsInRoleAsync(b2,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b2,"Student");
			}

			_db.SaveChanges();


			AppUser b3 = _db.Users.FirstOrDefault(u => u.Email == "Austin") ;

			if (b3 == null)
			{

				b3 = new AppUser();
				b3.UserName = "franco@example.com";
				b3.Email = "franco@example.com";
				b3.FirstName = "Franco";
				b3.LastName = "Broccolo";
				b3.ActiveStatus = true;
				b3.Birthday = new DateTime (1998,5,2);
				b3.GradDate = 2019;
				b3.GPA = 3.2m;
				b3.PositionType = PositionDuration.FT;
				b3.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "MIS");


				var result = await _userManager.CreateAsync(b3, "aggies");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b3 = _db.Users.FirstOrDefault(u => u.UserName == "franco@example.com");
			}

			if (await _userManager.IsInRoleAsync(b3,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b3,"Student");
			}

			_db.SaveChanges();


			AppUser b4 = _db.Users.FirstOrDefault(u => u.Email == "Eagle Pass") ;

			if (b4 == null)
			{

				b4 = new AppUser();
				b4.UserName = "wchang@example.com";
				b4.Email = "wchang@example.com";
				b4.FirstName = "Wendy";
				b4.LastName = "Chang";
				b4.ActiveStatus = true;
				b4.Birthday = new DateTime (1997,8,20);
				b4.GradDate = 2021;
				b4.GPA = 3.56m;
				b4.PositionType = PositionDuration.I;
				b4.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Finance");


				var result = await _userManager.CreateAsync(b4, "alaskaboy");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b4 = _db.Users.FirstOrDefault(u => u.UserName == "wchang@example.com");
			}

			if (await _userManager.IsInRoleAsync(b4,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b4,"Student");
			}

			_db.SaveChanges();


			AppUser b5 = _db.Users.FirstOrDefault(u => u.Email == "Austin") ;

			if (b5 == null)
			{

				b5 = new AppUser();
				b5.UserName = "limchou@gogle.com";
				b5.Email = "limchou@gogle.com";
				b5.FirstName = "Lim";
				b5.LastName = "Chou";
				b5.ActiveStatus = true;
				b5.Birthday = new DateTime (1999,4,6);
				b5.GradDate = 2020;
				b5.GPA = 2.63m;
				b5.PositionType = PositionDuration.I;
				b5.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Finance");


				var result = await _userManager.CreateAsync(b5, "allyrally");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b5 = _db.Users.FirstOrDefault(u => u.UserName == "limchou@gogle.com");
			}

			if (await _userManager.IsInRoleAsync(b5,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b5,"Student");
			}

			_db.SaveChanges();


			AppUser b6 = _db.Users.FirstOrDefault(u => u.Email == "Georgetown") ;

			if (b6 == null)
			{

				b6 = new AppUser();
				b6.UserName = "shdixon@aoll.com";
				b6.Email = "shdixon@aoll.com";
				b6.FirstName = "Shan";
				b6.LastName = "Dixon";
				b6.ActiveStatus = true;
				b6.Birthday = new DateTime (1998,10,21);
				b6.GradDate = 2022;
				b6.GPA = 3.62m;
				b6.PositionType = PositionDuration.I;
				b6.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "International Business");


				var result = await _userManager.CreateAsync(b6, "Anchorage");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b6 = _db.Users.FirstOrDefault(u => u.UserName == "shdixon@aoll.com");
			}

			if (await _userManager.IsInRoleAsync(b6,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b6,"Student");
			}

			_db.SaveChanges();


			AppUser b7 = _db.Users.FirstOrDefault(u => u.Email == "Austin") ;

			if (b7 == null)
			{

				b7 = new AppUser();
				b7.UserName = "j.b.evans@aheca.org";
				b7.Email = "j.b.evans@aheca.org";
				b7.FirstName = "Jim Bob";
				b7.LastName = "Evans";
				b7.ActiveStatus = true;
				b7.Birthday = new DateTime (1997,10,8);
				b7.GradDate = 2019;
				b7.GPA = 2.64m;
				b7.PositionType = PositionDuration.FT;
				b7.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Accounting");


				var result = await _userManager.CreateAsync(b7, "billyboy");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b7 = _db.Users.FirstOrDefault(u => u.UserName == "j.b.evans@aheca.org");
			}

			if (await _userManager.IsInRoleAsync(b7,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b7,"Student");
			}

			_db.SaveChanges();


			AppUser b8 = _db.Users.FirstOrDefault(u => u.Email == "Austin") ;

			if (b8 == null)
			{

				b8 = new AppUser();
				b8.UserName = "feeley@penguin.org";
				b8.Email = "feeley@penguin.org";
				b8.FirstName = "Lou Ann";
				b8.LastName = "Feeley";
				b8.ActiveStatus = true;
				b8.Birthday = new DateTime (1999,6,19);
				b8.GradDate = 2020;
				b8.GPA = 3.66m;
				b8.PositionType = PositionDuration.I;
				b8.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Marketing");


				var result = await _userManager.CreateAsync(b8, "bunnyhop");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b8 = _db.Users.FirstOrDefault(u => u.UserName == "feeley@penguin.org");
			}

			if (await _userManager.IsInRoleAsync(b8,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b8,"Student");
			}

			_db.SaveChanges();


			AppUser b9 = _db.Users.FirstOrDefault(u => u.Email == "College Station") ;

			if (b9 == null)
			{

				b9 = new AppUser();
				b9.UserName = "tfreeley@minnetonka.ci.us";
				b9.Email = "tfreeley@minnetonka.ci.us";
				b9.FirstName = "Tesa";
				b9.LastName = "Freeley";
				b9.ActiveStatus = true;
				b9.Birthday = new DateTime (1992,9,12);
				b9.GradDate = 2019;
				b9.GPA = 3.98m;
				b9.PositionType = PositionDuration.FT;
				b9.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Accounting");


				var result = await _userManager.CreateAsync(b9, "dustydusty");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b9 = _db.Users.FirstOrDefault(u => u.UserName == "tfreeley@minnetonka.ci.us");
			}

			if (await _userManager.IsInRoleAsync(b9,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b9,"Student");
			}

			_db.SaveChanges();


			AppUser b10 = _db.Users.FirstOrDefault(u => u.Email == "Austin") ;

			if (b10 == null)
			{

				b10 = new AppUser();
				b10.UserName = "mgarcia@gogle.com";
				b10.Email = "mgarcia@gogle.com";
				b10.FirstName = "Margaret";
				b10.LastName = "Garcia";
				b10.ActiveStatus = true;
				b10.Birthday = new DateTime (1998,6,17);
				b10.GradDate = 2019;
				b10.GPA = 3.22m;
				b10.PositionType = PositionDuration.FT;
				b10.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "MIS");


				var result = await _userManager.CreateAsync(b10, "gowest");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b10 = _db.Users.FirstOrDefault(u => u.UserName == "mgarcia@gogle.com");
			}

			if (await _userManager.IsInRoleAsync(b10,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b10,"Student");
			}

			_db.SaveChanges();


			AppUser b11 = _db.Users.FirstOrDefault(u => u.Email == "Austin") ;

			if (b11 == null)
			{

				b11 = new AppUser();
				b11.UserName = "jeffh@sonic.com";
				b11.Email = "jeffh@sonic.com";
				b11.FirstName = "Jeffrey";
				b11.LastName = "Hampton";
				b11.ActiveStatus = true;
				b11.Birthday = new DateTime (1999,4,8);
				b11.GradDate = 2020;
				b11.GPA = 3.66m;
				b11.PositionType = PositionDuration.I;
				b11.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Science and Technology Management");


				var result = await _userManager.CreateAsync(b11, "hickhickup");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b11 = _db.Users.FirstOrDefault(u => u.UserName == "jeffh@sonic.com");
			}

			if (await _userManager.IsInRoleAsync(b11,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b11,"Student");
			}

			_db.SaveChanges();


			AppUser b12 = _db.Users.FirstOrDefault(u => u.Email == "Liberty") ;

			if (b12 == null)
			{

				b12 = new AppUser();
				b12.UserName = "wjhearniii@umich.org";
				b12.Email = "wjhearniii@umich.org";
				b12.FirstName = "John";
				b12.LastName = "Hearn";
				b12.ActiveStatus = true;
				b12.Birthday = new DateTime (1996,9,15);
				b12.GradDate = 2019;
				b12.GPA = 3.46m;
				b12.PositionType = PositionDuration.FT;
				b12.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Business Honors");


				var result = await _userManager.CreateAsync(b12, "ingram2015");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b12 = _db.Users.FirstOrDefault(u => u.UserName == "wjhearniii@umich.org");
			}

			if (await _userManager.IsInRoleAsync(b12,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b12,"Student");
			}

			_db.SaveChanges();


			AppUser b13 = _db.Users.FirstOrDefault(u => u.Email == "San Antonio") ;

			if (b13 == null)
			{

				b13 = new AppUser();
				b13.UserName = "ahick@yaho.com";
				b13.Email = "ahick@yaho.com";
				b13.FirstName = "Anthony";
				b13.LastName = "Hicks";
				b13.ActiveStatus = true;
				b13.Birthday = new DateTime (1999,5,7);
				b13.GradDate = 2020;
				b13.GPA = 3.12m;
				b13.PositionType = PositionDuration.I;
				b13.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Supply Chain Management");


				var result = await _userManager.CreateAsync(b13, "jhearn22");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b13 = _db.Users.FirstOrDefault(u => u.UserName == "ahick@yaho.com");
			}

			if (await _userManager.IsInRoleAsync(b13,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b13,"Student");
			}

			_db.SaveChanges();


			AppUser b14 = _db.Users.FirstOrDefault(u => u.Email == "New Braunfels") ;

			if (b14 == null)
			{

				b14 = new AppUser();
				b14.UserName = "ingram@jack.com";
				b14.Email = "ingram@jack.com";
				b14.FirstName = "Brad";
				b14.LastName = "Ingram";
				b14.ActiveStatus = true;
				b14.Birthday = new DateTime (1997,2,6);
				b14.GradDate = 2020;
				b14.GPA = 3.72m;
				b14.PositionType = PositionDuration.I;
				b14.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Supply Chain Management");


				var result = await _userManager.CreateAsync(b14, "joejoejoe");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b14 = _db.Users.FirstOrDefault(u => u.UserName == "ingram@jack.com");
			}

			if (await _userManager.IsInRoleAsync(b14,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b14,"Student");
			}

			_db.SaveChanges();


			AppUser b15 = _db.Users.FirstOrDefault(u => u.Email == "New York") ;

			if (b15 == null)
			{

				b15 = new AppUser();
				b15.UserName = "toddj@yourmom.com";
				b15.Email = "toddj@yourmom.com";
				b15.FirstName = "Todd";
				b15.LastName = "Jacobs";
				b15.ActiveStatus = true;
				b15.Birthday = new DateTime (1997,8,29);
				b15.GradDate = 2019;
				b15.GPA = 2.64m;
				b15.PositionType = PositionDuration.FT;
				b15.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "MIS");


				var result = await _userManager.CreateAsync(b15, "jrod2017");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b15 = _db.Users.FirstOrDefault(u => u.UserName == "toddj@yourmom.com");
			}

			if (await _userManager.IsInRoleAsync(b15,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b15,"Student");
			}

			_db.SaveChanges();


			AppUser b16 = _db.Users.FirstOrDefault(u => u.Email == "Lockhart") ;

			if (b16 == null)
			{

				b16 = new AppUser();
				b16.UserName = "thequeen@aska.net";
				b16.Email = "thequeen@aska.net";
				b16.FirstName = "Victoria";
				b16.LastName = "Lawrence";
				b16.ActiveStatus = true;
				b16.Birthday = new DateTime (1997,1,29);
				b16.GradDate = 2021;
				b16.GPA = 3.72m;
				b16.PositionType = PositionDuration.I;
				b16.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "MIS");


				var result = await _userManager.CreateAsync(b16, "longhorns");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b16 = _db.Users.FirstOrDefault(u => u.UserName == "thequeen@aska.net");
			}

			if (await _userManager.IsInRoleAsync(b16,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b16,"Student");
			}

			_db.SaveChanges();


			AppUser b17 = _db.Users.FirstOrDefault(u => u.Email == "Kingwood") ;

			if (b17 == null)
			{

				b17 = new AppUser();
				b17.UserName = "linebacker@gogle.com";
				b17.Email = "linebacker@gogle.com";
				b17.FirstName = "Erik";
				b17.LastName = "Lineback";
				b17.ActiveStatus = true;
				b17.Birthday = new DateTime (2000,5,21);
				b17.GradDate = 2022;
				b17.GPA = 3.15m;
				b17.PositionType = PositionDuration.I;
				b17.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Accounting");


				var result = await _userManager.CreateAsync(b17, "louielouie");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b17 = _db.Users.FirstOrDefault(u => u.UserName == "linebacker@gogle.com");
			}

			if (await _userManager.IsInRoleAsync(b17,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b17,"Student");
			}

			_db.SaveChanges();


			AppUser b18 = _db.Users.FirstOrDefault(u => u.Email == "Beverly Hills") ;

			if (b18 == null)
			{

				b18 = new AppUser();
				b18.UserName = "elowe@netscare.net";
				b18.Email = "elowe@netscare.net";
				b18.FirstName = "Ernest";
				b18.LastName = "Lowe";
				b18.ActiveStatus = true;
				b18.Birthday = new DateTime (1997,12,27);
				b18.GradDate = 2019;
				b18.GPA = 3.07m;
				b18.PositionType = PositionDuration.FT;
				b18.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Finance");


				var result = await _userManager.CreateAsync(b18, "martin1234");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b18 = _db.Users.FirstOrDefault(u => u.UserName == "elowe@netscare.net");
			}

			if (await _userManager.IsInRoleAsync(b18,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b18,"Student");
			}

			_db.SaveChanges();


			AppUser b19 = _db.Users.FirstOrDefault(u => u.Email == "Navasota") ;

			if (b19 == null)
			{

				b19 = new AppUser();
				b19.UserName = "cluce@gogle.com";
				b19.Email = "cluce@gogle.com";
				b19.FirstName = "Chuck";
				b19.LastName = "Luce";
				b19.ActiveStatus = true;
				b19.Birthday = new DateTime (1997,12,23);
				b19.GradDate = 2020;
				b19.GPA = 3.87m;
				b19.PositionType = PositionDuration.I;
				b19.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Accounting");


				var result = await _userManager.CreateAsync(b19, "meganr34");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b19 = _db.Users.FirstOrDefault(u => u.UserName == "cluce@gogle.com");
			}

			if (await _userManager.IsInRoleAsync(b19,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b19,"Student");
			}

			_db.SaveChanges();


			AppUser b20 = _db.Users.FirstOrDefault(u => u.Email == "Austin") ;

			if (b20 == null)
			{

				b20 = new AppUser();
				b20.UserName = "mackcloud@george.com";
				b20.Email = "mackcloud@george.com";
				b20.FirstName = "Jennifer";
				b20.LastName = "MacLeod";
				b20.ActiveStatus = true;
				b20.Birthday = new DateTime (1996,11,12);
				b20.GradDate = 2019;
				b20.GPA = 4m;
				b20.PositionType = PositionDuration.FT;
				b20.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "MIS");


				var result = await _userManager.CreateAsync(b20, "meow88");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b20 = _db.Users.FirstOrDefault(u => u.UserName == "mackcloud@george.com");
			}

			if (await _userManager.IsInRoleAsync(b20,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b20,"Student");
			}

			_db.SaveChanges();


			AppUser b21 = _db.Users.FirstOrDefault(u => u.Email == "Austin") ;

			if (b21 == null)
			{

				b21 = new AppUser();
				b21.UserName = "cmartin@beets.com";
				b21.Email = "cmartin@beets.com";
				b21.FirstName = "Elizabeth";
				b21.LastName = "Markham";
				b21.ActiveStatus = true;
				b21.Birthday = new DateTime (1996,12,21);
				b21.GradDate = 2019;
				b21.GPA = 3.53m;
				b21.PositionType = PositionDuration.FT;
				b21.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Business Honors");


				var result = await _userManager.CreateAsync(b21, "mustangs");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b21 = _db.Users.FirstOrDefault(u => u.UserName == "cmartin@beets.com");
			}

			if (await _userManager.IsInRoleAsync(b21,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b21,"Student");
			}

			_db.SaveChanges();


			AppUser b22 = _db.Users.FirstOrDefault(u => u.Email == "Schenectady") ;

			if (b22 == null)
			{

				b22 = new AppUser();
				b22.UserName = "clarence@yoho.com";
				b22.Email = "clarence@yoho.com";
				b22.FirstName = "Clarence";
				b22.LastName = "Martin";
				b22.ActiveStatus = true;
				b22.Birthday = new DateTime (1998,10,27);
				b22.GradDate = 2020;
				b22.GPA = 3.11m;
				b22.PositionType = PositionDuration.I;
				b22.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Supply Chain Management");


				var result = await _userManager.CreateAsync(b22, "mydogspot");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b22 = _db.Users.FirstOrDefault(u => u.UserName == "clarence@yoho.com");
			}

			if (await _userManager.IsInRoleAsync(b22,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b22,"Student");
			}

			_db.SaveChanges();


			AppUser b23 = _db.Users.FirstOrDefault(u => u.Email == "Austin") ;

			if (b23 == null)
			{

				b23 = new AppUser();
				b23.UserName = "gregmartinez@drdre.com";
				b23.Email = "gregmartinez@drdre.com";
				b23.FirstName = "Gregory";
				b23.LastName = "Martinez";
				b23.ActiveStatus = true;
				b23.Birthday = new DateTime (1999,5,11);
				b23.GradDate = 2021;
				b23.GPA = 3.43m;
				b23.PositionType = PositionDuration.I;
				b23.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Business Honors");


				var result = await _userManager.CreateAsync(b23, "nothinggood");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b23 = _db.Users.FirstOrDefault(u => u.UserName == "gregmartinez@drdre.com");
			}

			if (await _userManager.IsInRoleAsync(b23,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b23,"Student");
			}

			_db.SaveChanges();


			AppUser b24 = _db.Users.FirstOrDefault(u => u.Email == "Austin") ;

			if (b24 == null)
			{

				b24 = new AppUser();
				b24.UserName = "cmiller@bob.com";
				b24.Email = "cmiller@bob.com";
				b24.FirstName = "Charles";
				b24.LastName = "Miller";
				b24.ActiveStatus = true;
				b24.Birthday = new DateTime (1997,6,16);
				b24.GradDate = 2020;
				b24.GPA = 3.14m;
				b24.PositionType = PositionDuration.I;
				b24.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Management");


				var result = await _userManager.CreateAsync(b24, "onetime");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b24 = _db.Users.FirstOrDefault(u => u.UserName == "cmiller@bob.com");
			}

			if (await _userManager.IsInRoleAsync(b24,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b24,"Student");
			}

			_db.SaveChanges();


			AppUser b25 = _db.Users.FirstOrDefault(u => u.Email == "Beaumont") ;

			if (b25 == null)
			{

				b25 = new AppUser();
				b25.UserName = "knelson@aoll.com";
				b25.Email = "knelson@aoll.com";
				b25.FirstName = "Kelly";
				b25.LastName = "Nelson";
				b25.ActiveStatus = true;
				b25.Birthday = new DateTime (1999,7,23);
				b25.GradDate = 2019;
				b25.GPA = 3.03m;
				b25.PositionType = PositionDuration.FT;
				b25.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Finance");


				var result = await _userManager.CreateAsync(b25, "painting");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b25 = _db.Users.FirstOrDefault(u => u.UserName == "knelson@aoll.com");
			}

			if (await _userManager.IsInRoleAsync(b25,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b25,"Student");
			}

			_db.SaveChanges();


			AppUser b26 = _db.Users.FirstOrDefault(u => u.Email == "San Marcos") ;

			if (b26 == null)
			{

				b26 = new AppUser();
				b26.UserName = "joewin@xfactor.com";
				b26.Email = "joewin@xfactor.com";
				b26.FirstName = "Joe";
				b26.LastName = "Nguyen";
				b26.ActiveStatus = true;
				b26.Birthday = new DateTime (1996,12,23);
				b26.GradDate = 2019;
				b26.GPA = 3.65m;
				b26.PositionType = PositionDuration.FT;
				b26.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Management");


				var result = await _userManager.CreateAsync(b26, "Password1");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b26 = _db.Users.FirstOrDefault(u => u.UserName == "joewin@xfactor.com");
			}

			if (await _userManager.IsInRoleAsync(b26,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b26,"Student");
			}

			_db.SaveChanges();


			AppUser b27 = _db.Users.FirstOrDefault(u => u.Email == "Bergheim") ;

			if (b27 == null)
			{

				b27 = new AppUser();
				b27.UserName = "orielly@foxnews.cnn";
				b27.Email = "orielly@foxnews.cnn";
				b27.FirstName = "Bill";
				b27.LastName = "O'Reilly";
				b27.ActiveStatus = true;
				b27.Birthday = new DateTime (1997,11,24);
				b27.GradDate = 2020;
				b27.GPA = 3.46m;
				b27.PositionType = PositionDuration.I;
				b27.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Finance");


				var result = await _userManager.CreateAsync(b27, "penguin12");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b27 = _db.Users.FirstOrDefault(u => u.UserName == "orielly@foxnews.cnn");
			}

			if (await _userManager.IsInRoleAsync(b27,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b27,"Student");
			}

			_db.SaveChanges();


			AppUser b28 = _db.Users.FirstOrDefault(u => u.Email == "Austin") ;

			if (b28 == null)
			{

				b28 = new AppUser();
				b28.UserName = "ankaisrad@gogle.com";
				b28.Email = "ankaisrad@gogle.com";
				b28.FirstName = "Anka";
				b28.LastName = "Radkovich";
				b28.ActiveStatus = true;
				b28.Birthday = new DateTime (1997,8,8);
				b28.GradDate = 2019;
				b28.GPA = 3.67m;
				b28.PositionType = PositionDuration.FT;
				b28.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Business Honors");


				var result = await _userManager.CreateAsync(b28, "pepperoni");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b28 = _db.Users.FirstOrDefault(u => u.UserName == "ankaisrad@gogle.com");
			}

			if (await _userManager.IsInRoleAsync(b28,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b28,"Student");
			}

			_db.SaveChanges();


			AppUser b29 = _db.Users.FirstOrDefault(u => u.Email == "Orlando") ;

			if (b29 == null)
			{

				b29 = new AppUser();
				b29.UserName = "megrhodes@freserve.co.uk";
				b29.Email = "megrhodes@freserve.co.uk";
				b29.FirstName = "Megan";
				b29.LastName = "Rhodes";
				b29.ActiveStatus = true;
				b29.Birthday = new DateTime (1997,5,20);
				b29.GradDate = 2020;
				b29.GPA = 3.14m;
				b29.PositionType = PositionDuration.I;
				b29.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Management");


				var result = await _userManager.CreateAsync(b29, "potato");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b29 = _db.Users.FirstOrDefault(u => u.UserName == "megrhodes@freserve.co.uk");
			}

			if (await _userManager.IsInRoleAsync(b29,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b29,"Student");
			}

			_db.SaveChanges();


			AppUser b30 = _db.Users.FirstOrDefault(u => u.Email == "South Padre Island") ;

			if (b30 == null)
			{

				b30 = new AppUser();
				b30.UserName = "erynrice@aoll.com";
				b30.Email = "erynrice@aoll.com";
				b30.FirstName = "Eryn";
				b30.LastName = "Rice";
				b30.ActiveStatus = true;
				b30.Birthday = new DateTime (2000,4,29);
				b30.GradDate = 2022;
				b30.GPA = 3.92m;
				b30.PositionType = PositionDuration.I;
				b30.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Marketing");


				var result = await _userManager.CreateAsync(b30, "radgirl");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b30 = _db.Users.FirstOrDefault(u => u.UserName == "erynrice@aoll.com");
			}

			if (await _userManager.IsInRoleAsync(b30,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b30,"Student");
			}

			_db.SaveChanges();


			AppUser b31 = _db.Users.FirstOrDefault(u => u.Email == "Austin") ;

			if (b31 == null)
			{

				b31 = new AppUser();
				b31.UserName = "jorge@noclue.com";
				b31.Email = "jorge@noclue.com";
				b31.FirstName = "Jorge";
				b31.LastName = "Rodriguez";
				b31.ActiveStatus = true;
				b31.Birthday = new DateTime (1998,10,3);
				b31.GradDate = 2021;
				b31.GPA = 3.64m;
				b31.PositionType = PositionDuration.I;
				b31.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "MIS");


				var result = await _userManager.CreateAsync(b31, "raiders");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b31 = _db.Users.FirstOrDefault(u => u.UserName == "jorge@noclue.com");
			}

			if (await _userManager.IsInRoleAsync(b31,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b31,"Student");
			}

			_db.SaveChanges();


			AppUser b32 = _db.Users.FirstOrDefault(u => u.Email == "Canyon Lake") ;

			if (b32 == null)
			{

				b32 = new AppUser();
				b32.UserName = "mrrogers@lovelyday.com";
				b32.Email = "mrrogers@lovelyday.com";
				b32.FirstName = "Allen";
				b32.LastName = "Rogers";
				b32.ActiveStatus = true;
				b32.Birthday = new DateTime (1997,2,20);
				b32.GradDate = 2020;
				b32.GPA = 3.01m;
				b32.PositionType = PositionDuration.I;
				b32.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Marketing");


				var result = await _userManager.CreateAsync(b32, "ricearoni");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b32 = _db.Users.FirstOrDefault(u => u.UserName == "mrrogers@lovelyday.com");
			}

			if (await _userManager.IsInRoleAsync(b32,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b32,"Student");
			}

			_db.SaveChanges();


			AppUser b33 = _db.Users.FirstOrDefault(u => u.Email == "Austin") ;

			if (b33 == null)
			{

				b33 = new AppUser();
				b33.UserName = "stjean@athome.com";
				b33.Email = "stjean@athome.com";
				b33.FirstName = "Olivier";
				b33.LastName = "Saint-Jean";
				b33.ActiveStatus = true;
				b33.Birthday = new DateTime (1998,2,26);
				b33.GradDate = 2019;
				b33.GPA = 3.24m;
				b33.PositionType = PositionDuration.FT;
				b33.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Science and Technology Management");


				var result = await _userManager.CreateAsync(b33, "rogerthat");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b33 = _db.Users.FirstOrDefault(u => u.UserName == "stjean@athome.com");
			}

			if (await _userManager.IsInRoleAsync(b33,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b33,"Student");
			}

			_db.SaveChanges();


			AppUser b34 = _db.Users.FirstOrDefault(u => u.Email == "Austin") ;

			if (b34 == null)
			{

				b34 = new AppUser();
				b34.UserName = "saunders@pen.com";
				b34.Email = "saunders@pen.com";
				b34.FirstName = "Sarah";
				b34.LastName = "Saunders";
				b34.ActiveStatus = true;
				b34.Birthday = new DateTime (1998,2,5);
				b34.GradDate = 2020;
				b34.GPA = 3.16m;
				b34.PositionType = PositionDuration.I;
				b34.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Supply Chain Management");


				var result = await _userManager.CreateAsync(b34, "slowwind");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b34 = _db.Users.FirstOrDefault(u => u.UserName == "saunders@pen.com");
			}

			if (await _userManager.IsInRoleAsync(b34,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b34,"Student");
			}

			_db.SaveChanges();


			AppUser b35 = _db.Users.FirstOrDefault(u => u.Email == "Austin") ;

			if (b35 == null)
			{

				b35 = new AppUser();
				b35.UserName = "willsheff@email.com";
				b35.Email = "willsheff@email.com";
				b35.FirstName = "William";
				b35.LastName = "Sewell";
				b35.ActiveStatus = true;
				b35.Birthday = new DateTime (1998,10,13);
				b35.GradDate = 2019;
				b35.GPA = 3.07m;
				b35.PositionType = PositionDuration.FT;
				b35.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "MIS");


				var result = await _userManager.CreateAsync(b35, "smitty444");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b35 = _db.Users.FirstOrDefault(u => u.UserName == "willsheff@email.com");
			}

			if (await _userManager.IsInRoleAsync(b35,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b35,"Student");
			}

			_db.SaveChanges();


			AppUser b36 = _db.Users.FirstOrDefault(u => u.Email == "Round Rock") ;

			if (b36 == null)
			{

				b36 = new AppUser();
				b36.UserName = "sheffiled@gogle.com";
				b36.Email = "sheffiled@gogle.com";
				b36.FirstName = "Martin";
				b36.LastName = "Sheffield";
				b36.ActiveStatus = true;
				b36.Birthday = new DateTime (1998,10,11);
				b36.GradDate = 2020;
				b36.GPA = 3.36m;
				b36.PositionType = PositionDuration.I;
				b36.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "MIS");


				var result = await _userManager.CreateAsync(b36, "snowsnow");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b36 = _db.Users.FirstOrDefault(u => u.UserName == "sheffiled@gogle.com");
			}

			if (await _userManager.IsInRoleAsync(b36,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b36,"Student");
			}

			_db.SaveChanges();


			AppUser b37 = _db.Users.FirstOrDefault(u => u.Email == "Austin") ;

			if (b37 == null)
			{

				b37 = new AppUser();
				b37.UserName = "johnsmith187@aoll.com";
				b37.Email = "johnsmith187@aoll.com";
				b37.FirstName = "John";
				b37.LastName = "Smith";
				b37.ActiveStatus = true;
				b37.Birthday = new DateTime (1997,8,19);
				b37.GradDate = 2019;
				b37.GPA = 3.57m;
				b37.PositionType = PositionDuration.FT;
				b37.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Finance");


				var result = await _userManager.CreateAsync(b37, "something");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b37 = _db.Users.FirstOrDefault(u => u.UserName == "johnsmith187@aoll.com");
			}

			if (await _userManager.IsInRoleAsync(b37,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b37,"Student");
			}

			_db.SaveChanges();


			AppUser b38 = _db.Users.FirstOrDefault(u => u.Email == "Sweet Home") ;

			if (b38 == null)
			{

				b38 = new AppUser();
				b38.UserName = "dustroud@mail.com";
				b38.Email = "dustroud@mail.com";
				b38.FirstName = "Dustin";
				b38.LastName = "Stroud";
				b38.ActiveStatus = true;
				b38.Birthday = new DateTime (1998,3,5);
				b38.GradDate = 2020;
				b38.GPA = 3.49m;
				b38.PositionType = PositionDuration.I;
				b38.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Marketing");


				var result = await _userManager.CreateAsync(b38, "spotmydog");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b38 = _db.Users.FirstOrDefault(u => u.UserName == "dustroud@mail.com");
			}

			if (await _userManager.IsInRoleAsync(b38,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b38,"Student");
			}

			_db.SaveChanges();


			AppUser b39 = _db.Users.FirstOrDefault(u => u.Email == "Corpus Christi") ;

			if (b39 == null)
			{

				b39 = new AppUser();
				b39.UserName = "estuart@anchor.net";
				b39.Email = "estuart@anchor.net";
				b39.FirstName = "Eric";
				b39.LastName = "Stuart";
				b39.ActiveStatus = true;
				b39.Birthday = new DateTime (1999,4,17);
				b39.GradDate = 2019;
				b39.GPA = 3.58m;
				b39.PositionType = PositionDuration.FT;
				b39.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Business Honors");


				var result = await _userManager.CreateAsync(b39, "stewball");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b39 = _db.Users.FirstOrDefault(u => u.UserName == "estuart@anchor.net");
			}

			if (await _userManager.IsInRoleAsync(b39,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b39,"Student");
			}

			_db.SaveChanges();


			AppUser b40 = _db.Users.FirstOrDefault(u => u.Email == "Pflugerville") ;

			if (b40 == null)
			{

				b40 = new AppUser();
				b40.UserName = "peterstump@noclue.com";
				b40.Email = "peterstump@noclue.com";
				b40.FirstName = "Peter";
				b40.LastName = "Stump";
				b40.ActiveStatus = true;
				b40.Birthday = new DateTime (1998,5,9);
				b40.GradDate = 2021;
				b40.GPA = 2.55m;
				b40.PositionType = PositionDuration.I;
				b40.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Supply Chain Management");


				var result = await _userManager.CreateAsync(b40, "tanner5454");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b40 = _db.Users.FirstOrDefault(u => u.UserName == "peterstump@noclue.com");
			}

			if (await _userManager.IsInRoleAsync(b40,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b40,"Student");
			}

			_db.SaveChanges();


			AppUser b41 = _db.Users.FirstOrDefault(u => u.Email == "Austin") ;

			if (b41 == null)
			{

				b41 = new AppUser();
				b41.UserName = "jtanner@mustang.net";
				b41.Email = "jtanner@mustang.net";
				b41.FirstName = "Jeremy";
				b41.LastName = "Tanner";
				b41.ActiveStatus = true;
				b41.Birthday = new DateTime (1998,12,15);
				b41.GradDate = 2020;
				b41.GPA = 3.16m;
				b41.PositionType = PositionDuration.I;
				b41.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Management");


				var result = await _userManager.CreateAsync(b41, "taylorbaylor");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b41 = _db.Users.FirstOrDefault(u => u.UserName == "jtanner@mustang.net");
			}

			if (await _userManager.IsInRoleAsync(b41,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b41,"Student");
			}

			_db.SaveChanges();


			AppUser b42 = _db.Users.FirstOrDefault(u => u.Email == "Austin") ;

			if (b42 == null)
			{

				b42 = new AppUser();
				b42.UserName = "taylordjay@aoll.com";
				b42.Email = "taylordjay@aoll.com";
				b42.FirstName = "Allison";
				b42.LastName = "Taylor";
				b42.ActiveStatus = true;
				b42.Birthday = new DateTime (1997,7,27);
				b42.GradDate = 2019;
				b42.GPA = 3.07m;
				b42.PositionType = PositionDuration.FT;
				b42.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Marketing");


				var result = await _userManager.CreateAsync(b42, "teeoff22");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b42 = _db.Users.FirstOrDefault(u => u.UserName == "taylordjay@aoll.com");
			}

			if (await _userManager.IsInRoleAsync(b42,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b42,"Student");
			}

			_db.SaveChanges();


			AppUser b43 = _db.Users.FirstOrDefault(u => u.Email == "Austin") ;

			if (b43 == null)
			{

				b43 = new AppUser();
				b43.UserName = "rtaylor@gogle.com";
				b43.Email = "rtaylor@gogle.com";
				b43.FirstName = "Rachel";
				b43.LastName = "Taylor";
				b43.ActiveStatus = true;
				b43.Birthday = new DateTime (1999,5,16);
				b43.GradDate = 2020;
				b43.GPA = 2.88m;
				b43.PositionType = PositionDuration.I;
				b43.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Finance");


				var result = await _userManager.CreateAsync(b43, "texas1");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b43 = _db.Users.FirstOrDefault(u => u.UserName == "rtaylor@gogle.com");
			}

			if (await _userManager.IsInRoleAsync(b43,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b43,"Student");
			}

			_db.SaveChanges();


			AppUser b44 = _db.Users.FirstOrDefault(u => u.Email == "Austin") ;

			if (b44 == null)
			{

				b44 = new AppUser();
				b44.UserName = "teefrank@noclue.com";
				b44.Email = "teefrank@noclue.com";
				b44.FirstName = "Frank";
				b44.LastName = "Tee";
				b44.ActiveStatus = true;
				b44.Birthday = new DateTime (1999,8,22);
				b44.GradDate = 2019;
				b44.GPA = 3.5m;
				b44.PositionType = PositionDuration.FT;
				b44.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Finance");


				var result = await _userManager.CreateAsync(b44, "toddy25");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b44 = _db.Users.FirstOrDefault(u => u.UserName == "teefrank@noclue.com");
			}

			if (await _userManager.IsInRoleAsync(b44,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b44,"Student");
			}

			_db.SaveChanges();


			AppUser b45 = _db.Users.FirstOrDefault(u => u.Email == "San Antonio") ;

			if (b45 == null)
			{

				b45 = new AppUser();
				b45.UserName = "ctucker@alphabet.co.uk";
				b45.Email = "ctucker@alphabet.co.uk";
				b45.FirstName = "Clent";
				b45.LastName = "Tucker";
				b45.ActiveStatus = true;
				b45.Birthday = new DateTime (1997,9,28);
				b45.GradDate = 2020;
				b45.GPA = 3.04m;
				b45.PositionType = PositionDuration.I;
				b45.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "MIS");


				var result = await _userManager.CreateAsync(b45, "tucksack1");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b45 = _db.Users.FirstOrDefault(u => u.UserName == "ctucker@alphabet.co.uk");
			}

			if (await _userManager.IsInRoleAsync(b45,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b45,"Student");
			}

			_db.SaveChanges();


			AppUser b46 = _db.Users.FirstOrDefault(u => u.Email == "Navasota") ;

			if (b46 == null)
			{

				b46 = new AppUser();
				b46.UserName = "avelasco@yoho.com";
				b46.Email = "avelasco@yoho.com";
				b46.FirstName = "Allen";
				b46.LastName = "Velasco";
				b46.ActiveStatus = true;
				b46.Birthday = new DateTime (1999,6,27);
				b46.GradDate = 2019;
				b46.GPA = 3.55m;
				b46.PositionType = PositionDuration.FT;
				b46.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "MIS");


				var result = await _userManager.CreateAsync(b46, "vinovino");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b46 = _db.Users.FirstOrDefault(u => u.UserName == "avelasco@yoho.com");
			}

			if (await _userManager.IsInRoleAsync(b46,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b46,"Student");
			}

			_db.SaveChanges();


			AppUser b47 = _db.Users.FirstOrDefault(u => u.Email == "Boston") ;

			if (b47 == null)
			{

				b47 = new AppUser();
				b47.UserName = "vinovino@grapes.com";
				b47.Email = "vinovino@grapes.com";
				b47.FirstName = "Janet";
				b47.LastName = "Vino";
				b47.ActiveStatus = true;
				b47.Birthday = new DateTime (1993,12,17);
				b47.GradDate = 2021;
				b47.GPA = 3.28m;
				b47.PositionType = PositionDuration.I;
				b47.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Business Honors");


				var result = await _userManager.CreateAsync(b47, "whatever");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b47 = _db.Users.FirstOrDefault(u => u.UserName == "vinovino@grapes.com");
			}

			if (await _userManager.IsInRoleAsync(b47,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b47,"Student");
			}

			_db.SaveChanges();


			AppUser b48 = _db.Users.FirstOrDefault(u => u.Email == "Austin") ;

			if (b48 == null)
			{

				b48 = new AppUser();
				b48.UserName = "winner@hootmail.com";
				b48.Email = "winner@hootmail.com";
				b48.FirstName = "Louis";
				b48.LastName = "Winthorpe";
				b48.ActiveStatus = true;
				b48.Birthday = new DateTime (1997,1,20);
				b48.GradDate = 2019;
				b48.GPA = 2.57m;
				b48.PositionType = PositionDuration.FT;
				b48.Major = _db.Majors.FirstOrDefault(m => m.MajorName == "Finance");


				var result = await _userManager.CreateAsync(b48, "woodyman1");
				if (result.Succeeded == false)
				{
					throw new Exception("This user cannot be added - "+ result.ToString());
				}
				_db.SaveChanges();
				b48 = _db.Users.FirstOrDefault(u => u.UserName == "winner@hootmail.com");
			}

			if (await _userManager.IsInRoleAsync(b48,"Student") == false)
			{
				await _userManager.AddToRoleAsync(b48,"Student");
			}

			_db.SaveChanges();


		}
	}
}
