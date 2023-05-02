using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Servicios;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositorioProyectos repositorioProyectos;

        //la inyecion de dependencias se da en el constructor de la clase para poder se usada dentro de la clase
        public HomeController(
            IRepositorioProyectos repositorioProyectos
            )
        {
            this.repositorioProyectos = repositorioProyectos;
        }

        public IActionResult Index()
        {
            var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();

            var modelo = new HomeIndexViewModel() { 
                Proyectos = proyectos,
            };
            return View(modelo);
        }
        public IActionResult Proyectos ()
        {
            var proyectos = repositorioProyectos.ObtenerProyectos();
            return View(proyectos);
        }

        public IActionResult Contacto()
        {
            return View();
        }
                                                               
        [HttpPost] //atributo de un metodo
        public IActionResult Contacto(ContactoViewModel contactoViewModel) 
        {
            //redireccion a una vista
            return RedirectToAction("Agradecimiento");
        }
        public IActionResult Agradecimiento()
        {
            return View();
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