using System;
using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using PensionesWebApi.Models;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;

namespace PensionesWebApi.Helpers
{
    public class Email : IEmail
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public Email(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public void SendEmail(int action, Usuario usuario, string password)
        {
            string templateBody = CreateEmailBody(usuario, action, password);

            SendHtmlFormattedEmail(action, templateBody, usuario.Email);
        }

        public string CreateEmailBody(Usuario usuario, int action, string password)
        {
            string template = string.Empty;
            var path = _hostingEnvironment.ContentRootPath + "\\EmailTemplate\\PensionesEmailTemplate.html";
            //using streamreader for reading my htmltemplate   
            using (StreamReader reader = new StreamReader(path))
            {
                template = reader.ReadToEnd();
            }

            var body = GetContenido(action, usuario, password);

            template = template.Replace("<!--CONTENIDO-->", body);

            return template;
        }

        public void SendHtmlFormattedEmail(int action, string templateBody, string email)
        {
            using(MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress("notification@pensionesweb.com");
                mailMessage.Subject = GetSubject(action);
                mailMessage.Body = "";
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(email));
                mailMessage.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(templateBody, new ContentType("text/html")));

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("pensionesweb@gmail.com", "Pensiones123*");
                    smtp.EnableSsl = true;
                    smtp.Send(mailMessage);
                }
            }
        }

        public string GetSubject(int accion)
        {
            var titulo = string.Empty;

            switch (accion)
            {
                case 1:
                    titulo = "Registro de usuario";
                    break;
                case 2:
                    titulo = "Actualización de contraseña";
                    break;
                case 3:
                    titulo = "Contraseña temporal";
                    break;
                default:
                    break;
            }
                
            return titulo;
        }

        public string GetContenido(int accion, Usuario usuario, string password)
        {
            var contenido = string.Empty;

            switch (accion)
            {
                //Nuevo Usuario
                case 1:
                    contenido = "<p style='font-size: 12pt; color: #63666A;'>Hola " + usuario.Nombre + ",</p>" +
                        "<p style='font-size: 12pt; color: #63666A;'>Has sido registrado como nuevo usuario del sistema <strong>Pensiones Web</strong>. <br></p>" +
                        "<p style='font-size: 12pt; color: #63666A;'>A continuación encontraras tu nombre de usuario y contraseña temporal para acceder al sitio web: <br><br></p>" +
                        "<p style='font-size: 12pt; color: #63666A;'><strong>Usuario: </strong> " + usuario.UserName + "<br>" +
                        "<strong>Contraseña: </strong> " + password + "<br></p>";
                    break;
                //Actualizacion Contraseña
                case 2:
                    contenido = "<p style='font-size: 12pt; color: #63666A;'>Hola " + usuario.Nombre + ",</p>" +
                        "<p style='font-size: 12pt; color: #63666A;'>Tu contraseña ha sido actualizada correctamente.<br></p>" +
                        "<p style='font-size: 12pt; color: #63666A;'>A continuación encontraras tu nombre de usuario y nueva contraseña para acceder al sitio web: <br><br></p>" +
                        "<p style='font-size: 12pt; color: #63666A;'><strong>Usuario: </strong> " + usuario.UserName + "<br>" +
                        "<strong>Contraseña: </strong> " + password + "<br></p>";
                    break;
                //Olvido Contraseña
                case 3:
                    contenido = "<p style='font-size: 12pt; color: #63666A;'>Hola " + usuario.Nombre + ",</p>" +
                        "<p style='font-size: 12pt; color: #63666A;'>Has solicitado restablecer tu contraseña para ingresar al sistema <strong>Pensiones Web</strong>.<br></p>" +
                        "<p style='font-size: 12pt; color: #63666A;'>A continuación encontraras tu nombre de usuario y una contraseña temporal para acceder al sitio web y crear una nueva contraseña: <br><br></p>" +
                        "<p style='font-size: 12pt; color: #63666A;'><strong>Usuario: </strong> " + usuario.UserName + "<br>" +
                        "<strong>Contraseña: </strong> " + password + "<br></p>";
                    break;
                default:
                    break;
            }

            return contenido;
        }
    }
}
