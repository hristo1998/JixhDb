namespace JixhDb.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<JixhDb.Data.JixhDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(JixhDb.Data.JixhDbContext context)
        {
            if (!context.Roles.Any(role => role.Name == "Member"))
            {
                var store =  new RoleStore<IdentityRole>(context);
                var manager =  new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Member");
                manager.Create(role);
            }

            if (!context.Roles.Any(role => role.Name == "Reviewer"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Reviewer");
                manager.Create(role);
            }

            if (!context.Roles.Any(role => role.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Admin");
                manager.Create(role);
            }

        }
    }
}
