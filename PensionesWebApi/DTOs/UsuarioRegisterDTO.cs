using PensionesWebApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PensionesWebApi.DTOs
{
    public class UsuarioRegisterDTO
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int RolId { get; set; }
        [Required]
        public int UbicacionId { get; set; }
    }
}
