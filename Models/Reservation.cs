using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampplaceTest1.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public Camp Camp { get; set; }
        [Display(Name ="Miejsce Obozowe")]
        public int CampId { get; set; }
        [Display(Name ="Początek Obozu")]
        public DateTime Start { get; set; }
        [Display(Name = "Koniec Obozu")]
        public DateTime End { get; set; }
        [Display(Name = "Jednostka")]
        public string Unit { get; set; }
        public string UserId { get; set; }
        [Display(Name = "Osoba rezerwująca")]
        public string UserName { get; set; }
        public Status Status { get; set; }

    }
    public enum Status
    {
        Planowane,
        Zarezerwowane,
    }
}

