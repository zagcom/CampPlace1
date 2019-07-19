using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampplaceTest1.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int CampId { get; set; }
        public Camp Camp { get; set; }
        [Display (Name ="Treść Komentarza")]
        public string Content { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public DateTime Added { get; set; }
    }
}
