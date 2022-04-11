using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PensionesWebApi.Models
{
    [Table("flujo")]
    public class Flujo
    {
        [Key]
        [Column("flujo_id")]
        public int FlujoId { get; set; }

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("descripcion")]
        public string Descripcion { get; set; }

        [Required]
        [Column("paso")]
        public int Paso { get; set; }

        [Required]
        [Column("activo")]
        public bool Activo { get; set; }
    }
}
