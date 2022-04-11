using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PensionesWebApi.Models;

namespace PensionesWebApi.Services
{
    public interface IUsuarioService
    {
        bool PasswordValidation(string password, Usuario usuario);
        string GetJsonToken(int id, string secret);
        Usuario GetUserProperties(Usuario user, string password);
        Usuario UpdatePassword(Password password);
        Usuario GetUserById(int id);
        Usuario ForgotPassword(string password);
        string CreateTemporalPassword();
    }
}
