using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PensionesWebApi.Models;

namespace PensionesWebApi.EntityFramework
{
    public static class PensionesDBData
    {
        public static void InsertInitialData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>().HasData(new Rol { RolId = 1, Nombre = "Administrador", Descripcion = "Privilegios de ejecutar cualquier operacion.", Activo = true });
            modelBuilder.Entity<Rol>().HasData(new Rol { RolId = 2, Nombre = "Usuario Regular", Descripcion = "Puede capturar expedientes y subir documentos escaneados.", Activo = true });
            modelBuilder.Entity<Rol>().HasData(new Rol { RolId = 3, Nombre = "Validador", Descripcion = "Valida los datos capturados y los documentos de cada expediente.", Activo = true });

            modelBuilder.Entity<Flujo>().HasData(new Flujo { FlujoId = 1, Nombre = "Capturando", Descripcion = "Primer paso para capturar datos y documentos del cliente.", Activo = true });
            modelBuilder.Entity<Flujo>().HasData(new Flujo { FlujoId = 2, Nombre = "Captura Completa", Descripcion = "Captura de datos y documentos completa y lista para validarse.", Activo = true });
            modelBuilder.Entity<Flujo>().HasData(new Flujo { FlujoId = 3, Nombre = "Validando", Descripcion = "Validacion de datos y documentos por departamento juridico.", Activo = true });
            modelBuilder.Entity<Flujo>().HasData(new Flujo { FlujoId = 4, Nombre = "Completado", Descripcion = "Expediente completado.", Activo = true });

            modelBuilder.Entity<Ubicacion>().HasData(new Ubicacion { UbicacionId = 1, Descripcion = "Monterrey", Activo = true });
            modelBuilder.Entity<Ubicacion>().HasData(new Ubicacion { UbicacionId = 2, Descripcion = "Ciudad de México", Activo = true });
            modelBuilder.Entity<Ubicacion>().HasData(new Ubicacion { UbicacionId = 3, Descripcion = "Piedras Negras", Activo = true });

            modelBuilder.Entity<Segmento>().HasData(new Segmento { SegmentoId = 1, Descripcion = "Otorgamiento Cesantia y Vejez", Activo = true });
            modelBuilder.Entity<Segmento>().HasData(new Segmento { SegmentoId = 2, Descripcion = "Incremento Cesantia y Vejez", Activo = true });
            modelBuilder.Entity<Segmento>().HasData(new Segmento { SegmentoId = 3, Descripcion = "Otorgamiento Viudez", Activo = true });
            modelBuilder.Entity<Segmento>().HasData(new Segmento { SegmentoId = 4, Descripcion = "Incremento Viudez", Activo = true });

            modelBuilder.Entity<Resolucion>().HasData(new Resolucion { ResolucionId = 1, Descripcion = "Cesantia", Activo = true });
            modelBuilder.Entity<Resolucion>().HasData(new Resolucion { ResolucionId = 2, Descripcion = "Vejez", Activo = true });
            modelBuilder.Entity<Resolucion>().HasData(new Resolucion { ResolucionId = 3, Descripcion = "Viudez", Activo = true });
            modelBuilder.Entity<Resolucion>().HasData(new Resolucion { ResolucionId = 4, Descripcion = "Negativa", Activo = true });

            modelBuilder.Entity<Comprobante>().HasData(new Comprobante { ComprobanteId = 1, Descripcion = "Luz", Activo = true });
            modelBuilder.Entity<Comprobante>().HasData(new Comprobante { ComprobanteId = 2, Descripcion = "Agua", Activo = true });
            modelBuilder.Entity<Comprobante>().HasData(new Comprobante { ComprobanteId = 3, Descripcion = "Telefono", Activo = true });
            modelBuilder.Entity<Comprobante>().HasData(new Comprobante { ComprobanteId = 4, Descripcion = "Gas", Activo = true });
            modelBuilder.Entity<Comprobante>().HasData(new Comprobante { ComprobanteId = 5, Descripcion = "Internet", Activo = true });
            modelBuilder.Entity<Comprobante>().HasData(new Comprobante { ComprobanteId = 6, Descripcion = "Otro", Activo = true });

            modelBuilder.Entity<Documento>().HasData(new Documento { DocumentoId = 1, Nombre = "NSS", Activo = true });
            modelBuilder.Entity<Documento>().HasData(new Documento { DocumentoId = 2, Nombre = "IFE", Activo = true });
            modelBuilder.Entity<Documento>().HasData(new Documento { DocumentoId = 3, Nombre = "CURP", Activo = true });
            modelBuilder.Entity<Documento>().HasData(new Documento { DocumentoId = 4, Nombre = "Comprobante de domicilio", Activo = true });
            modelBuilder.Entity<Documento>().HasData(new Documento { DocumentoId = 5, Nombre = "Acta de nacimiento", Activo = true });
            modelBuilder.Entity<Documento>().HasData(new Documento { DocumentoId = 6, Nombre = "Acta de difusión", Activo = true });
            modelBuilder.Entity<Documento>().HasData(new Documento { DocumentoId = 7, Nombre = "Concubinato", Activo = true });
        }
    }
}
