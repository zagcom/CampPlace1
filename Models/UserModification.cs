using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampplaceTest1.Models
{
    public class UserModification
    {
        [Required]
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string[] RoleAdds { get; set; }
        public string[] RoleDels { get; set; }
    }
}
