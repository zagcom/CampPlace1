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
        [Display(Name ="Województwo")]
        public Voivodeship Voivodeship { get; set; }
        [Display(Name = "Urząd Gminy")]
        public string Community { get; set; }
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Display(Name = "Współrzędne")]
        public string Coordinates { get; set; }
        [Display(Name = "Adres")]
        public string Address { get; set; }
        [Display(Name = "Obóz Letni")]
        public bool SummerCamp { get; set; }
        [Display(Name = "Zimowisko")]
        public bool WinterCamp { get; set; }
        [Display(Name = "Biwak")]
        public bool Bivouac { get; set; }
        [Display(Name = "Gałąź Zielona")]
        public bool Scouts { get; set; }
        [Display(Name = "Gałąź Żółta")]
        public bool WolfCubs { get; set; }
        [Display(Name = "Jezioro")]
        public bool Lake { get; set; }
        [Display(Name = "Rzeka")]
        public bool River { get; set; }
        [Display(Name = "Góry")]
        public bool Mountains { get; set; }
        [Display(Name = "Dostępne dla samochodu")]
        public bool AccessibleByCar { get; set; }
        [Display(Name = "Zabudowania")]
        public bool Buildings { get; set; }
        [Display(Name = "Toaleta")]
        public bool Toilet { get; set; }
        [Display(Name = "Prysznic")]
        public bool Shower { get; set; }
        [Display(Name = "Kuchnia")]
        public bool Kitchen { get; set; }
        [Display(Name = "Możliwość noclegu wewnątrz")]
        public bool SleepingInside { get; set; }
        [Display(Name = "Maksymalna ilość osób")]
        public int MaxPeopleCapacity { get; set; }
        [Display(Name = "Zdjęcie")]
        public string ImagePath { get; set; }
        [Display(Name = "Odległość od najbliższych gospodarstw")]
        public string DistanceFromBuildings { get; set; }
        [Display(Name = "Najbliższy szpital")]
        public string NearestHospital { get; set; }
        [Display(Name = "Najbliższa Jednostka Straży Pożarnej")]
        public string NearestFireDepartment { get; set; }
        [Display(Name = "Najbliższy Posterunek Policji")]
        public string NearestPoliceStation { get; set; }
        [Display(Name = "Najbliższy Sklep")]
        public string NearestMarket { get; set; }
        [Display(Name = "Najbliższa Parafia")]
        public string NearestParish { get; set; }
        [Display(Name = "Sanepid")]
        public string Sanel { get; set; }
        [Display(Name = "Nadleśnictwo")]
        public string Superintendence { get; set; }
        [Display(Name = "Powiatowa Straż Pożarna")]
        public string PoviatFireBrigade { get; set; }
        [Display(Name = "Osoba Kontaktowa")]
        public string ContactPoint { get; set; }
        [Display(Name = "E-mail do osoby kontaktowej")]
        [EmailAddress]
        public string EmailToCP { get; set; }
        [Display(Name = "Telefon do osoby kontaktowej")]
        public string PhoneToCP { get; set; }
        [Display(Name = "Data ostatniej edycji")]
        public DateTime? LastEdited { get; set; }
        public string EditorId { get; set; }
        [Display(Name = "Utworzono")]
        public DateTime TimeCreated { get; set; }
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
