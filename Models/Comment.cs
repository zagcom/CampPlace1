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
        [Display(Name = "Obóz")]
        public int CampId { get; set; }
        [Display(Name = "Obóz")]
        public Camp Camp { get; set; }
        [Display (Name ="Treść Komentarza")]
        public string Content { get; set; }
        [Display(Name = "Autor")]
        public string UserName { get; set; }
        public string UserId { get; set; }
        [Display(Name = "Data publikacji")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy, hh:mm}")]
        public DateTime Added { get; set; }
    }
}
