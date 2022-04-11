using PensionesWebApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PensionesWebApi.DTOs
{
    public class ExpedientePostDTO
    {
        public int ExpedienteId { get; set; }
        [Required]
        [MaxLength(11)]
        public string NSS { get; set; }
        public DateTime? FechaIngreso { get; set; }
        [MaxLength(50)]
        public string OcupacionLaboral { get; set; }
        [MaxLength(20)]
        public string UMF { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        [MaxLength(3)]
        public int? Edad { get; set; }
        [MaxLength(40)]
        public string Nombre { get; set; }
        [MaxLength(20)]
        public string ApellidoPaterno { get; set; }
        [MaxLength(20)]
        public string ApellidoMaterno { get; set; }
        [MaxLength(20)]
        public string TelefonoCelular { get; set; }
        [MaxLength(20)]
        public string TelefonoCasa { get; set; }
        [MaxLength(20)]
        public string CURP { get; set; }
        [MaxLength(40)]
        public string PadecimientoEnfermedad { get; set; }
        [MaxLength(50)]
        public string NombreConyugue { get; set; }
        [MaxLength(20)]
        public string CURPBeneficiario { get; set; }
        public DateTime? FechaEntregaDespacho { get; set; }
        [MaxLength(3)]
        public int? ComprobanteId { get; set; }
        [MaxLength(2)]
        public int? ResolucionId { get; set; }
        public DateTime? FechaCreacion { get; set; }
        [Required]
        public int CreadoPorUsuario { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public int? ActualizadoPorUsuario { get; set; }
        public int SegmentoId { get; set; }
        public int FlujoId { get; set; }
        public DomicilioIFEDTO DomicilioIFE { get; set; }
        public DomicilioComprobanteDTO DomicilioComprobante { get; set; }
    }
}
