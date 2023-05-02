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
        private readonly IConfiguration configuration;

        //la inyecion de dependencias se da en el constructor de la clase para poder se usada dentro de la clase
        public HomeController(ILogger<HomeController> logger,
            IRepositorioProyectos repositorioProyectos,
            IConfiguration configuration
            )
        {
            _logger = logger;
            this.repositorioProyectos = repositorioProyectos;
            this.configuration = configuration;
        }

        public IActionResult Index()
        {
            //obtencion del valor desde el archivo de configuracion appsettings.development.json cuando se ejecuta la aplicacion en modo desarrollo y si es en produccion se toma toa la configuracion desde appsetting.json
            var apellido = configuration.GetValue<string>("Apellido");
            _logger.LogTrace("Este es un mensaje de log trace");
            _logger.LogDebug("Este es un mensaje de debug");
            _logger.LogInformation("Este es un mensaje de log information");
            _logger.LogWarning("Este es un mensaje de log warnig");
            _logger.LogError("Este es un mensaje de log error");
            _logger.LogCritical("Este es un mensaje de log critical " + apellido);
            var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();

            var modelo = new HomeIndexViewModel() { 
                Proyectos = proyectos,
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