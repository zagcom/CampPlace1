using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampplaceTest1.Models
{
    public class Camp
    {
        public int Id { get; set; }
        public Voivodeship Voivodeship { get; set; }
        public string Community { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Coordinates { get; set; }
        public string Address { get; set; }
        public bool SummerCamp { get; set; }
        public bool WinterCamp { get; set; }
        public bool Bivouac { get; set; }
        public bool Scouts { get; set; }
        public bool WolfCubs { get; set; }
        public bool Buildings { get; set; }
        public bool Toilet { get; set; }
        public bool Kitchen { get; set; }
        public bool SleepingInside { get; set; }
        public int MaxPeopleCapacity { get; set; }
        public string ImagePath { get; set; }
        public string DistanceFromBuildings { get; set; }
        public string NearestHospital { get; set; }
        public string NearestFireDepartment { get; set; }
        public string NearestPoliceStation { get; set; }
        public string NearestMarket { get; set; }
        public string ContactPoint { get; set; }
        public string EmailToCP { get; set; }
        public string PhoneToCP { get; set; }
        public DateTime LastEdited { get; set; }
        public string EditorId { get; set; }
        public string OwnerId { get; set; }


        
    }
    public enum Voivodeship
    {
        dolnośląskie,
        [Display(Name = "kujawsko-pomorskie")]
        kujawskoPomorskie,
        lubelskie,
        lubuskie,
        łódzkie,
        małopolskie,
        mazowieckie,
        opolskie,
        podkarpackie,
        podlaskie,
        pomorskie,
        śląskie,
        świętokrzyskie,
        [Display(Name = "warmińsko-mazurskie")]
        warmińskoMazurskie,
        wielkopolskie,
        zachodniopomorskie
    }

}
