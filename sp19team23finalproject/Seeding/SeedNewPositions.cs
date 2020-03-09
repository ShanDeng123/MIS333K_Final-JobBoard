using sp19team23finalproject.Models;
using sp19team23finalproject.DAL;
using System.Collections.Generic;
using System;
using System.Linq;
using sp19team23finalproject.Controllers;

namespace sp19team23finalproject.Seeding
{
	public static class SeedNewPositions
	{
		public static void SeedAllPositionsNew(AppDbContext db)
		{
			if (db.Positions.Count() == 9)
			{
				throw new NotSupportedException("The database already contains all 28 Positions!");
			}

			Int32 intPositionsAdded = 0;
			String strPositionName = "Begin"; //helps to keep track of error on books
			List<Position> Positions = new List<Position>();

			try
			{
				Position p1 = new Position()
				{
					Title = "Supply Chain Internship",
					PositionType = PositionDuration.I,
					Location = "Houston, Texas",
					Deadline = new DateTime(2019, 5, 5),
					Description = ""
				};
				p1.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Shell");
				Positions.Add(p1);
                PositionMajor pm1 = new PositionMajor();
                pm1.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Supply Chain Management");
                pm1.Position = p1;
                p1.PositionMajors.Add(pm1);

                Position p2 = new Position()
				{
					Title = "Accounting Intern",
					PositionType = PositionDuration.I,
					Location = "Austin, Texas",
					Deadline = new DateTime(2019, 5, 1),
					Description = "Work in our audit group"
				};
				p2.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Deloitte");
				Positions.Add(p2);
                PositionMajor pm2 = new PositionMajor();
                pm2.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Accounting");
                pm2.Position = p2;
                p2.PositionMajors.Add(pm2);

                Position p3 = new Position()
				{
					Title = "Web Development",
					PositionType = PositionDuration.FT,
					Location = "Richmond, Virginia",
					Deadline = new DateTime(2019, 3, 14),
					Description = "Developing a great new website for customer portfolio management"
				};
				p3.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Capital One");
				Positions.Add(p3);
                PositionMajor pm3 = new PositionMajor();
                pm3.Major = db.Majors.FirstOrDefault(g => g.MajorName == "MIS");
                pm3.Position = p3;
                p3.PositionMajors.Add(pm3);

                Position p4 = new Position()
				{
					Title = "Sales Associate",
					PositionType = PositionDuration.FT,
					Location = "Los Angeles, California",
					Deadline = new DateTime(2019, 4, 1),
					Description = ""
				};
				p4.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Aon");
				Positions.Add(p4);
                PositionMajor pm4 = new PositionMajor();
                pm4.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Accounting");
                pm4.Position = p4;
                p4.PositionMajors.Add(pm4);

                PositionMajor pm5 = new PositionMajor();
                pm5.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Marketing");
                pm5.Position = p4;
                p4.PositionMajors.Add(pm5);

                PositionMajor pm6 = new PositionMajor();
                pm6.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Finance");
                pm6.Position = p4;
                p4.PositionMajors.Add(pm6);

                Position p5 = new Position()
				{
					Title = "Amenities Analytics Intern",
					PositionType = PositionDuration.I,
					Location = "New York, New York",
					Deadline = new DateTime(2019, 3, 30),
					Description = "Help analyze our amenities and customer rewards programs"
				};
				p5.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Hilton Worldwide");
				Positions.Add(p5);
                PositionMajor pm7 = new PositionMajor();
                pm7.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Finance");
                pm7.Position = p5;
                p5.PositionMajors.Add(pm7);

                PositionMajor pm8 = new PositionMajor();
                pm8.Major = db.Majors.FirstOrDefault(g => g.MajorName == "MIS");
                pm8.Position = p5;
                p5.PositionMajors.Add(pm8);

                PositionMajor pm9 = new PositionMajor();
                pm9.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Marketing");
                pm9.Position = p5;
                p5.PositionMajors.Add(pm9);

                PositionMajor pm10 = new PositionMajor();
                pm10.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Business Honors");
                pm10.Position = p5;
                p5.PositionMajors.Add(pm10);

                Position p6 = new Position()
				{
					Title = "Junior Programmer",
					PositionType = PositionDuration.I,
					Location = "Redmond, Washington",
					Deadline = new DateTime(2019, 4, 3),
					Description = ""
				};
				p6.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Microsoft");
				Positions.Add(p6);
                PositionMajor pm11 = new PositionMajor();
                pm11.Major = db.Majors.FirstOrDefault(g => g.MajorName == "MIS");
                pm11.Position = p6;
                p6.PositionMajors.Add(pm11);

                Position p7 = new Position()
				{
					Title = "Consultant ",
					PositionType = PositionDuration.FT,
					Location = "Houston, Texas",
					Deadline = new DateTime(2019, 4, 15),
					Description = "Full-time consultant position"
				};
				p7.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Accenture");
				Positions.Add(p7);
                PositionMajor pm12 = new PositionMajor();
                pm12.Major = db.Majors.FirstOrDefault(g => g.MajorName == "MIS");
                pm12.Position = p7;
                p7.PositionMajors.Add(pm12);

                PositionMajor pm13 = new PositionMajor();
                pm13.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Accounting");
                pm13.Position = p7;
                p7.PositionMajors.Add(pm13);

                PositionMajor pm14 = new PositionMajor();
                pm14.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Business Honors");
                pm14.Position = p7;
                p7.PositionMajors.Add(pm14);

                Position p8 = new Position()
				{
					Title = "Project Manager",
					PositionType = PositionDuration.FT,
					Location = "Chicago, Illinois",
					Deadline = new DateTime(2019, 6, 1),
					Description = ""
				};
				p8.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Aon");
				Positions.Add(p8);
                PositionMajor pm15 = new PositionMajor();
                pm15.Major = db.Majors.FirstOrDefault(g => g.MajorName == "MIS");
                pm15.Position = p8;
                p8.PositionMajors.Add(pm15);

                PositionMajor pm16 = new PositionMajor();
                pm16.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Supply Chain Management");
                pm16.Position = p8;
                p8.PositionMajors.Add(pm16);

                PositionMajor pm17 = new PositionMajor();
                pm17.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Accounting");
                pm17.Position = p8;
                p8.PositionMajors.Add(pm17);

                PositionMajor pm18 = new PositionMajor();
                pm18.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Marketing");
                pm18.Position = p8;
                p8.PositionMajors.Add(pm18);

                Position p9 = new Position()
				{
					Title = "Account Manager",
					PositionType = PositionDuration.FT,
					Location = "Dallas, Texas",
					Deadline = new DateTime(2019, 2, 28),
					Description = ""
				};
				p9.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Deloitte");
				Positions.Add(p9);
                PositionMajor pm19 = new PositionMajor();
                pm19.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Accounting");
                pm19.Position = p9;
                p9.PositionMajors.Add(pm19);

                PositionMajor pm20 = new PositionMajor();
                pm20.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Business Honors");
                pm20.Position = p9;
                p9.PositionMajors.Add(pm20);

                Position p10 = new Position()
				{
					Title = "Marketing Intern",
					PositionType = PositionDuration.I,
					Location = "Austin, Texas",
					Deadline = new DateTime(2019, 4, 30),
					Description = "Help our marketing team develop new advertising strategies for local Austin businesses"
				};
				p10.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Adlucent");
				Positions.Add(p10);
                PositionMajor pm21 = new PositionMajor();
                pm21.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Marketing");
                pm21.Position = p10;
                p10.PositionMajors.Add(pm21);

                Position p11 = new Position()
				{
					Title = "Financial Analyst",
					PositionType = PositionDuration.FT,
					Location = "Richmond, Virginia",
					Deadline = new DateTime(2019, 4, 15),
					Description = ""
				};
				p11.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Capital One");
				Positions.Add(p11);
                PositionMajor pm22 = new PositionMajor();
                pm22.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Finance");
                pm22.Position = p11;
                p11.PositionMajors.Add(pm22);

                Position p12 = new Position()
				{
					Title = "Pilot",
					PositionType = PositionDuration.FT,
					Location = "Ft. Worth, Texas",
					Deadline = new DateTime(2019, 10, 8),
					Description = ""
				};
				p12.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "United Airlines");
				Positions.Add(p12);
                PositionMajor pm23 = new PositionMajor();
                pm23.Major = db.Majors.FirstOrDefault(g => g.MajorName == "MIS");
                pm23.Position = p12;
                p12.PositionMajors.Add(pm23);

                PositionMajor pm24 = new PositionMajor();
                pm24.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Supply Chain Management");
                pm24.Position = p12;
                p12.PositionMajors.Add(pm24);

                PositionMajor pm25 = new PositionMajor();
                pm25.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Accounting");
                pm25.Position = p12;
                p12.PositionMajors.Add(pm25);

                PositionMajor pm26 = new PositionMajor();
                pm26.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Marketing");
                pm26.Position = p12;
                p12.PositionMajors.Add(pm26);

                Position p13 = new Position()
				{
					Title = "Corporate Recruiting Intern",
					PositionType = PositionDuration.I,
					Location = "Redmond, Washington",
					Deadline = new DateTime(2019, 4, 30),
					Description = ""
				};
				p13.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Microsoft");
				Positions.Add(p13);
                PositionMajor pm27 = new PositionMajor();
                pm27.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Management");
                pm27.Position = p13;
                p13.PositionMajors.Add(pm27);

                Position p14 = new Position()
				{
					Title = "Business Analyst",
					PositionType = PositionDuration.FT,
					Location = "Austin, Texas",
					Deadline = new DateTime(2019, 5, 31),
					Description = ""
				};
				p14.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Microsoft");
				Positions.Add(p14);
                PositionMajor pm28 = new PositionMajor();
                pm28.Major = db.Majors.FirstOrDefault(g => g.MajorName == "MIS");
                pm28.Position = p14;
                p14.PositionMajors.Add(pm28);

                Position p15 = new Position()
				{
					Title = "Programmer Analyst",
					PositionType = PositionDuration.FT,
					Location = "Minneapolis, Minnesota",
					Deadline = new DateTime(2019, 5, 15),
					Description = ""
				};
				p15.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Target");
				Positions.Add(p15);
                PositionMajor pm29 = new PositionMajor();
                pm29.Major = db.Majors.FirstOrDefault(g => g.MajorName == "MIS");
                pm29.Position = p15;
                p15.PositionMajors.Add(pm29);

                Position p16 = new Position()
				{
					Title = "Intern",
					PositionType = PositionDuration.I,
					Location = "Minneapolis, Minnesota",
					Deadline = new DateTime(2019, 5, 15),
					Description = ""
				};
				p16.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Target");
				Positions.Add(p16);
                PositionMajor pm30 = new PositionMajor();
                pm30.Major = db.Majors.FirstOrDefault(g => g.MajorName == "MIS");
                pm30.Position = p16;
                p16.PositionMajors.Add(pm30);

                PositionMajor pm31 = new PositionMajor();
                pm31.Major = db.Majors.FirstOrDefault(g => g.MajorName == "International Business");
                pm31.Position = p16;
                p16.PositionMajors.Add(pm31);

                PositionMajor pm32 = new PositionMajor();
                pm32.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Finance");
                pm32.Position = p16;
                p16.PositionMajors.Add(pm32);

                PositionMajor pm33 = new PositionMajor();
                pm33.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Accounting");
                pm33.Position = p16;
                p16.PositionMajors.Add(pm33);

                PositionMajor pm34 = new PositionMajor();
                pm34.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Marketing");
                pm34.Position = p16;
                p16.PositionMajors.Add(pm34);

                PositionMajor pm35 = new PositionMajor();
                pm35.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Science and Technology Management");
                pm35.Position = p16;
                p16.PositionMajors.Add(pm35);

                PositionMajor pm36 = new PositionMajor();
                pm36.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Business Honors");
                pm36.Position = p16;
                p16.PositionMajors.Add(pm36);

                PositionMajor pm37 = new PositionMajor();
                pm37.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Supply Chain Management");
                pm37.Position = p16;
                p16.PositionMajors.Add(pm37);

                PositionMajor pm38 = new PositionMajor();
                pm38.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Management");
                pm38.Position = p16;
                p16.PositionMajors.Add(pm38);

                Position p17 = new Position()
				{
					Title = "Digital Intern",
					PositionType = PositionDuration.I,
					Location = "Dallas, Texas",
					Deadline = new DateTime(2019, 5, 20),
					Description = ""
				};
				p17.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Accenture");
				Positions.Add(p17);
                PositionMajor pm39 = new PositionMajor();
                pm39.Major = db.Majors.FirstOrDefault(g => g.MajorName == "MIS");
                pm39.Position = p17;
                p17.PositionMajors.Add(pm39);

                PositionMajor pm40 = new PositionMajor();
                pm40.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Marketing");
                pm40.Position = p17;
                p17.PositionMajors.Add(pm40);


                Position p18 = new Position()
				{
					Title = "Analyst Development Program",
					PositionType = PositionDuration.I,
					Location = "Plano, Texas",
					Deadline = new DateTime(2019, 5, 20),
					Description = ""
				};
				p18.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Capital One");
				Positions.Add(p18);
                PositionMajor pm41 = new PositionMajor();
                pm41.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Finance");
                pm41.Position = p18;
                p18.PositionMajors.Add(pm41);

                PositionMajor pm42 = new PositionMajor();
                pm42.Major = db.Majors.FirstOrDefault(g => g.MajorName == "MIS");
                pm42.Position = p18;
                p18.PositionMajors.Add(pm42);

                PositionMajor pm43 = new PositionMajor();
                pm43.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Business Honors");
                pm43.Position = p18;
                p18.PositionMajors.Add(pm43);

                Position p19 = new Position()
				{
					Title = "Procurements Associate",
					PositionType = PositionDuration.FT,
					Location = "Houston,  Texas",
					Deadline = new DateTime(2019, 5, 30),
					Description = "Handle procurement and vendor accounts"
				};
				p19.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Shell");
				Positions.Add(p19);
                PositionMajor pm44 = new PositionMajor();
                pm44.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Supply Chain Management");
                pm44.Position = p19;
                p19.PositionMajors.Add(pm44);

                Position p20 = new Position()
				{
					Title = "IT Rotational Program",
					PositionType = PositionDuration.FT,
					Location = "Dallas, Texas",
					Deadline = new DateTime(2019, 5, 30),
					Description = ""
				};
				p20.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Texas Instruments");
				Positions.Add(p20);
                PositionMajor pm45 = new PositionMajor();
                pm45.Major = db.Majors.FirstOrDefault(g => g.MajorName == "MIS");
                pm45.Position = p20;
                p20.PositionMajors.Add(pm45);

                Position p21 = new Position()
				{
					Title = "Sales Rotational Program",
					PositionType = PositionDuration.FT,
					Location = "Dallas, Texas",
					Deadline = new DateTime(2019, 5, 30),
					Description = ""
				};
				p21.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Texas Instruments");
				Positions.Add(p21);
                PositionMajor pm46 = new PositionMajor();
                pm46.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Marketing");
                pm46.Position = p21;
                p21.PositionMajors.Add(pm46);

                PositionMajor pm47 = new PositionMajor();
                pm47.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Management");
                pm47.Position = p21;
                p21.PositionMajors.Add(pm47);

                PositionMajor pm48 = new PositionMajor();
                pm48.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Finance");
                pm48.Position = p21;
                p21.PositionMajors.Add(pm48);

                PositionMajor pm49 = new PositionMajor();
                pm49.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Accounting");
                pm49.Position = p21;
                p21.PositionMajors.Add(pm48);

                

                Position p22 = new Position()
				{
					Title = "Accounting Rotational Program",
					PositionType = PositionDuration.FT,
					Location = "Austin, Texas",
					Deadline = new DateTime(2019, 5, 30),
					Description = ""
				};
				p22.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Texas Instruments");
				Positions.Add(p22);
                PositionMajor pm50 = new PositionMajor();
                pm50.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Accounting");
                pm50.Position = p22;
                p22.PositionMajors.Add(pm50);

                Position p23 = new Position()
				{
					Title = "Financial Planning Intern",
					PositionType = PositionDuration.I,
					Location = "Orlando, Florida",
					Deadline = new DateTime(2019, 6, 1),
					Description = ""
				};
				p23.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Academy Sports & Outdoors");
				Positions.Add(p23);
                PositionMajor pm51 = new PositionMajor();
                pm51.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Finance");
                pm51.Position = p23;
                p23.PositionMajors.Add(pm51);

                PositionMajor pm52 = new PositionMajor();
                pm52.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Accounting");
                pm52.Position = p23;
                p23.PositionMajors.Add(pm52);

                PositionMajor pm53 = new PositionMajor();
                pm53.Major = db.Majors.FirstOrDefault(g => g.MajorName == "Business Honors");
                pm53.Position = p23;
                p23.PositionMajors.Add(pm53);

                Position p24 = new Position()
				{
					Title = "Digital Product Manager",
					PositionType = PositionDuration.FT,
					Location = "Houston, Texas",
					Deadline = new DateTime(2019, 6, 1),
					Description = ""
				};
				p24.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Academy Sports & Outdoors");
				Positions.Add(p24);

				Position p25 = new Position()
				{
					Title = "Product Marketing Intern",
					PositionType = PositionDuration.I,
					Location = "Redmond, Washington",
					Deadline = new DateTime(2019, 6, 1),
					Description = ""
				};
				p25.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Microsoft");
				Positions.Add(p25);

				Position p26 = new Position()
				{
					Title = "Program Manager",
					PositionType = PositionDuration.FT,
					Location = "Redmond, Washington",
					Deadline = new DateTime(2019, 6, 1),
					Description = ""
				};
				p26.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Microsoft");
				Positions.Add(p26);

				Position p27 = new Position()
				{
					Title = "Security Analyst",
					PositionType = PositionDuration.FT,
					Location = "Redmond, Washington",
					Deadline = new DateTime(2019, 6, 1),
					Description = ""
				};
				p27.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "Microsoft");
				Positions.Add(p27);

				Position p28 = new Position()
				{
					Title = "Big Data Analyst",
					PositionType = PositionDuration.FT,
					Location = "Dallas, Texas",
					Deadline = new DateTime(2019, 5, 9),
					Description = ""
				};
				p28.Company = db.Companies.FirstOrDefault(g => g.CompanyName == "United Airlines");
				Positions.Add(p28);

                try
                {
                    foreach (Position positionToAdd in Positions)
                    {
                        strPositionName = positionToAdd.Title;
                        Position dbPosition = db.Positions.FirstOrDefault(b => b.Title == positionToAdd.Title);
                        if (dbPosition == null) //this title doesn't exist
                        {
                            db.Positions.Add(positionToAdd);
                            db.SaveChanges();
                            intPositionsAdded += 1;
                        }
                        else //position exists - update values
                        {
                            dbPosition.Title = positionToAdd.Title;
                            dbPosition.PositionType = positionToAdd.PositionType;
                            dbPosition.Location = positionToAdd.Location;
                            dbPosition.Deadline = positionToAdd.Deadline;
                            dbPosition.Description = positionToAdd.Description;
                            dbPosition.Company = positionToAdd.Company;
                            db.Update(dbPosition);
                            db.SaveChanges();
                            intPositionsAdded += 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    String msg = "  Repositories added:" + intPositionsAdded + "; Error on " + strPositionName;
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