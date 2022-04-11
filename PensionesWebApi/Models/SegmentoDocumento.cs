using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PensionesWebApi.Models
{
    [Table("segmento_documento")]
    public class SegmentoDocumento
    {
        [Key]
        [Column("segmento_documento_id")]
        public int SegmentoDocumentoId { get; set; }

        [Column("segmento_id")]
        public int SegmentoId { get; set; }
        public Segmento Segmento { get; set; }

        [Column("documento_id")]
        public int DocumentoId { get; set; }
        public Documento Documento { get; set; }
    }
}
