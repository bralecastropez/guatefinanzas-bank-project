namespace Project_GuateFinanzas.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Project_GuateFinanzas.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Project_GuateFinanzas.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Project_GuateFinanzas.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            if (!context.Users.Any(u => u.UserName == "admin@guatefinanzas.com.gt"))
            {
            //    var UStore = new UserStore<ApplicationUser>(context);
            //    var UManager = new UserManager<ApplicationUser>(UStore);

                var RStore = new RoleStore<IdentityRole>(context);
                var RManager = new RoleManager<IdentityRole>(RStore);

            //    var NewUser = new ApplicationUser() { UserName = "admin@guatefinanzas.com.gt" };

                var NewRoleAdmin = new IdentityRole { Name = "Admin" };
                var NewRoleCustomer = new IdentityRole { Name = "Customer" };


                RManager.Create(NewRoleAdmin);
                RManager.Create(NewRoleCustomer);
                
            //    UManager.Create(NewUser, "4dmin$");

            //    UManager.AddToRole(NewUser.Id, "Admin");

            //    context.Persons.AddOrUpdate(c => c.ID,
            //        new Person() { ID = 3473875940101, Name = "Bryam", SurName = "Paniagua", Email = "bpaniagua@guatefinanzas.com.gt", Address = "zone 7", PhoneNumber = "54526031"},
            //        new Person() { ID = 4512526980101, Name = "Lucky", SurName = "Seven", Email = "lseven@guatefinanzas.com.gt", Address = "zone 16", PhoneNumber = "51058031" });

            //    context.BankAccounts.AddOrUpdate(cuenta => cuenta.ID,
            //        new BankAccount() { ID = 1201862596, Name = "ct. Bryam", Type = Enumeration.AccountType.Monetary, State = Enumeration.State.Active, Balance = 1000.0 },
            //        new BankAccount() { ID = 1250226, Name = "ct. Lucky7", Type = Enumeration.AccountType.Saving, State = Enumeration.State.Inactive, Balance = 3000.0 });

            //    context.DebitCards.AddOrUpdate(dt => dt.ID,
            //        new DebitCard() { ID = 1023623596124525, BankAccountID = 120125862596, ActivationDate = DateTime.Today, State = Enumeration.State.Active, Pin = "2356" },
            //        new DebitCard() { ID = 1250253625845632, BankAccountID = 1250226, ActivationDate = DateTime.Today, State = Enumeration.State.Inactive, Pin = "36526" });

            //    context.CreditCards.AddOrUpdate(ct => ct.ID,
            //        new CreditCard() { ID = 4111111111111111, PersonID = 4512526980101, Type = Enumeration.CreditCardType.MasterCard, CreditLimit = 5000, ActivationDate = DateTime.Today, State = Enumeration.State.Active, Rate = 20, Pin = "98562" });
            }
        }
    }
}
