using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PensionesWebApi.Models
{
    [Table("rol")]
    public class Rol
    {
        [Key]
        [Column("rol_id")]
        public int RolId { get; set; }

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("descripcion")]
        public string Descripcion { get; set; }

        [Required]
        [Column("activo")]
        public bool Activo { get; set; }
    }
}
