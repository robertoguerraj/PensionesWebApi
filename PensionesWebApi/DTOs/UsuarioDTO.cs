using PensionesWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PensionesWebApi.DTOs
{
    public class UsuarioDTO
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public Rol Rol { get; set; }
        public Ubicacion Ubicacion { get; set; }
    }
}
