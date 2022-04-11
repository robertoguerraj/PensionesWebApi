using PensionesWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PensionesWebApi.Helpers
{
    public interface IEmail
    {
        void SendEmail(int action, Usuario usuario, string password);
        string CreateEmailBody(Usuario usuario, int action, string password);
        void SendHtmlFormattedEmail(int action, string templateBody, string email);
        string GetSubject(int accion);
        string GetContenido(int accion, Usuario usuario, string password);
    }
}
