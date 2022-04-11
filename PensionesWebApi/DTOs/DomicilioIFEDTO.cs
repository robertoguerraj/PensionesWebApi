using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PensionesWebApi.Models
{
    public class DomicilioIFEDTO
    {
        public int? DomicilioIFEId { get; set; }
        public string Calle { get; set; }
        public int? NumeroExterior { get; set; }
        public string NumeroInterior { get; set; }
        public string Colonia { get; set; }
        public int? CodigoPostal { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
    }
}
