using Microsoft.AspNetCore.Identity;
using NYHApp.Data;
using NYHApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NYHApp.Migrations
{
    public class dbInitializer
    {

        //This example just creates an Administrator role and one Admin users
        public static async Task Initialize(ApplicationDbContext db, UserManager<ApplicationUser> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            //Create database if not exists
            db.Database.EnsureCreated();
            if (!db.Roles.Any(r => r.Name == "Administrator"))
            {

                //Create the Administartor Role
                await _roleManager.CreateAsync(new IdentityRole("Administrator"));

                //Create the default Admin account and apply the Administrator role
                ApplicationUser Administrator = new ApplicationUser()
                {
                    UserName = "Administrador",
                    Email = "jld0016@alu.ubu.es",
                    Address = "Administrador",
                    City = "Burgos",
                    IdCountry = 1,
                    Door = "1",
                    Floor = "1",
                    State = "Castilla y León",
                    IdTypeRoad = 1,
                    Name = "Jorge",
                    NIF = "12345678Q",
                    Number = "1",
                    Phone1 = "123456789",
                    Phone2 = "123456789",
                    PostalCode = "09000",
                    Surname1 = "Laguna",
                    Surname2 = "Delgado",
                    DateLastModified = DateTime.Now
                };
                await _userManager.CreateAsync(Administrator, "Abc123*");
                await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync("Administrador"), "Administrator");
            }

            //If there is already an Enterprise role, abort
            if (!db.Roles.Any(r => r.Name == "Enterprise"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Enterprise"));
            }
            //If there is already an User role, abort
            if (!db.Roles.Any(r => r.Name == "User"))
            {
                await _roleManager.CreateAsync(new IdentityRole("User"));
            }
        }
    }
}
