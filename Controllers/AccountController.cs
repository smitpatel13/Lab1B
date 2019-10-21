// I, Smitkumar Patel, 000737859 certify that this material is my
// original work. No other person's work has been used without due
// acknowledgement and I have not made my work available to anyone else.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab_1B.Data;
using Lab_1B.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lab_1B.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> RoleManager)
        {
            _userManager = userManager;
            _roleManager = RoleManager;
        }
        public async Task<IActionResult> SeedRoles()
        {
            ApplicationUser user1 = new ApplicationUser { Email = "spiderman@gmail.com", UserName = "spiderman@gmail.com", FirstName = "Peter", LastName = "Parker", BirthDate = "1992-04-13", Company = "TonyStark", Position = "LifeSaver" };
            ApplicationUser user2 = new ApplicationUser { Email = "drstrange@gmail.com", UserName = "drstrange@gmail.com", FirstName = "Doctor", LastName = "Strange", BirthDate = "1991-04-18", Company = "Avengers", Position = "Doctor" };

            IdentityResult result = await _userManager.CreateAsync(user1, "Mohawk1!");
            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to add new user" });

            result = await _userManager.CreateAsync(user2, "Mohawk1!");
            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to add new user" });

            result = await _roleManager.CreateAsync(new IdentityRole("Employee"));
            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to add new role" });

            result = await _roleManager.CreateAsync(new IdentityRole("Supervisor"));
            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to add new role" });


            result = await _userManager.AddToRoleAsync(user1, "Employee");
            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to assign new role" });

            result = await _userManager.AddToRoleAsync(user2, "Supervisor");
            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to assign new role" });


            return RedirectToAction("Index", "Home");
        }
    }
}