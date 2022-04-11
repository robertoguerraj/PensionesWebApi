using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PensionesWebApi.Models
{
    [Table("documento")]
    public class Documento
    {
        [Key]
        [Column("documento_id")]
        public int DocumentoId { get; set; }

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }

        [Required]
        [Column("activo")]
        public bool Activo { get; set; }
    }
}