using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Servicios;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyectos repositorioProyectos;
        private readonly ServicioDelimitado servicioDelimitado;//se utiliza en el mismo contexto HTTP o en las misma peticion
        private readonly ServicioUnico ServicioUnico; //e una unica instancia durante una peticion http               
        private readonly ServicioTransitorio ServicioTransitorio; //Servicio transitorio utiliza una instancia distinta en cada servicio

        //la inyecion de dependencias se da en el constructor de la clase para poder se usada dentro de la clase
        public HomeController(ILogger<HomeController> logger,
            IRepositorioProyectos repositorioProyectos,
            ServicioDelimitado servicioDelimitado,
            ServicioUnico servicioUnico,
            ServicioTransitorio servicioTransitorio
            )
        {
            _logger = logger;
            this.repositorioProyectos = repositorioProyectos;
            this.servicioDelimitado = servicioDelimitado;
            ServicioUnico = servicioUnico;
            ServicioTransitorio = servicioTransitorio;
        }

        public IActionResult Index()
        {
            var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();

            var guidViewModel = new EjemploGUIDViewModel()
            {
                Delimitado = servicioDelimitado.ObtenerGuid,
                Transitorio = ServicioTransitorio.ObtenerGuid,
                Unico = ServicioUnico.ObtenerGuid,
            };

            var modelo = new HomeIndexViewModel() { 
                Proyectos = proyectos,
                EjemploGUID_1 = guidViewModel                
            };
            return View(modelo);
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