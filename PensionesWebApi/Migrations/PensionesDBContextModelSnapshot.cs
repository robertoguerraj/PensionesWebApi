// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PensionesWebApi.EntityFramework;

namespace PensionesWebApi.Migrations
{
    [DbContext(typeof(PensionesDBContext))]
    partial class PensionesDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PensionesWebApi.Models.Comentario", b =>
                {
                    b.Property<int>("ComentarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("comentario_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreadoPorUsuario")
                        .HasColumnName("creado_por_usuario")
                        .HasColumnType("int");

                    b.Property<int>("ExpedienteId")
                        .HasColumnName("expediente_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnName("fecha_creacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mensaje")
                        .IsRequired()
                        .HasColumnName("mensaje")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ComentarioId");

                    b.HasIndex("ExpedienteId");

                    b.ToTable("comentario");
                });

            modelBuilder.Entity("PensionesWebApi.Models.Comprobante", b =>
                {
                    b.Property<int>("ComprobanteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("comprobante_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnName("activo")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnName("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ComprobanteId");

                    b.ToTable("comprobante");

                    b.HasData(
                        new
                        {
                            ComprobanteId = 1,
                            Activo = true,
                            Descripcion = "Luz"
                        },
                        new
                        {
                            ComprobanteId = 2,
                            Activo = true,
                            Descripcion = "Agua"
                        },
                        new
                        {
                            ComprobanteId = 3,
                            Activo = true,
                            Descripcion = "Telefono"
                        },
                        new
                        {
                            ComprobanteId = 4,
                            Activo = true,
                            Descripcion = "Gas"
                        },
                        new
                        {
                            ComprobanteId = 5,
                            Activo = true,
                            Descripcion = "Internet"
                        },
                        new
                        {
                            ComprobanteId = 6,
                            Activo = true,
                            Descripcion = "Otro"
                        });
                });

            modelBuilder.Entity("PensionesWebApi.Models.Documento", b =>
                {
                    b.Property<int>("DocumentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("documento_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnName("activo")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnName("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DocumentoId");

                    b.ToTable("documento");

                    b.HasData(
                        new
                        {
                            DocumentoId = 1,
                            Activo = true,
                            Nombre = "NSS"
                        },
                        new
                        {
                            DocumentoId = 2,
                            Activo = true,
                            Nombre = "IFE"
                        },
                        new
                        {
                            DocumentoId = 3,
                            Activo = true,
                            Nombre = "CURP"
                        },
                        new
                        {
                            DocumentoId = 4,
                            Activo = true,
                            Nombre = "Comprobante de domicilio"
                        },
                        new
                        {
                            DocumentoId = 5,
                            Activo = true,
                            Nombre = "Acta de nacimiento"
                        },
                        new
                        {
                            DocumentoId = 6,
                            Activo = true,
                            Nombre = "Acta de difusión"
                        },
                        new
                        {
                            DocumentoId = 7,
                            Activo = true,
                            Nombre = "Concubinato"
                        });
                });

            modelBuilder.Entity("PensionesWebApi.Models.DomicilioComprobante", b =>
                {
                    b.Property<int>("DomicilioComprobanteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("domicilio_comprobante_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Calle")
                        .HasColumnName("calle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CodigoPostal")
                        .HasColumnName("codigo_postal")
                        .HasColumnType("int");

                    b.Property<string>("Colonia")
                        .HasColumnName("colonia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnName("estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Municipio")
                        .HasColumnName("municipio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumeroExterior")
                        .HasColumnName("numero_exterior")
                        .HasColumnType("int");

                    b.Property<string>("NumeroInterior")
                        .HasColumnName("numero_interior")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DomicilioComprobanteId");

                    b.ToTable("domicilio_comprobante");
                });

            modelBuilder.Entity("PensionesWebApi.Models.DomicilioIFE", b =>
                {
                    b.Property<int>("DomicilioIFEId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("domicilio_ife_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Calle")
                        .HasColumnName("calle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CodigoPostal")
                        .HasColumnName("codigo_postal")
                        .HasColumnType("int");

                    b.Property<string>("Colonia")
                        .HasColumnName("colonia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnName("estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Municipio")
                        .HasColumnName("municipio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumeroExterior")
                        .HasColumnName("numero_exterior")
                        .HasColumnType("int");

                    b.Property<string>("NumeroInterior")
                        .HasColumnName("numero_interior")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DomicilioIFEId");

                    b.ToTable("domicilio_ife");
                });

            modelBuilder.Entity("PensionesWebApi.Models.Expediente", b =>
                {
                    b.Property<int>("ExpedienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("expediente_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActualizadoPorUsuario")
                        .HasColumnName("actualizado_por_usuario")
                        .HasColumnType("int");

                    b.Property<string>("ApellidoMaterno")
                        .HasColumnName("apellido_materno")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("ApellidoPaterno")
                        .HasColumnName("apellido_paterno")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("CURP")
                        .HasColumnName("curp")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("CURPBeneficiario")
                        .HasColumnName("curp_beneficiario")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int?>("ComprobanteId")
                        .HasColumnName("comprobante_id")
                        .HasColumnType("int")
                        .HasMaxLength(3);

                    b.Property<int>("CreadoPorUsuario")
                        .HasColumnName("creado_por_usuario")
                        .HasColumnType("int");

                    b.Property<int>("DomicilioComprobanteId")
                        .HasColumnName("domicilio_comprobante_id")
                        .HasColumnType("int");

                    b.Property<int>("DomicilioIFEId")
                        .HasColumnName("domicilio_ife_id")
                        .HasColumnType("int");

                    b.Property<int?>("Edad")
                        .HasColumnName("edad")
                        .HasColumnType("int")
                        .HasMaxLength(3);

                    b.Property<DateTime?>("FechaActualizacion")
                        .HasColumnName("fecha_actualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnName("fecha_creacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaEntregaDespacho")
                        .HasColumnName("fecha_entrega_despacho")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaIngreso")
                        .HasColumnName("fecha_ingreso")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaNacimiento")
                        .HasColumnName("fecha_nacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("FlujoId")
                        .HasColumnName("flujo_id")
                        .HasColumnType("int");

                    b.Property<string>("NSS")
                        .IsRequired()
                        .HasColumnName("nss")
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("Nombre")
                        .HasColumnName("nombre")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("NombreConyugue")
                        .HasColumnName("nombre_conyugue")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("OcupacionLaboral")
                        .HasColumnName("ocupacion_laboral")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PadecimientoEnfermedad")
                        .HasColumnName("padecimiento_enfermedad")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<int?>("ResolucionId")
                        .HasColumnName("resolucion_id")
                        .HasColumnType("int")
                        .HasMaxLength(2);

                    b.Property<int>("SegmentoId")
                        .HasColumnName("segmento_id")
                        .HasColumnType("int");

                    b.Property<string>("TelefonoCasa")
                        .HasColumnName("telefono_casa")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("TelefonoCelular")
                        .HasColumnName("telefono_celular")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("UMF")
                        .HasColumnName("umf")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("ExpedienteId");

                    b.HasIndex("DomicilioComprobanteId");

                    b.HasIndex("DomicilioIFEId");

                    b.HasIndex("FlujoId");

                    b.HasIndex("SegmentoId");

                    b.ToTable("expediente");
                });

            modelBuilder.Entity("PensionesWebApi.Models.ExpedienteDocumento", b =>
                {
                    b.Property<int>("ExpedienteDocumentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("expediente_documento_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActualizadoPorUsuario")
                        .HasColumnName("actualizado_por_usuario")
                        .HasColumnType("int");

                    b.Property<int>("DocumentoId")
                        .HasColumnName("documento_id")
                        .HasColumnType("int");

                    b.Property<int>("ExpedienteId")
                        .HasColumnName("expediente_id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaActualizacion")
                        .HasColumnName("fecha_actualizacion")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Registrado")
                        .HasColumnName("registrado")
                        .HasColumnType("bit");

                    b.Property<string>("ServerPath")
                        .HasColumnName("server_path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExpedienteDocumentoId");

                    b.HasIndex("DocumentoId");

                    b.HasIndex("ExpedienteId");

                    b.ToTable("expediente_documento");
                });

            modelBuilder.Entity("PensionesWebApi.Models.Flujo", b =>
                {
                    b.Property<int>("FlujoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("flujo_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnName("activo")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .HasColumnName("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnName("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Paso")
                        .HasColumnName("paso")
                        .HasColumnType("int");

                    b.HasKey("FlujoId");

                    b.ToTable("flujo");

                    b.HasData(
                        new
                        {
                            FlujoId = 1,
                            Activo = true,
                            Descripcion = "Primer paso para capturar datos y documentos del cliente.",
                            Nombre = "Capturando",
                            Paso = 0
                        },
                        new
                        {
                            FlujoId = 2,
                            Activo = true,
                            Descripcion = "Captura de datos y documentos completa y lista para validarse.",
                            Nombre = "Captura Completa",
                            Paso = 0
                        },
                        new
                        {
                            FlujoId = 3,
                            Activo = true,
                            Descripcion = "Validacion de datos y documentos por departamento juridico.",
                            Nombre = "Validando",
                            Paso = 0
                        },
                        new
                        {
                            FlujoId = 4,
                            Activo = true,
                            Descripcion = "Expediente completado.",
                            Nombre = "Completado",
                            Paso = 0
                        });
                });

            modelBuilder.Entity("PensionesWebApi.Models.Resolucion", b =>
                {
                    b.Property<int>("ResolucionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("resolucion_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnName("activo")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnName("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ResolucionId");

                    b.ToTable("resolucion");

                    b.HasData(
                        new
                        {
                            ResolucionId = 1,
                            Activo = true,
                            Descripcion = "Cesantia"
                        },
                        new
                        {
                            ResolucionId = 2,
                            Activo = true,
                            Descripcion = "Vejez"
                        },
                        new
                        {
                            ResolucionId = 3,
                            Activo = true,
                            Descripcion = "Viudez"
                        },
                        new
                        {
                            ResolucionId = 4,
                            Activo = true,
                            Descripcion = "Negativa"
                        });
                });

            modelBuilder.Entity("PensionesWebApi.Models.Rol", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("rol_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnName("activo")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .HasColumnName("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnName("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RolId");

                    b.ToTable("rol");

                    b.HasData(
                        new
                        {
                            RolId = 1,
                            Activo = true,
                            Descripcion = "Privilegios de ejecutar cualquier operacion.",
                            Nombre = "Administrador"
                        },
                        new
                        {
                            RolId = 2,
                            Activo = true,
                            Descripcion = "Puede capturar expedientes y subir documentos escaneados.",
                            Nombre = "Usuario Regular"
                        },
                        new
                        {
                            RolId = 3,
                            Activo = true,
                            Descripcion = "Valida los datos capturados y los documentos de cada expediente.",
                            Nombre = "Validador"
                        });
                });

            modelBuilder.Entity("PensionesWebApi.Models.Segmento", b =>
                {
                    b.Property<int>("SegmentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("segmento_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnName("activo")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnName("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SegmentoId");

                    b.ToTable("segmento");

                    b.HasData(
                        new
                        {
                            SegmentoId = 1,
                            Activo = true,
                            Descripcion = "Otorgamiento Cesantia y Vejez"
                        },
                        new
                        {
                            SegmentoId = 2,
                            Activo = true,
                            Descripcion = "Incremento Cesantia y Vejez"
                        },
                        new
                        {
                            SegmentoId = 3,
                            Activo = true,
                            Descripcion = "Otorgamiento Viudez"
                        },
                        new
                        {
                            SegmentoId = 4,
                            Activo = true,
                            Descripcion = "Incremento Viudez"
                        });
                });

            modelBuilder.Entity("PensionesWebApi.Models.SegmentoDocumento", b =>
                {
                    b.Property<int>("SegmentoDocumentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("segmento_documento_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DocumentoId")
                        .HasColumnName("documento_id")
                        .HasColumnType("int");

                    b.Property<int>("SegmentoId")
                        .HasColumnName("segmento_id")
                        .HasColumnType("int");

                    b.HasKey("SegmentoDocumentoId");

                    b.HasIndex("DocumentoId");

                    b.HasIndex("SegmentoId");

                    b.ToTable("segmento_documento");
                });

            modelBuilder.Entity("PensionesWebApi.Models.Ubicacion", b =>
                {
                    b.Property<int>("UbicacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ubicacion_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnName("activo")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnName("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UbicacionId");

                    b.ToTable("ubicacion");

                    b.HasData(
                        new
                        {
                            UbicacionId = 1,
                            Activo = true,
                            Descripcion = "Monterrey"
                        },
                        new
                        {
                            UbicacionId = 2,
                            Activo = true,
                            Descripcion = "Ciudad de México"
                        },
                        new
                        {
                            UbicacionId = 3,
                            Activo = true,
                            Descripcion = "Piedras Negras"
                        });
                });

            modelBuilder.Entity("PensionesWebApi.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("usuario_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnName("activo")
                        .HasColumnType("bit");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnName("apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnName("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnName("password_hash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnName("password_salt")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("RolId")
                        .HasColumnName("rol_id")
                        .HasColumnType("int");

                    b.Property<bool>("TemporalPassword")
                        .HasColumnName("temporal_password")
                        .HasColumnType("bit");

                    b.Property<int>("UbicacionId")
                        .HasColumnName("ubicacion_id")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnName("user_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioId");

                    b.HasIndex("RolId");

                    b.HasIndex("UbicacionId");

                    b.ToTable("usuario");
                });

            modelBuilder.Entity("PensionesWebApi.Models.Comentario", b =>
                {
                    b.HasOne("PensionesWebApi.Models.Expediente", "Expediente")
                        .WithMany()
                        .HasForeignKey("ExpedienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PensionesWebApi.Models.Expediente", b =>
                {
                    b.HasOne("PensionesWebApi.Models.DomicilioComprobante", "DomicilioComprobante")
                        .WithMany()
                        .HasForeignKey("DomicilioComprobanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PensionesWebApi.Models.DomicilioIFE", "DomicilioIFE")
                        .WithMany()
                        .HasForeignKey("DomicilioIFEId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PensionesWebApi.Models.Flujo", "Flujo")
                        .WithMany()
                        .HasForeignKey("FlujoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PensionesWebApi.Models.Segmento", "Segmento")
                        .WithMany()
                        .HasForeignKey("SegmentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PensionesWebApi.Models.ExpedienteDocumento", b =>
                {
                    b.HasOne("PensionesWebApi.Models.Documento", "Documento")
                        .WithMany()
                        .HasForeignKey("DocumentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PensionesWebApi.Models.Expediente", "Expediente")
                        .WithMany()
                        .HasForeignKey("ExpedienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PensionesWebApi.Models.SegmentoDocumento", b =>
                {
                    b.HasOne("PensionesWebApi.Models.Documento", "Documento")
                        .WithMany()
                        .HasForeignKey("DocumentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PensionesWebApi.Models.Segmento", "Segmento")
                        .WithMany()
                        .HasForeignKey("SegmentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PensionesWebApi.Models.Usuario", b =>
                {
                    b.HasOne("PensionesWebApi.Models.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PensionesWebApi.Models.Ubicacion", "Ubicacion")
                        .WithMany()
                        .HasForeignKey("UbicacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
