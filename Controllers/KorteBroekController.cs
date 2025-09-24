using Microsoft.AspNetCore.Mvc;

namespace KorteBroeken.Controllers
{
    public class KorteBroekController : Controller
    {
        // GET: /KorteBroek/ of /KorteBroek/Index of /KorteBroek/Index/{id}
        public IActionResult Index(int? id, string? naam)
        {
            if (id == 3 && !string.IsNullOrWhiteSpace(naam))
            {
                ViewData["Title"] = "Welkom!";
                ViewData["Antwoord"] = $"Welkom {naam}, jij kunt ALTIJD een korte broek aan";
                ViewData["Temperatuur"] = "-";
                ViewData["Regenkans"] = "-";
                ViewData["Afbeelding"] = Url.Content("~/images/droog.png"); // Droog als standaard
                return View("Weer");
            }
            return View();
        }

        // GET: /KorteBroek/Weer?temperatuur=...&regenkans=...
        [HttpGet]
        public IActionResult Weer(int temperatuur, int regenkans)
        {
            string antwoord;
            string afbeelding;

            if (regenkans >= 80)
            {
                afbeelding = Url.Content("~/images/storm.jpg");
            }
            else if (regenkans >= 30)
            {
                afbeelding = Url.Content("~/images/bui.jpg");
            }
            else
            {
                afbeelding = Url.Content("~/images/droog.jpg");
            }

            if (temperatuur > 20 && regenkans < 50)
            {
                antwoord = "Ja! je kunt vandaag een korte broek aan";
            }
            else
            {
                antwoord = "Nee, je kunt vandaag helaas geen korte broek aan";
            }

            ViewData["Antwoord"] = antwoord;
            ViewData["Temperatuur"] = temperatuur;
            ViewData["Regenkans"] = regenkans;
            ViewData["Afbeelding"] = afbeelding;
            return View();
        }
    }
}