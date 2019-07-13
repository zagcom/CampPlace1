using CampplaceTest1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampplaceTest1.TagHelpers
{
    [HtmlTargetElement("td", Attributes = "i-user")]
    public class UserRoleTH : TagHelper
    {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        public UserRoleTH(UserManager<ApplicationUser> usermgr, RoleManager<IdentityRole> rolemgr)
        {
            userManager = usermgr;
            roleManager = rolemgr;
        }

        [HtmlAttributeName("i-user")]
        public string User { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            List<string> names = new List<string>();
            ApplicationUser user = await userManager.FindByIdAsync(User);
            if (user != null)
            {
                foreach (var role in roleManager.Roles)
                {
                    if (role != null && await userManager.IsInRoleAsync(user, role.Name))
                        names.Add(role.Name);
                }
            }
            output.Content.SetContent(names.Count == 0 ? "No Roles" : string.Join(" | ", names));


        }
    }
}
