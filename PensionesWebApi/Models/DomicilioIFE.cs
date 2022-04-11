using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PensionesWebApi.Models
{
    [Table("domicilio_ife")]
    public class DomicilioIFE
    {
        [Key]
        [Column("domicilio_ife_id")]
        public int DomicilioIFEId { get; set; }

        [Column("calle")]
        public string Calle { get; set; }

        [Column("numero_exterior")]
        public int? NumeroExterior { get; set; }

        [Column("numero_interior")]
        public string NumeroInterior { get; set; }

        [Column("colonia")]
        public string Colonia { get; set; }

        [Column("codigo_postal")]
        public int? CodigoPostal { get; set; }

        [Column("estado")]
        public string Estado { get; set; }

        [Column("municipio")]
        public string Municipio { get; set; }
    }
}
