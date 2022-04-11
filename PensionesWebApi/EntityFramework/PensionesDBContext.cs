using Microsoft.EntityFrameworkCore;
using PensionesWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PensionesWebApi.EntityFramework;

namespace PensionesWebApi.EntityFramework
{
    public class PensionesDBContext : DbContext 
    {
        public PensionesDBContext(DbContextOptions<PensionesDBContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            PensionesDBData.InsertInitialData(modelBuilder);
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Ubicacion> Ubicaciones { get; set; }
        public DbSet<Flujo> Flujos { get; set; }
        public DbSet<Segmento> Segmentos { get; set; }
        public DbSet<Comprobante> Comprobantes { get; set; }
        public DbSet<Resolucion> Resoluciones { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<SegmentoDocumento> SegmentoDocumentos { get; set; }
        public DbSet<DomicilioIFE> DomicilioIFEs { get; set; }
        public DbSet<DomicilioComprobante> DomicilioComprobantes { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Expediente> Expedientes { get; set; }
        public DbSet<ExpedienteDocumento> ExpedienteDocumentos { get; set; }
    }
}
