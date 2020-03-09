using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using sp19team23finalproject.Models;


namespace sp19team23finalproject.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Application> Applications { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PositionMajor> PositionMajors { get; set; }
        public DbSet<PositionApplication> PositionApplications { get; set; }
        //TODO: Add your DbSets here.  You will need one for each model you want to store in the database
        //IMPORTANT: Do NOT add DbSets for your ViewModel classes - they are not stored in your database

        //Also, remember that Identity will add a DbSet for your User class.  It will be called Users.  
        //If you add another DbSet for users, you WILL get an error

    }
}
