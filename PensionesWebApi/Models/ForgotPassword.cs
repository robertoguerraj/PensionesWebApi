using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PensionesWebApi.Models
{
    public class ForgotPassword
    {
        [Required]
        public string Identificacion { get; set; }
    }
}
