using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampplaceTest1.Models
{
    public class UserEdit
    {
        public ApplicationUser User { get; set; }
        public IEnumerable<IdentityRole> UserRoles { get; set; }
        public IEnumerable<IdentityRole> UserNonRoles { get; set; }
    }
}
