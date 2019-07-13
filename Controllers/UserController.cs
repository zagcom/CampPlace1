using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampplaceTest1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CampplaceTest1.Controllers
{
    [Authorize(Roles = "MasterUser")]
    public class UserController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<ApplicationUser> userManager;
        private IPasswordHasher<ApplicationUser> passwordHasher;
        public UserController(UserManager<ApplicationUser> userMrg, RoleManager<IdentityRole> roleMgr, IPasswordHasher<ApplicationUser> passwordHash)
        {
            roleManager = roleMgr;
            userManager = userMrg;
            passwordHasher = passwordHash;
        }

        public ViewResult Index() => View(userManager.Users);

        public async Task<IActionResult> Update(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            List<IdentityRole> members = new List<IdentityRole>();
            List<IdentityRole> nonMembers = new List<IdentityRole>();
            foreach (IdentityRole role in roleManager.Roles)
            {
                var list = await userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(role);
            }
            return View(new UserEdit
            {
                User = user,
                UserRoles = members,
                UserNonRoles = nonMembers
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserModification model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (string roleName in model.RoleAdds ?? new string[] { })
                {
                    ApplicationUser user = await userManager.FindByIdAsync(model.UserId);
                    if (user != null)
                    {
                        result = await userManager.AddToRoleAsync(user, roleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
                foreach (string roleName in model.RoleDels ?? new string[] { })
                {
                    ApplicationUser user = await userManager.FindByIdAsync(model.UserId);
                    if (user != null)
                    {
                        result = await userManager.RemoveFromRoleAsync(user, roleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
            }



            if (ModelState.IsValid)
                return RedirectToAction(nameof(Index));
            else
                return await Update(model.UserId);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "No user found");
            return View("Index", userManager.Users);
        }

        public async Task<IActionResult> Details(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if (user != null)
                return View(user);
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Details(string id, string email, string firstname, string lastname, string unit, string function, string city)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                //if (email!=user.Email)
                //    user.Email = email;
                //else
                //    ModelState.AddModelError("email", "Email cannot be empty");
                 
                if (!string.IsNullOrEmpty(email))
                    user.Email = email;
                else
                    ModelState.AddModelError("email", "Email is required");

                if (!string.IsNullOrEmpty(firstname))
                    user.FirstName = firstname;
                else
                    ModelState.AddModelError("firstname", "First Name is required");

                if (!string.IsNullOrEmpty(lastname))
                    user.LastName = lastname;
                else
                    ModelState.AddModelError("lastname", "Last Name is required");

                if (!string.IsNullOrEmpty(unit))
                    user.Unit = unit;
                else
                    ModelState.AddModelError("unit", "Unit is required");

                if (!string.IsNullOrEmpty(function))
                    user.Function = function;
                else
                    ModelState.AddModelError("function", "Function is required");

                if (!string.IsNullOrEmpty(city))
                    user.City = city;
                else
                    ModelState.AddModelError("city", "City is required");

                if (!string.IsNullOrEmpty(email))
                {
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                        return RedirectToAction("Index");
                    else
                        Errors(result);
                }
                
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View(user);
        }

        public async Task<IActionResult> ChangePassword(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if (user != null)
                return View(user);
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(string id, string email, string password)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                if (!string.IsNullOrEmpty(email))
                    user.Email = email;
                else
                    ModelState.AddModelError("", "Email is required");

                if (!string.IsNullOrEmpty(password))
                    user.PasswordHash = passwordHasher.HashPassword(user, password);
                else
                    ModelState.AddModelError("", "Password is required");

                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                        return RedirectToAction("Index");
                    else
                        Errors(result);
                }
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View(user);
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
    }
}