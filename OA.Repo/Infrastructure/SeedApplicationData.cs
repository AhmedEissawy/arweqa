using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OA.Data;
using OA.Data.Domain;
using OA.Repo.Enums;
using System;
using System.Threading.Tasks;

namespace OA.Repo.Infrastructure
{
    public class Seed
    {
        public static async Task SeedApplicationData(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager) 
        {
            try
            {
                await SeedRoles(roleManager);
                await SeedUsers(userManager);
            }
            catch (Exception ex)
            {

                throw new Exception("Error While Seeding Data!", ex);
            }
        }


        private async static Task SeedRoles(RoleManager<ApplicationRole> roleManager) 
        {
            if (!await roleManager.RoleExistsAsync(ApplicationConstatns.StudentsRole))
                await roleManager.CreateAsync(new ApplicationRole { Name = ApplicationConstatns.StudentsRole });

            if (!await roleManager.RoleExistsAsync(ApplicationConstatns.ReportsRole))
                await roleManager.CreateAsync(new ApplicationRole { Name = ApplicationConstatns.ReportsRole });
           
            if (!await roleManager.RoleExistsAsync(ApplicationConstatns.TeachersRole))
                await roleManager.CreateAsync(new ApplicationRole { Name = ApplicationConstatns.TeachersRole });

            if (!await roleManager.RoleExistsAsync(ApplicationConstatns.TechnicalSupportRole))
                await roleManager.CreateAsync(new ApplicationRole { Name = ApplicationConstatns.TechnicalSupportRole });

            if (!await roleManager.RoleExistsAsync(ApplicationConstatns.LibraryRole))
                await roleManager.CreateAsync(new ApplicationRole { Name = ApplicationConstatns.LibraryRole });

            if (!await roleManager.RoleExistsAsync(ApplicationConstatns.SubjectsRole))
                await roleManager.CreateAsync(new ApplicationRole { Name = ApplicationConstatns.SubjectsRole });

            if (!await roleManager.RoleExistsAsync(ApplicationConstatns.SuperAdminRole))
                await roleManager.CreateAsync(new ApplicationRole { Name = ApplicationConstatns.SuperAdminRole });
        }


        async static Task  SeedUsers(UserManager<ApplicationUser> userManager)
        {

            var userId = Guid.Parse(ApplicationConstatns.SuperAdminUserId);
            if (!await userManager.Users.AnyAsync(a => a.Id==userId))
            {
                var newUser = new ApplicationUser
                {
                    Id = Guid.Parse(ApplicationConstatns.SuperAdminUserId),
                    IsActive = true,
                    Email = "programmer@programmer.com",
                    NormalizedEmail = "PROGRAMMER@PROGRAMMER.COM",
                    UserFullName = "Super Admin",
                    EmailConfirmed = true,
                    PhoneNumber = string.Empty,
                    UserName = "Programmer",
                    UserType=UserType.SuperAdmin.ToString()
                };

              

                var result = await userManager.CreateAsync(newUser,"P00000");

               await userManager.AddToRoleAsync(newUser, ApplicationConstatns.SuperAdminRole);
               await userManager.AddToRoleAsync(newUser, ApplicationConstatns.LibraryRole);
               await userManager.AddToRoleAsync(newUser, ApplicationConstatns.StudentsRole);
               await userManager.AddToRoleAsync(newUser, ApplicationConstatns.SubjectsRole);
               await userManager.AddToRoleAsync(newUser, ApplicationConstatns.TechnicalSupportRole);
               await userManager.AddToRoleAsync(newUser, ApplicationConstatns.TeachersRole);
               await userManager.AddToRoleAsync(newUser, ApplicationConstatns.ReportsRole);

            }
           
        }

    }
}
