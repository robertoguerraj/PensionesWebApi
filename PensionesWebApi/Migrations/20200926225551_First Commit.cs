using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PensionesWebApi.Migrations
{
    public partial class FirstCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "comprobante",
                columns: table => new
                {
                    comprobante_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(nullable: false),
                    activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comprobante", x => x.comprobante_id);
                });

            migrationBuilder.CreateTable(
                name: "documento",
                columns: table => new
                {
                    documento_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: false),
                    activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documento", x => x.documento_id);
                });

            migrationBuilder.CreateTable(
                name: "domicilio_comprobante",
                columns: table => new
                {
                    domicilio_comprobante_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    calle = table.Column<string>(nullable: true),
                    numero_exterior = table.Column<int>(nullable: true),
                    numero_interior = table.Column<string>(nullable: true),
                    colonia = table.Column<string>(nullable: true),
                    codigo_postal = table.Column<int>(nullable: true),
                    estado = table.Column<string>(nullable: true),
                    municipio = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_domicilio_comprobante", x => x.domicilio_comprobante_id);
                });

            migrationBuilder.CreateTable(
                name: "domicilio_ife",
                columns: table => new
                {
                    domicilio_ife_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    calle = table.Column<string>(nullable: true),
                    numero_exterior = table.Column<int>(nullable: true),
                    numero_interior = table.Column<string>(nullable: true),
                    colonia = table.Column<string>(nullable: true),
                    codigo_postal = table.Column<int>(nullable: true),
                    estado = table.Column<string>(nullable: true),
                    municipio = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_domicilio_ife", x => x.domicilio_ife_id);
                });

            migrationBuilder.CreateTable(
                name: "flujo",
                columns: table => new
                {
                    flujo_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: false),
                    descripcion = table.Column<string>(nullable: true),
                    paso = table.Column<int>(nullable: false),
                    activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flujo", x => x.flujo_id);
                });

            migrationBuilder.CreateTable(
                name: "resolucion",
                columns: table => new
                {
                    resolucion_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(nullable: false),
                    activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resolucion", x => x.resolucion_id);
                });

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    rol_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: false),
                    descripcion = table.Column<string>(nullable: true),
                    activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.rol_id);
                });

            migrationBuilder.CreateTable(
                name: "segmento",
                columns: table => new
                {
                    segmento_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(nullable: false),
                    activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_segmento", x => x.segmento_id);
                });

            migrationBuilder.CreateTable(
                name: "ubicacion",
                columns: table => new
                {
                    ubicacion_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(nullable: false),
                    activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ubicacion", x => x.ubicacion_id);
                });

            migrationBuilder.CreateTable(
                name: "expediente",
                columns: table => new
                {
                    expediente_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nss = table.Column<string>(maxLength: 11, nullable: false),
                    fecha_ingreso = table.Column<DateTime>(nullable: true),
                    ocupacion_laboral = table.Column<string>(maxLength: 50, nullable: true),
                    umf = table.Column<string>(maxLength: 20, nullable: true),
                    fecha_nacimiento = table.Column<DateTime>(nullable: true),
                    edad = table.Column<int>(maxLength: 3, nullable: true),
                    nombre = table.Column<string>(maxLength: 40, nullable: true),
                    apellido_paterno = table.Column<string>(maxLength: 20, nullable: true),
                    apellido_materno = table.Column<string>(maxLength: 20, nullable: true),
                    telefono_celular = table.Column<string>(maxLength: 20, nullable: true),
                    telefono_casa = table.Column<string>(maxLength: 20, nullable: true),
                    curp = table.Column<string>(maxLength: 20, nullable: true),
                    padecimiento_enfermedad = table.Column<string>(maxLength: 40, nullable: true),
                    nombre_conyugue = table.Column<string>(maxLength: 50, nullable: true),
                    curp_beneficiario = table.Column<string>(maxLength: 20, nullable: true),
                    fecha_entrega_despacho = table.Column<DateTime>(nullable: true),
                    comprobante_id = table.Column<int>(maxLength: 3, nullable: true),
                    resolucion_id = table.Column<int>(maxLength: 2, nullable: true),
                    fecha_creacion = table.Column<DateTime>(nullable: false),
                    creado_por_usuario = table.Column<int>(nullable: false),
                    fecha_actualizacion = table.Column<DateTime>(nullable: true),
                    actualizado_por_usuario = table.Column<int>(nullable: true),
                    segmento_id = table.Column<int>(nullable: false),
                    flujo_id = table.Column<int>(nullable: false),
                    domicilio_ife_id = table.Column<int>(nullable: false),
                    domicilio_comprobante_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expediente", x => x.expediente_id);
                    table.ForeignKey(
                        name: "FK_expediente_domicilio_comprobante_domicilio_comprobante_id",
                        column: x => x.domicilio_comprobante_id,
                        principalTable: "domicilio_comprobante",
                        principalColumn: "domicilio_comprobante_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_expediente_domicilio_ife_domicilio_ife_id",
                        column: x => x.domicilio_ife_id,
                        principalTable: "domicilio_ife",
                        principalColumn: "domicilio_ife_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_expediente_flujo_flujo_id",
                        column: x => x.flujo_id,
                        principalTable: "flujo",
                        principalColumn: "flujo_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_expediente_segmento_segmento_id",
                        column: x => x.segmento_id,
                        principalTable: "segmento",
                        principalColumn: "segmento_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "segmento_documento",
                columns: table => new
                {
                    segmento_documento_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    segmento_id = table.Column<int>(nullable: false),
                    documento_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_segmento_documento", x => x.segmento_documento_id);
                    table.ForeignKey(
                        name: "FK_segmento_documento_documento_documento_id",
                        column: x => x.documento_id,
                        principalTable: "documento",
                        principalColumn: "documento_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_segmento_documento_segmento_segmento_id",
                        column: x => x.segmento_id,
                        principalTable: "segmento",
                        principalColumn: "segmento_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    usuario_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: false),
                    apellidos = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    user_name = table.Column<string>(nullable: false),
                    password_hash = table.Column<byte[]>(nullable: true),
                    password_salt = table.Column<byte[]>(nullable: true),
                    temporal_password = table.Column<bool>(nullable: false),
                    administrador = table.Column<bool>(nullable: false),
                    activo = table.Column<bool>(nullable: false),
                    rol_id = table.Column<int>(nullable: false),
                    ubicacion_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.usuario_id);
                    table.ForeignKey(
                        name: "FK_usuario_rol_rol_id",
                        column: x => x.rol_id,
                        principalTable: "rol",
                        principalColumn: "rol_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usuario_ubicacion_ubicacion_id",
                        column: x => x.ubicacion_id,
                        principalTable: "ubicacion",
                        principalColumn: "ubicacion_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comentario",
                columns: table => new
                {
                    comentario_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mensaje = table.Column<string>(nullable: false),
                    fecha_creacion = table.Column<DateTime>(nullable: false),
                    creado_por_usuario = table.Column<int>(nullable: false),
                    expediente_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comentario", x => x.comentario_id);
                    table.ForeignKey(
                        name: "FK_comentario_expediente_expediente_id",
                        column: x => x.expediente_id,
                        principalTable: "expediente",
                        principalColumn: "expediente_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "expediente_documento",
                columns: table => new
                {
                    expediente_documento_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    registrado = table.Column<bool>(nullable: false),
                    server_path = table.Column<string>(nullable: true),
                    fecha_actualizacion = table.Column<DateTime>(nullable: true),
                    actualizado_por_usuario = table.Column<int>(nullable: true),
                    expediente_id = table.Column<int>(nullable: false),
                    documento_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expediente_documento", x => x.expediente_documento_id);
                    table.ForeignKey(
                        name: "FK_expediente_documento_documento_documento_id",
                        column: x => x.documento_id,
                        principalTable: "documento",
                        principalColumn: "documento_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_expediente_documento_expediente_expediente_id",
                        column: x => x.expediente_id,
                        principalTable: "expediente",
                        principalColumn: "expediente_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "flujo",
                columns: new[] { "flujo_id", "activo", "descripcion", "nombre", "paso" },
                values: new object[,]
                {
                    { 1, true, "Primer paso para capturar datos y documentos del cliente.", "Capturando", 0 },
                    { 2, true, "Captura de datos y documentos completa y lista para validarse.", "Captura Completa", 0 },
                    { 3, true, "Validacion de datos y documentos por departamento juridico.", "Validando", 0 },
                    { 4, true, "Expediente completado.", "Completado", 0 }
                });

            migrationBuilder.InsertData(
                table: "rol",
                columns: new[] { "rol_id", "activo", "descripcion", "nombre" },
                values: new object[,]
                {
                    { 1, true, "Privilegios de ejecutar cualquier operacion.", "Administrador" },
                    { 2, true, "Puede capturar expedientes y subir documentos escaneados.", "Usuario Regular" },
                    { 3, true, "", "Validador" }
                });

            migrationBuilder.InsertData(
                table: "ubicacion",
                columns: new[] { "ubicacion_id", "activo", "descripcion" },
                values: new object[,]
                {
                    { 1, true, "Monterrey" },
                    { 2, true, "Ciudad de México" },
                    { 3, true, "Piedras Negras" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_comentario_expediente_id",
                table: "comentario",
                column: "expediente_id");

            migrationBuilder.CreateIndex(
                name: "IX_expediente_domicilio_comprobante_id",
                table: "expediente",
                column: "domicilio_comprobante_id");

            migrationBuilder.CreateIndex(
                name: "IX_expediente_domicilio_ife_id",
                table: "expediente",
                column: "domicilio_ife_id");

            migrationBuilder.CreateIndex(
                name: "IX_expediente_flujo_id",
                table: "expediente",
                column: "flujo_id");

            migrationBuilder.CreateIndex(
                name: "IX_expediente_segmento_id",
                table: "expediente",
                column: "segmento_id");

            migrationBuilder.CreateIndex(
                name: "IX_expediente_documento_documento_id",
                table: "expediente_documento",
                column: "documento_id");

            migrationBuilder.CreateIndex(
                name: "IX_expediente_documento_expediente_id",
                table: "expediente_documento",
                column: "expediente_id");

            migrationBuilder.CreateIndex(
                name: "IX_segmento_documento_documento_id",
                table: "segmento_documento",
                column: "documento_id");

            migrationBuilder.CreateIndex(
                name: "IX_segmento_documento_segmento_id",
                table: "segmento_documento",
                column: "segmento_id");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_rol_id",
                table: "usuario",
                column: "rol_id");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_ubicacion_id",
                table: "usuario",
                column: "ubicacion_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comentario");

            migrationBuilder.DropTable(
                name: "comprobante");

            migrationBuilder.DropTable(
                name: "expediente_documento");

            migrationBuilder.DropTable(
                name: "resolucion");

            migrationBuilder.DropTable(
                name: "segmento_documento");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "expediente");

            migrationBuilder.DropTable(
                name: "documento");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "ubicacion");

            migrationBuilder.DropTable(
                name: "domicilio_comprobante");

            migrationBuilder.DropTable(
                name: "domicilio_ife");

            migrationBuilder.DropTable(
                name: "flujo");

            migrationBuilder.DropTable(
                name: "segmento");
        }
    }
}
