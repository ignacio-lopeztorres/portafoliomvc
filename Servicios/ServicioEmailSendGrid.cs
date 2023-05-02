using Portafolio.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Portafolio.Servicios
{
    public class ServicioEmailSendGrid : IServicioEmail
    {
        private readonly IConfiguration configuration;

        public ServicioEmailSendGrid(IConfiguration configuration) 
        {
            this.configuration = configuration;
        }
        public async Task Enviar(ContactoViewModel contacto) {
            var apiKey = configuration.GetValue<string>("SENDGRID_API_KEY");
            var email = configuration.GetValue<string>("SENDGRID_FROM");
            var nombre = configuration.GetValue<string>("SENDGRID_NOMBRE");

            var cliente = new SendGridClient(apiKey);
            var from = new EmailAddress(email, nombre);
            var subject = $"el cliente {contacto.Email} quiere contactarte";
            var to =  new EmailAddress(email, nombre);
            var mensajeTextoPlano = contacto.Mensaje.ToString();
            var contenidoHtml = $@"De: {contacto.Nombre} -
            Email: {contacto.Email}
            Mensaje: {contacto.Mensaje}";
            var singleEmail = MailHelper.CreateSingleEmail(from, to, subject, mensajeTextoPlano, contenidoHtml);

            //envia el correo
            var respuesta = await cliente.SendEmailAsync(singleEmail);
        }

    }
}
