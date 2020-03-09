using sp19team23finalproject.Models;
using sp19team23finalproject.DAL;
using System.Collections.Generic;
using System;
using System.Linq;
using sp19team23finalproject.Controllers;


namespace sp19team23finalproject.Seeding
{
    public static class SeedApplications
    {
        public static void SeedAllApplications(AppDbContext db)
        {
            if (db.Applications.Count() == 14)
            {
                throw new NotSupportedException("The database already contains all 14 Applications!");
            }

            Int32 intApplicationsAdded = 0;
            Int32 strApplicationPosition = 0; //helps to keep track of error on applications
            List<Application> Applications = new List<Application>();

            try
            {
                Application i1 = new Application()
                {
                    ApplicationNumber = 1001,
                    Accepted = true,
                    Status = true
                };
                i1.User = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Lou Ann" & g.LastName == "Feeley"));
                i1.Position = db.Positions.FirstOrDefault(g => g.Title == "Marketing Intern");

                Applications.Add(i1);

                Application i2 = new Application()
                {
                    ApplicationNumber = 1002,
                    Accepted = true,
                    Status = true
                };
                i2.User = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Eryn" & g.LastName == "Rice"));
                i2.Position = db.Positions.FirstOrDefault(g => g.Title == "Marketing Intern");

                Applications.Add(i2);

                Application i3 = new Application()
                {
                    ApplicationNumber = 1003,
                    Accepted = true,
                    Status = true
                };
                i3.User = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Charles" & g.LastName == "Miller"));
                i3.Position = db.Positions.FirstOrDefault(g => g.Title == "Corporate Recruiting Intern");

                Applications.Add(i3);

                Application i4 = new Application()
                {
                    ApplicationNumber = 1004,
                    Accepted = true,
                    Status = true
                };
                i4.User = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Eric" & g.LastName == "Stuart"));
                i4.Position = db.Positions.FirstOrDefault(g => g.Title == "Account Manager");

                Applications.Add(i4);

                Application i5 = new Application()
                {
                    ApplicationNumber = 1005,
                    Accepted = true,
                    Status = true
                };
                i5.User = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Christopher" & g.LastName == "Baker"));
                i5.Position = db.Positions.FirstOrDefault(g => g.Title == "Web Development");

                Applications.Add(i5);

                Application i6 = new Application()
                {
                    ApplicationNumber = 1006,
                    Accepted = true,
                    Status = true
                };
                i6.User = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Eryn" & g.LastName == "Rice"));
                i6.Position = db.Positions.FirstOrDefault(g => g.Title == "Amenities Analytics Intern");

                Applications.Add(i6);

                Application i7 = new Application()
                {
                    ApplicationNumber = 1007,
                    Accepted = true,
                    Status = true
                };
                i7.User = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Tesa" & g.LastName == "Freeley"));
                i7.Position = db.Positions.FirstOrDefault(g => g.Title == "Amenities Analytics Intern");

                Applications.Add(i7);

                Application i8 = new Application()
                {
                    ApplicationNumber = 1008,
                    Accepted = true,
                    Status = true
                };
                i8.User = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Lim" & g.LastName == "Chou"));
                i8.Position = db.Positions.FirstOrDefault(g => g.Title == "Amenities Analytics Intern");

                Applications.Add(i8);

                Application i9 = new Application()
                {
                    ApplicationNumber = 1009,
                    Accepted = true,
                    Status = true
                };
                i9.User = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Brad" & g.LastName == "Ingram"));
                i9.Position = db.Positions.FirstOrDefault(g => g.Title == "Supply Chain Internship");

                Applications.Add(i9);

                Application i10 = new Application()
                {
                    ApplicationNumber = 1010,
                    Accepted = true,
                    Status = true
                };
                i10.User = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Sarah" & g.LastName == "Saunders"));
                i10.Position = db.Positions.FirstOrDefault(g => g.Title == "Supply Chain Internship");

                Applications.Add(i10);

                Application i11 = new Application()
                {
                    ApplicationNumber = 1011,
                    Accepted = true,
                    Status = true
                };
                i11.User = db.AppUsers.FirstOrDefault(g => (g.FirstName == "John" & g.LastName == "Smith"));
                i11.Position = db.Positions.FirstOrDefault(g => g.Title == "Financial Analyst");

                Applications.Add(i11);

                Application i12 = new Application()
                {
                    ApplicationNumber = 1012,
                    Accepted = true,
                    Status = true
                };
                i12.User = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Chuck" & g.LastName == "Luce"));
                i12.Position = db.Positions.FirstOrDefault(g => g.Title == "Accounting Intern");

                Applications.Add(i12);

                Application i13 = new Application()
                {
                    ApplicationNumber = 1013,
                    Accepted = true,
                    Status = true
                };
                i13.User = db.AppUsers.FirstOrDefault(g => (g.FirstName == "Eric" & g.LastName == "Stuart"));
                i13.Position = db.Positions.FirstOrDefault(g => g.Title == "Consultant");

                Applications.Add(i13);

                Application i14 = new Application()
                {
                    ApplicationNumber = 1014,
                    Accepted = true,
                    Status = true
                };
                i14.User = db.AppUsers.FirstOrDefault(g => (g.FirstName == "John" & g.LastName == "Hearn"));
                i14.Position = db.Positions.FirstOrDefault(g => g.Title == "Consultant");

                Applications.Add(i14);

                try
                {
                    foreach (Application applicationToAdd in Applications)
                    {
                        strApplicationPosition = applicationToAdd.ApplicationNumber;
                        Application dbApplication = db.Applications.FirstOrDefault(b => b.ApplicationID == applicationToAdd.ApplicationID);
                        if (dbApplication == null) //this Application doesn't exist
                        {
                            db.Applications.Add(applicationToAdd);
                            db.SaveChanges();
                            intApplicationsAdded += 1;
                        }
                        else //Application exists - update values
                        {
                            dbApplication.ApplicationNumber = applicationToAdd.ApplicationNumber;
                            dbApplication.Accepted = applicationToAdd.Accepted;
                            dbApplication.Status = applicationToAdd.Status;
                            dbApplication.User = applicationToAdd.User;
                            dbApplication.Position = applicationToAdd.Position;
                            db.Update(dbApplication);
                            db.SaveChanges();
                            intApplicationsAdded += 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    String msg = "  Repositories added:" + intApplicationsAdded + "; Error on " + strApplicationPosition;
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
