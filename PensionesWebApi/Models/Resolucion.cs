using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PensionesWebApi.Models
{
    [Table("resolucion")]
    public class Resolucion
    {
        [Key]
        [Column("resolucion_id")]
        public int ResolucionId { get; set; }

        [Required]
        [Column("descripcion")]
        public string Descripcion { get; set; }

        [Required]
        [Column("activo")]
        public bool Activo { get; set; }
    }
}