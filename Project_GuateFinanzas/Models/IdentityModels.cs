using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;

using Microsoft.AspNet.Identity.EntityFramework;

namespace Project_GuateFinanzas.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public Int64? PersonID { get; set; }
        public Person Person { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<Person> Persons { get; set; }
        public System.Data.Entity.DbSet<BankAccount> BankAccounts { get; set; }
        public System.Data.Entity.DbSet<AccountMovement> AccountMovements { get; set; }
        public System.Data.Entity.DbSet<DebitCard> DebitCards { get; set; }
        public System.Data.Entity.DbSet<CreditCard> CreditCards { get; set; }
        public System.Data.Entity.DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<Person>()
            //    .HasMany(p => p.BankAccounts).WithRequired(per => per.Person);
                //.HasMany(p => p.BankAccount).WithMany(i => i.Courses)
            //    .Map(t => t.MapLeftKey("CourseID")
            //        .MapRightKey("InstructorID")
            //        .ToTable("CourseInstructor"));


            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(log => log.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(rl => rl.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(ur => new { ur.RoleId, ur.UserId });
        }
    }
}