using Portafolio.Models;

namespace Portafolio.Servicios
{
    public class RepositorioProyectos : IRepositorioProyectos
    {
        //el principio de responsabilidad ayuda a que una clase ejecute una tarea
        public List<Proyecto> ObtenerProyectos()
        {
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
    }
}
