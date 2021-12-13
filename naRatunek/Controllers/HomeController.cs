using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using naRatunek.Data;
using naRatunek.Models.Hospitals;
using naRatunek.Models.Pharmacy;
using System.Dynamic;

namespace naRatunek.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// inicjalizacja bazy danych
        /// Index jest to funkcja domyślna uruchamiana na starcie aplikacji, w tym przypadku domyślnie do niej wysyłane są dane z formularza.
        /// Jeśli użytkownik wybrał już miasto i typ obiektów to w zależności od tych danych zwracane są one w ViewBag.Obiekty.
        /// 
        /// GetAll to funkcja pobierająca wszystkie obiekty z danego miasta i mające pierwsze 4 znaki kodu pocztowego takie same jak ten przypisany do lokalizacji użytkownika.
        /// 
        /// GetHospitals i GetPharmacies to funkcje pomocnicze korzystające z modeli danych zawartych w bazie, symulacja zapytań SQL.
        /// 
        /// Pobierane dane zamieniane są w String z ustalonymi rozdzieleniami (symulacja CSV) by potem łatwiej przyporządkować dane.
        /// 
        /// </summary>
        private naRatunekContext db = new naRatunekContext();

        public async Task<ActionResult> Index(string city, string obiekt)
        {
            if(city == "")
            {
                ViewBag.Obiekty = "";
                return View();
            }
            else
            { 
                if (obiekt == "Szpitale")
                {
                    ViewBag.Obiekty = GetHospitals(city);
                }
                else
                {
                    ViewBag.Obiekty = GetPharmacies(city);
                }
                return View();
            }
        }

        public String GetAll(string city, string zip)
        {
            List<String> wszystko = new List<String>();
            foreach (var item in db.Hospitals)
            {
                if ((item.City == city) && (String.Equals(item.PostalCode.Remove(4), zip.Remove(4))))
                    wszystko.Add("Szpital; " + item.HospitalName + " " + item.Email + " " + item.Telephone + " ;" + item.City + " " + item.Street + " " + item.StreetNumber + ";_");
            }
            foreach (var item in db.Pharmacies)
            {
                if ((item.City == city) && (String.Equals(item.PostalCode.Remove(4), zip.Remove(4))))
                    wszystko.Add("Apteka; " + item.PharmacyName + " ;" + item.City + " " + item.Street + " " + item.StreetNumber + " " + item.FlatNumber + ";_");
            }
            string combindedString = string.Join(",", wszystko);
            return combindedString;
        }

        public List<String> GetHospitals(string city)
        {
            List<String> hospitals = new List<String>();
            foreach (var item in db.Hospitals)
            {
                if (item.City == city)
                    hospitals.Add("Szpital; " + item.HospitalName + " " + item.Email + " " + item.Telephone + " ;" + item.City + " " + item.Street + " " + item.StreetNumber + ";_");
            }
             return hospitals;
        }

        public List<String> GetPharmacies(string city)
        {
            List<String> pharmacies = new List<String>();
            foreach (var item in db.Pharmacies)
            {
                if (item.City == city)
                    pharmacies.Add("Apteka; " + item.PharmacyName + " ;" + item.City + " " + item.Street + " " + item.StreetNumber + " " + item.FlatNumber + ";_");
            }
            return pharmacies;
        }

        public ActionResult GetNearMyLocation(string currentlat, string currentLng)
        {
            using (var context = new Data.naRatunekContext())
            {
                var currentLocation = DbGeography.FromText("POINT("+ currentlat +"" +currentLng+")");
               // var places = (from  u in context.Hospitals orderby u.ge)
            }
            return View();
        }

        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}