using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PensionesWebApi.Models
{
    [Table("expediente_documento")]
    public class ExpedienteDocumento
    {
        [Key]
        [Column("expediente_documento_id")]
        public int ExpedienteDocumentoId { get; set; }

        [Column("registrado")]
        public bool Registrado { get; set; }

        [Column("server_path")]
        public string ServerPath { get; set; }

        [Column("fecha_actualizacion")]
        public DateTime? FechaActualizacion { get; set; }

        [Column("actualizado_por_usuario")]
        public int? ActualizadoPorUsuario { get; set; }

        [Column("expediente_id")]
        public int ExpedienteId { get; set; }
        public Expediente Expediente { get; set; }

        [Column("documento_id")]
        public int DocumentoId { get; set; }
        public Documento Documento { get; set; }
    }
}
