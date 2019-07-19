using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampplaceTest1.Models
{
    public class CampCommentsVM
    {
        public Camp Camp { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
