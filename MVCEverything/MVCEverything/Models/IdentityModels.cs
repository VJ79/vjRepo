using Microsoft.AspNet.Identity.EntityFramework;
using MVCEverything.Areas.StudentManagement.Models;
using MVCEverything.Models;
using System.Data.Entity.Migrations;

namespace MVCEverything.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("MVCEverything")
        {
           // this.Database.Initialize(false);               
        }

        public System.Data.Entity.DbSet<MVCEverything.Models.Student> Students { get; set; }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student1>().ToTable("StudentToTable");
        }
    }
}

