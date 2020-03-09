using sp19team23finalproject.Models;
using sp19team23finalproject.DAL;
using System.Collections.Generic;
using System;
using System.Linq;

namespace sp19team23finalproject.Seeding
{
	public static class SeedCompanies
	{
		public static void SeedAllCompanies(AppDbContext db)
		{
			if (db.Companies.Count() == 13)
			{
				throw new NotSupportedException("The database already contains all 13 companies!");
			}

			Int32 intCompaniesAdded = 0;
			String strCompanyName = "Begin"; //helps to keep track of error on companies
			List<Company> Companies = new List<Company>();

			try
			{
				Company b1 = new Company()
				{
					CompanyName = "Accenture",
					Email = "accenture@example.com",
					CompanyDescription = "Accenture is a global management consulting, technology services and outsourcing company.",
					Industry = "Consulting, Technology"
				};
				Companies.Add(b1);

				Company b2 = new Company()
				{
					CompanyName = "Shell",
					Email = "shell@example.com",
					CompanyDescription = "Shell Oil Company, including its consolidated companies and its share in equity companies, is one of America's leading oild and natural gas producers, natural gas marketers, gasoline marketers and petrochemical manufacturers.",
					Industry = "Energy, Chemicals"
				};
				Companies.Add(b2);

				Company b3 = new Company()
				{
					CompanyName = "Deloitte",
					Email = "deloitte@example.com",
					CompanyDescription = "Deloitte is one of the leading professional services organizations in the United States specializing in audit, tax, consulting, and financial advisory services with clients in more than 20 industries.",
					Industry = "Accounting, Consulting, Technology"
				};
				Companies.Add(b3);

				Company b4 = new Company()
				{
					CompanyName = "Capital One",
					Email = "capitalone@example.com",
					CompanyDescription = "Capital One offers a broad spectrum of financial products and services to consumers, small businesses and commercial clients.",
					Industry = "Financial Services"
				};
				Companies.Add(b4);

				Company b5 = new Company()
				{
					CompanyName = "Texas Instruments",
					Email = "texasinstruments@example.com",
					CompanyDescription = "TI is one of the world’s largest global leaders in analog and digital semiconductor design and manufacturing",
					Industry = "Manufacturing"
				};
				Companies.Add(b5);

				Company b6 = new Company()
				{
					CompanyName = "Hilton Worldwide",
					Email = "hiltonworldwide@example.com",
					CompanyDescription = "Hilton Worldwide offers business and leisure travelers the finest in accommodations, service, amenities and value.",
					Industry = "Hospitality"
				};
				Companies.Add(b6);

				Company b7 = new Company()
				{
					CompanyName = "Aon",
					Email = "aon@example.com",
					CompanyDescription = "Aon is the leading global provider of risk management, insurance and reinsurance brokerage, and human resources solutions and outsourcing services.",
					Industry = "Insurance, Consulting"
				};
				Companies.Add(b7);

				Company b8 = new Company()
				{
					CompanyName = "Adlucent",
					Email = "adlucent@example.com",
					CompanyDescription = "Adlucent is a technology and analytics company specializing in selling products through the Internet for online retail clients.",
					Industry = "Marketing, Technology"
				};
				Companies.Add(b8);

				Company b9 = new Company()
				{
					CompanyName = "Stream Realty Partners",
					Email = "streamrealtypartners@example.com",
					CompanyDescription = "Stream Realty Partners, L.P. (Stream) is a national, commercial real estate firm with locations across the country.",
					Industry = "Real-Estate"
				};
				Companies.Add(b9);

				Company b10 = new Company()
				{
					CompanyName = "Microsoft",
					Email = "microsoft@example.com",
					CompanyDescription = "Microsoft is the worldwide leader in software, services and solutions that help people and businesses realize their full potential.",
					Industry = "Technology"
				};
				Companies.Add(b10);

				Company b11 = new Company()
				{
					CompanyName = "Academy Sports & Outdoors",
					Email = "academysports@example.com",
					CompanyDescription = "Academy Sports is intensely focused on being a leader in the sporting goods, outdoor and lifestyle retail arena",
					Industry = "Retail"
				};
				Companies.Add(b11);

				Company b12 = new Company()
				{
					CompanyName = "United Airlines",
					Email = "unitedairlines@example.com",
					CompanyDescription = "United Airlines has the most modern and fuel-efficient fleet (when adjusted for cabin size), and the best new aircraft order book, among U.S. network carriers",
					Industry = "Transportation"
				};
				Companies.Add(b12);

				Company b13 = new Company()
				{
					CompanyName = "Target",
					Email = "target@example.com",
					CompanyDescription = "Target is a leading retailer",
					Industry = "Retail"
				};
				Companies.Add(b13);

				try
				{
					foreach (Company companyToAdd in Companies)
					{
						strCompanyName = companyToAdd.CompanyName;
						Company dbCompany = db.Companies.FirstOrDefault(b => b.CompanyName == companyToAdd.CompanyName);
						if (dbCompany == null) //this CompanyName doesn't exist
						{
							db.Companies.Add(companyToAdd);
							db.SaveChanges();
							intCompaniesAdded += 1;
						}
						else //Company exists - update values
						{
							dbCompany.CompanyName = companyToAdd.CompanyName;
							dbCompany.Email = companyToAdd.Email;
							dbCompany.CompanyDescription = companyToAdd.CompanyDescription;
							dbCompany.Industry = companyToAdd.Industry;
							db.Update(dbCompany);
							db.SaveChanges();
							intCompaniesAdded += 1;
						}
					}
				}
				catch (Exception ex)
				{
					String msg = "  Repositories added:" + intCompaniesAdded + "; Error on " + strCompanyName;
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
