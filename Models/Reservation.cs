using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampplaceTest1.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public Camp Camp { get; set; }
        public int CampId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Unit { get; set; }
        public string UserName { get; set; }
        public Status Status { get; set; }

    }
    public enum Status
    {
        Planowane,
        Zarezerwowane,
    }
}

