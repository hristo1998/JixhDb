namespace JixhDb.Web.Infrastructure.Extensions
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;    
    using static JixhDb.Common.GlobalConstants;
    using JixhDb.Data;
    using JixhDb.Models.EntityModels;

    public static class ApplicationBuilderExtentions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<JixhDbContext>().Database.Migrate();

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task.Run(async () =>
                {
                    //  Checks if administrator role exists. If not, creats one.
                    var adminRoleExists = await roleManager.RoleExistsAsync(AdministratorRoleName);

                    if (!adminRoleExists)
                    {
                        var result = await roleManager.CreateAsync(new IdentityRole
                        {
                            Name = AdministratorRoleName
                        });
                    }

                    // Checks if default admin account exists. If not, creates one.
                    var adminEmail = "admin@mysite.com";
                    var adminPassword = "admin12";
                    var adminUser = await userManager.FindByNameAsync(adminEmail);

                    if (adminUser == null)
                    {
                        adminUser = new User
                        {
                            Email = adminEmail,
                            UserName = adminEmail
                        };

                        await userManager.CreateAsync(adminUser, adminPassword);

                        await userManager.AddToRoleAsync(adminUser, AdministratorRoleName);
                    }

                    //Checks if moderator role exists. If not, creates one.
                    var moderatorRoleExists = await roleManager.RoleExistsAsync(ModeratorRoleName);

                    if (!moderatorRoleExists)
                    {
                        var result = await roleManager.CreateAsync(new IdentityRole
                        {
                            Name = ModeratorRoleName
                        });
                    }

                    //Checks if default moderator account exists. if not, creats one.
                    var moderatorEmail = "moderator@mysite.com";
                    var moderatorPassword = "moderator12";
                    var moderatorUser = await userManager.FindByEmailAsync(moderatorEmail);

                    if (moderatorUser == null)
                    {
                        moderatorUser = new User
                        {
                            Email = moderatorEmail,
                            UserName = moderatorEmail
                        };

                        await userManager.CreateAsync(moderatorUser, moderatorPassword);
                        await userManager.AddToRoleAsync(moderatorUser, ModeratorRoleName);
                    }

                    //Checks if movie moderator role exists. If not, creates one.
                    var movieModeratorRoleExists = await roleManager.RoleExistsAsync(MovieModeratorRoleName);

                    if (!movieModeratorRoleExists)
                    {
                        var result = await roleManager.CreateAsync(new IdentityRole
                        {
                            Name = MovieModeratorRoleName
                        });
                    }

                    //Checks if default movie moderator account exists. if not, creats one.
                    var movieModeratorEmail = "movie_moderator@mysite.com";
                    var movieModeratorPassword = "moviemoderator12";
                    var movieModeratorUser = await userManager.FindByEmailAsync(movieModeratorEmail);

                    if (movieModeratorUser == null)
                    {
                        movieModeratorUser = new User
                        {
                            Email = movieModeratorEmail,
                            UserName = movieModeratorEmail
                        };

                        await userManager.CreateAsync(movieModeratorUser, movieModeratorPassword);
                        await userManager.AddToRoleAsync(movieModeratorUser, MovieModeratorRoleName);
                    }

                    // Checks if the default power admin exists. If not, creates one.
                    var powerAdminEmail = "power_admin@mysite.com";
                    var powerAdminPassword = "poweradmin12";
                    var powerAdminUser = await userManager.FindByEmailAsync(powerAdminEmail);

                    if (powerAdminUser == null)
                    {
                        powerAdminUser = new User
                        {
                            Email = powerAdminEmail,
                            UserName = "POWEEER"
                        };

                        await userManager.CreateAsync(powerAdminUser, powerAdminPassword);
                        await userManager.AddToRolesAsync(powerAdminUser, new List<string>() { AdministratorRoleName, ModeratorRoleName, MovieModeratorRoleName } );
                    }


                })
                    .Wait();
            }

            return app;
        }
    }
}
