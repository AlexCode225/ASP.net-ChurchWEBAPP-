using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Stock_system.Models;

namespace Stock_system.Data
{
    //identityDbcontext   /  Dbcontext
    public class ApplicationDbContext  :IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
         
        }
       
      
      
        public DbSet<AuthUser> AuthUsers { get; set;}




        //==========for the ngo=================
        //for the events
         public DbSet<attendance> Attendances { get; set; }

        //for the events
         public DbSet<events> Events { get; set; }

        //for the prayerwall
        public DbSet<Prayerwall> Prayerwalls { get; set; }

        //for the volunteer
        public DbSet<Stock_system.Models.Volunteer>? Volunteer { get; set; }


    }
}
