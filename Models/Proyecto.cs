namespace Portafolio.Models
{
    public class Proyecto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Description { get; set; }
        public string ImagenURL { get; set; }
        public string Link { get; set; }
    }
}
