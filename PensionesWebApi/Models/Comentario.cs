using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PensionesWebApi.Models
{
    [Table("comentario")]
    public class Comentario
    {
        [Key]
        [Column("comentario_id")]
        public int ComentarioId { get; set; }

        [Required]
        [Column("mensaje")]
        public string Mensaje { get; set; }

        [Required]
        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; }

        [Required]
        [Column("creado_por_usuario")]
        public int CreadoPorUsuario { get; set; }

        [Column("expediente_id")]
        public int ExpedienteId { get; set; }
        public Expediente Expediente { get; set; }
    }
}
