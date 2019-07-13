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
        public UserController(UserManager<ApplicationUser> userMrg, RoleManager<IdentityRole> roleMgr)
        {
            roleManager = roleMgr;
            userManager = userMrg;
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

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
    }
}