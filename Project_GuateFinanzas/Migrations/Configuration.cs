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
                var UStore = new UserStore<ApplicationUser>(context);
                var UManager = new UserManager<ApplicationUser>(UStore);

                var RStore = new RoleStore<IdentityRole>(context);
                var RManager = new RoleManager<IdentityRole>(RStore);

                var NewUser = new ApplicationUser() { UserName = "admin@guatefinanzas.com.gt" };

                var NewRoleAdmin = new IdentityRole { Name = "Admin" };
                var NewRoleCustomer = new IdentityRole { Name = "Customer" };


                RManager.Create(NewRoleAdmin);
                RManager.Create(NewRoleCustomer);

                //UManager.Create(NewUser, "4dmin$");

                //UManager.AddToRole(NewUser.Id, "Admin");

                //context.Persona.AddOrUpdate(c => c.ID,
                //    new Person() { Nombre = "anonimo", Apellido = "null", Correo = "a@guatefinanzas.com.gt", Direccion = "desconocida" });

                //context.Cuentas.AddOrUpdate(cuenta => cuenta.ID,
                //    new Cuenta() { Nombre = "desconocido", EstadoID = 1, Saldo = 0, ClienteID = 1, TipoID = 1 });

                //context.DebitoTarjetas.AddOrUpdate(dt => dt.ID,
                //    new DebitoTarjeta() { CuentaID = 1, Pin = 0000, EstadoID = 1, FechaActivacion = DateTime.Today, FechaVencimiento = DateTime.Today });

                //context.CreditoTarjetas.AddOrUpdate(ct => ct.ID,
                //    new CreditoTarjeta() { ClienteID = 1, EstadoID = 1, Limite = 0, Pin = 0000, Tasa = 0, FechaVencimiento = DateTime.Today, FechaActivacion = DateTime.Today });
            }
        }
    }
}
