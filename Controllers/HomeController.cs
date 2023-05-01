using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var proyectos = ObtenerProyectos().Take(3).ToList();
            var modelo = new HomeIndexViewModel() { Proyectos = proyectos };
            return View(modelo);
        }

        private List<Proyecto> ObtenerProyectos() {
            return new List<Proyecto>(){
                new Proyecto {
                    Titulo = "Amazon",
                    Description = "E-Commerce realizado en ASP.NET Core",
                    Link = "http://amazon.com",
                    ImagenURL = "/imagenes/amazon.jpg"
                },
                new Proyecto {
                    Titulo = "New York Times",
                    Description = "Pagina de noticias en React",
                    Link = "http://nytimes.com",
                    ImagenURL = "/imagenes/New-York-Times.png"
                },
                new Proyecto {
                    Titulo = "Reddit",
                    Description = "Red Social para compartir en comunidades",
                    Link = "http://reddit.com",
                    ImagenURL = "/imagenes/reddit-01.jpg"
                },
                new Proyecto {
                    Titulo = "Steam",
                    Description = "Tienda en linea para comprar videojuegos",
                    Link = "http://store.teampowered.com",
                    ImagenURL = "/imagenes/steam.jpg"
                }
            };
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}