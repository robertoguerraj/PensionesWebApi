using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PensionesWebApi.Models
{
    public class Password
    {
        [Required]
        public int UsuarioId { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
