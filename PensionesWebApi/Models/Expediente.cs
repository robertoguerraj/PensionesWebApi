using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PensionesWebApi.Models
{
    [Table("expediente")]
    public class Expediente
    {
        [Key]
        [Column("expediente_id")]
        public int ExpedienteId { get; set; }

        [Required]
        [MaxLength(11)]
        [Column("nss")]
        public string NSS { get; set; }

        [Column("fecha_ingreso")]
        public DateTime? FechaIngreso { get; set; }

        [MaxLength(50)]
        [Column("ocupacion_laboral")]
        public string OcupacionLaboral { get; set; }

        [MaxLength(20)]
        [Column("umf")]
        public string UMF { get; set; }

        [Column("fecha_nacimiento")]
        public DateTime? FechaNacimiento { get; set; }

        [MaxLength(3)]
        [Column("edad")]
        public int? Edad { get; set; }

        [MaxLength(40)]
        [Column("nombre")]
        public string Nombre { get; set; }

        [MaxLength(20)]
        [Column("apellido_paterno")]
        public string ApellidoPaterno { get; set; }

        [MaxLength(20)]
        [Column("apellido_materno")]
        public string ApellidoMaterno { get; set; }

        [MaxLength(20)]
        [Column("telefono_celular")]
        public string TelefonoCelular { get; set; }

        [MaxLength(20)]
        [Column("telefono_casa")]
        public string TelefonoCasa{ get; set; }

        [MaxLength(20)]
        [Column("curp")]
        public string CURP { get; set; }

        [MaxLength(40)]
        [Column("padecimiento_enfermedad")]
        public string PadecimientoEnfermedad { get; set; }

        [MaxLength(50)]
        [Column("nombre_conyugue")]
        public string NombreConyugue { get; set; }

        [MaxLength(20)]
        [Column("curp_beneficiario")]
        public string CURPBeneficiario { get; set; }

        [Column("fecha_entrega_despacho")]
        public DateTime? FechaEntregaDespacho { get; set; }

        [MaxLength(3)]
        [Column("comprobante_id")]
        public int? ComprobanteId { get; set; }

        [MaxLength(2)]
        [Column("resolucion_id")]
        public int? ResolucionId { get; set; }

        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; }

        [Required]
        [Column("creado_por_usuario")]
        public int CreadoPorUsuario { get; set; }

        [Column("fecha_actualizacion")]
        public DateTime? FechaActualizacion { get; set; }

        [Column("actualizado_por_usuario")]
        public int? ActualizadoPorUsuario { get; set; }

        [Column("segmento_id")]
        public int SegmentoId { get; set; }
        public Segmento Segmento { get; set; }

        [Column("flujo_id")]
        public int FlujoId { get; set; }
        public Flujo Flujo { get; set; }

        [Column("domicilio_ife_id")]
        public int DomicilioIFEId { get; set; }
        public DomicilioIFE DomicilioIFE { get; set; }

        [Column("domicilio_comprobante_id")]
        public int DomicilioComprobanteId { get; set; }
        public DomicilioComprobante DomicilioComprobante { get; set; }
    }
}
