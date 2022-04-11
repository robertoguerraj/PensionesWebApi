using PensionesWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PensionesWebApi.DTOs
{
    public class ComentarioPostDTO
    {
        public int ComentarioId { get; set; }
        public string Mensaje { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int CreadoPorUsuario { get; set; }
        public int ExpedienteId { get; set; }
    }
}
