using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PensionesWebApi.DTOs
{
    public class UsuarioTokenDTO
    {
        public int UsuarioId { get; set; }
        public string UserName { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Token { get; set; }
    }
}
