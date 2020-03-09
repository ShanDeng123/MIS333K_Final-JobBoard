using sp19team23finalproject.Models;
using sp19team23finalproject.DAL;
using System.Collections.Generic;
using System;
using System.Linq;
using sp19team23finalproject.Controllers;


namespace sp19team23finalproject.Seeding
{
	public static class SeedInterviews
	{
		public static void SeedAllInterviews(AppDbContext db)
		{
			if (db.Interviews.Count() == 14)
			{
				throw new NotSupportedException("The database already contains all 14 Interviews!");
			}

			Int32 intInterviewsAdded = 0;
			String strInterviewPosition = "Begin"; //helps to keep track of error on interviews
			List<Interview> Interviews = new List<Interview>();

			try
			{
				Interview i1 = new Interview()
				{
                    InterviewDate = new DateTime(2019, 5, 13),
                    InterviewTime = InterviewTime.time1,
                    InterviewRoom = 2,
					InterviewStatus = true
				};
				i1.Student = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Lou Ann" & g.LastName == "Feeley"));
				i1.Recruiter = db.AppUsers.FirstOrDefault(g => g.FirstName == "Allison" & g.LastName == "Taylor");
				i1.Position = db.Positions.FirstOrDefault(g => g.Title == "Marketing Intern");
                i1.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Adlucent");

                Interviews.Add(i1);

				Interview i2 = new Interview()
				{
                    InterviewDate = new DateTime(2019, 5, 14),
                    InterviewTime = InterviewTime.time1,
                    InterviewRoom = 2,
					InterviewStatus = true
				};
				i2.Student = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Eryn" & g.LastName == "Rice"));
				i2.Recruiter = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Allison" & g.LastName == "Taylor"));
				i2.Position = db.Positions.FirstOrDefault(g => g.Title == "Marketing Intern");
                i2.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Adlucent");

                Interviews.Add(i2);

				Interview i3 = new Interview()
				{
                    InterviewDate = new DateTime(2019, 5, 15),
                    InterviewTime = InterviewTime.time1,
                    InterviewRoom = 2,
					InterviewStatus = true
				};
				i3.Student = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Charles" & g.LastName == "Miller"));
				i3.Recruiter = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Louis" & g.LastName == "Winthorpe"));
				i3.Position = db.Positions.FirstOrDefault(g => g.Title == "Corporate Recruiting Intern");
                i3.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Microsoft");

                Interviews.Add(i3);

				Interview i4 = new Interview()
				{
                    InterviewDate = new DateTime(2019, 5, 13),
                    InterviewTime = InterviewTime.time10,
                    InterviewRoom = 1,
                    InterviewStatus = true
				};
				i4.Student = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Eric" & g.LastName == "Stuart"));
				i4.Recruiter = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Clarence" & g.LastName == "Martin"));
				i4.Position = db.Positions.FirstOrDefault(g => g.Title == "Account Manager");
                i4.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Deloitte");

                Interviews.Add(i4);

				Interview i5 = new Interview()
				{
                    InterviewDate = new DateTime(2019, 5, 16),
                    InterviewTime = InterviewTime.time2,
                    InterviewRoom = 2,
                    InterviewStatus = true
				};
				i5.Student = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Christopher" & g.LastName == "Baker"));
				i5.Recruiter = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Gregory" & g.LastName == "Martinez"));
				i5.Position = db.Positions.FirstOrDefault(g => g.Title == "Web Development");
                i5.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Capital One");

                Interviews.Add(i5);

				Interview i6 = new Interview()
				{
                    InterviewDate = new DateTime(2019, 4, 1),
                    InterviewTime = InterviewTime.time9,
                    InterviewRoom = 1,
                    InterviewStatus = true
				};
				i6.Student = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Eryn" & g.LastName == "Rice"));
				i6.Recruiter = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Rachel" & g.LastName == "Taylor"));
				i6.Position = db.Positions.FirstOrDefault(g => g.Title == "Amenities Analytics Intern");
                i6.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Hilton Worldwide");

                Interviews.Add(i6);

				Interview i7 = new Interview()
				{
                    InterviewDate = new DateTime(2019, 4, 1),
                    InterviewTime = InterviewTime.time10,
                    InterviewRoom = 1,
					InterviewStatus = true
				};
				i7.Student = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Tesa" & g.LastName == "Freeley"));
				i7.Recruiter = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Rachel" & g.LastName == "Taylor"));
				i7.Position = db.Positions.FirstOrDefault(g => g.Title == "Amenities Analytics Intern");
                i7.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Hilton Worldwide");

                Interviews.Add(i7);

				Interview i8 = new Interview()
				{
                    InterviewDate = new DateTime(2019, 4, 2),
                    InterviewTime = InterviewTime.time3,
                    InterviewRoom = 4,
					InterviewStatus = true
				};
				i8.Student = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Lim" & g.LastName == "Chou"));
				i8.Recruiter = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Rachel" & g.LastName == "Taylor"));
				i8.Position = db.Positions.FirstOrDefault(g => g.Title == "Amenities Analytics Intern");
                i8.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Hilton Worldwide");

                Interviews.Add(i8);

				Interview i9 = new Interview()
				{
                    InterviewDate = new DateTime(2019, 5, 10),
                    InterviewTime = InterviewTime.time9,
                    InterviewRoom = 1,
					InterviewStatus = true
				};
				i9.Student = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Brad" & g.LastName == "Ingram"));
				i9.Recruiter = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Ernest" & g.LastName == "Lowe"));
				i9.Position = db.Positions.FirstOrDefault(g => g.Title == "Supply Chain Internship");
                i9.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Shell");

                Interviews.Add(i9);

				Interview i10 = new Interview()
				{
                    InterviewDate = new DateTime(2019, 5, 10),
                    InterviewTime = InterviewTime.time11,
                    InterviewRoom = 1,
					InterviewStatus = true
				};
				i10.Student = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Sarah" & g.LastName == "Saunders"));
				i10.Recruiter = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Ernest" & g.LastName == "Lowe"));
				i10.Position = db.Positions.FirstOrDefault(g => g.Title == "Supply Chain Internship");
                i10.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Shell");

                Interviews.Add(i10);

				Interview i11 = new Interview()
				{
                    InterviewDate = new DateTime(2019, 5, 16),
                    InterviewTime = InterviewTime.time3,
                    InterviewRoom = 3,
					InterviewStatus = true
				};
				i11.Student = db.AppUsers.FirstOrDefault(g => (g.FirstName == "John" & g.LastName == "Smith"));
				i11.Recruiter = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Anka" & g.LastName == "Radkovich"));
				i11.Position = db.Positions.FirstOrDefault(g => g.Title == "Financial Analyst");
                i11.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Capital One");

                Interviews.Add(i11);

				Interview i12 = new Interview()
				{
                    InterviewDate = new DateTime(2019, 5, 16),
                    InterviewTime = InterviewTime.time11,
                    InterviewRoom = 4,
					InterviewStatus = true
				};
				i12.Student = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Chuck" & g.LastName == "Luce"));
				i12.Recruiter = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Kelly" & g.LastName == "Nelson"));
				i12.Position = db.Positions.FirstOrDefault(g => g.Title == "Accounting Intern");
                i12.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Deloitte");

                Interviews.Add(i12);

				Interview i13 = new Interview()
				{
                    InterviewDate = new DateTime(2019, 6, 5),
                    InterviewTime = InterviewTime.time2,
                    InterviewRoom = 3,
					InterviewStatus = true
				};
				i13.Student = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Eric" & g.LastName == "Stuart"));
				i13.Recruiter = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Michelle" & g.LastName == "Banks"));
				i13.Position = db.Positions.FirstOrDefault(g => g.Title == "Consultant");
                i13.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Accenture");

                Interviews.Add(i13);

				Interview i14 = new Interview()
				{
                    InterviewDate = new DateTime(2019, 6, 5),
                    InterviewTime = InterviewTime.time4,
                    InterviewRoom = 3,
					InterviewStatus = true
				};
				i14.Student = db.AppUsers.FirstOrDefault(g => (g.FirstName == "John" & g.LastName == "Hearn"));
				i14.Recruiter = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Todd" & g.LastName == "Jacobs"));
				i14.Position = db.Positions.FirstOrDefault(g => g.Title == "Consultant");
                i14.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Accenture");

                Interviews.Add(i14);

				try
				{
					foreach (Interview interviewToAdd in Interviews)
					{
						strInterviewPosition = interviewToAdd.Position.Title;
						Interview dbInterview = db.Interviews.FirstOrDefault(b => b.InterviewID == interviewToAdd.InterviewID);
						if (dbInterview == null) //this Interview doesn't exist
						{
							db.Interviews.Add(interviewToAdd);
							db.SaveChanges();
							intInterviewsAdded += 1;
						}
						else //Interview exists - update values
						{
							dbInterview.InterviewDate = interviewToAdd.InterviewDate;
                            dbInterview.InterviewTime = interviewToAdd.InterviewTime;
                            dbInterview.InterviewStatus = interviewToAdd.InterviewStatus;
							dbInterview.InterviewRoom = interviewToAdd.InterviewRoom;
							dbInterview.Recruiter = interviewToAdd.Recruiter;
							dbInterview.Student = interviewToAdd.Student;
							dbInterview.Position = interviewToAdd.Position;
                            dbInterview.Company = interviewToAdd.Company;
                            db.Update(dbInterview);
							db.SaveChanges();
							intInterviewsAdded += 1;
						}
					}
				}
				catch (Exception ex)
				{
					String msg = "  Repositories added:" + intInterviewsAdded + "; Error on " + strInterviewPosition;
					throw new InvalidOperationException(ex.Message + msg);
				}
			}
			catch (Exception e)
			{
				throw new InvalidOperationException(e.Message);
			}
		}
	}
}
