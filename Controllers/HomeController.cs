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
        private readonly ServicioUnico servicioUnico; //e una unica instancia durante una peticion http               
        private readonly ServicioTransitorio servicioTransitorio; //Servicio transitorio utiliza una instancia distinta en cada servicio
        private readonly ServicioDelimitado servicioDelimitado_2;
        private readonly ServicioUnico servicioUnico_2;
        private readonly ServicioTransitorio servicioTransitorio_2;

        //la inyecion de dependencias se da en el constructor de la clase para poder se usada dentro de la clase
        public HomeController(ILogger<HomeController> logger,
            IRepositorioProyectos repositorioProyectos,
            ServicioDelimitado servicioDelimitado,
            ServicioUnico servicioUnico,
            ServicioTransitorio servicioTransitorio,

            ServicioDelimitado servicioDelimitado_2,
            ServicioUnico servicioUnico_2,
            ServicioTransitorio servicioTransitorio_2
            )
        {
            _logger = logger;
            this.repositorioProyectos = repositorioProyectos;
            this.servicioDelimitado = servicioDelimitado;
            this.servicioUnico = servicioUnico;
            this.servicioTransitorio = servicioTransitorio;

            this.servicioDelimitado_2 = servicioDelimitado_2;
            this.servicioUnico_2 = servicioUnico_2;
            this.servicioTransitorio_2 = servicioTransitorio_2;
        }

        public IActionResult Index()
        {
            var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();

            var guidViewModel = new EjemploGUIDViewModel()
            {
                Delimitado = servicioDelimitado.ObtenerGuid,
                Transitorio = servicioTransitorio.ObtenerGuid,
                Unico = servicioUnico.ObtenerGuid,
            };

            var guidViewModel_2 = new EjemploGUIDViewModel()
            {
                Delimitado = servicioDelimitado_2.ObtenerGuid,
                Transitorio = servicioTransitorio_2.ObtenerGuid,
                Unico = servicioUnico_2.ObtenerGuid,
            };
            var modelo = new HomeIndexViewModel() { 
                Proyectos = proyectos,
                EjemploGUID_1 = guidViewModel,
                EjemploGUID_2 = guidViewModel_2
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