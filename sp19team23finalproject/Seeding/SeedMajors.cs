using sp19team23finalproject.Models;
using sp19team23finalproject.DAL;
using System.Collections.Generic;
using System;
using System.Linq;

namespace sp19team23finalproject.Seeding
{
	public static class SeedMajors
	{
		public static void SeedAllMajors(AppDbContext db)
		{
			if (db.Majors.Count() == 15)
			{
				throw new NotSupportedException("The database already contains all 15 Majors!");
			}

			Int32 intMajorsAdded = 0;
			String strMajorTitle = "Begin"; //helps to keep track of error on books
			List<Major> Majors = new List<Major>();

			try
			{
				Major b1 = new Major()
				{
					MajorName = "Supply Chain Management"
				};
				Majors.Add(b1);

				Major b2 = new Major()
				{
					MajorName = "Accounting"
				};
				Majors.Add(b2);

				Major b3 = new Major()
				{
					MajorName = "MIS"
				};
				Majors.Add(b3);

				Major b5 = new Major()
				{
					MajorName = "Finance"
				};
				Majors.Add(b5);

				Major b6 = new Major()
				{
					MajorName = "Marketing"
				};
				Majors.Add(b6);

				Major b7 = new Major()
				{
					MajorName = "Management"
				};
				Majors.Add(b7);

				Major b8 = new Major()
				{
					MajorName = "All Majors"
				};
				Majors.Add(b8);

				Major b9 = new Major()
				{
					MajorName = "Business Honors"
				};
				Majors.Add(b9);

				Major b10 = new Major()
				{
					MajorName = "International Business"
				};
				Majors.Add(b10);

                Major b11 = new Major()
                {
                    MajorName = "Science and Technology Management"
                };
                Majors.Add(b11);

                try
				{
					foreach (Major majorToAdd in Majors)
					{
						strMajorTitle = majorToAdd.MajorName;
						Major dbMajor = db.Majors.FirstOrDefault(b => b.MajorName == majorToAdd.MajorName);
						if (dbMajor == null) //this title doesn't exist
						{
							db.Majors.Add(majorToAdd);
							db.SaveChanges();
							intMajorsAdded += 1;
						}
						else //Major exists - update values
						{
							dbMajor.MajorName = majorToAdd.MajorName;
							db.Update(dbMajor);
							db.SaveChanges();
							intMajorsAdded += 1;
						}
					}
				}
				catch (Exception ex)
				{
					String msg = "  Repositories added:" + intMajorsAdded + "; Error on " + strMajorTitle;
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
