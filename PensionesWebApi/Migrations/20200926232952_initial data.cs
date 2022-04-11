using Microsoft.EntityFrameworkCore.Migrations;

namespace PensionesWebApi.Migrations
{
    public partial class initialdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "comprobante",
                columns: new[] { "comprobante_id", "activo", "descripcion" },
                values: new object[,]
                {
                    { 1, true, "Luz" },
                    { 2, true, "Agua" },
                    { 3, true, "Telefono" },
                    { 4, true, "Gas" },
                    { 5, true, "Internet" },
                    { 6, true, "Otro" }
                });

            migrationBuilder.InsertData(
                table: "documento",
                columns: new[] { "documento_id", "activo", "nombre" },
                values: new object[,]
                {
                    { 7, true, "Concubinato" },
                    { 6, true, "Acta de difusión" },
                    { 4, true, "Comprobante de domicilio" },
                    { 5, true, "Acta de nacimiento" },
                    { 2, true, "IFE" },
                    { 1, true, "NSS" },
                    { 3, true, "CURP" }
                });

            migrationBuilder.InsertData(
                table: "resolucion",
                columns: new[] { "resolucion_id", "activo", "descripcion" },
                values: new object[,]
                {
                    { 1, true, "Cesantia" },
                    { 2, true, "Vejez" },
                    { 3, true, "Viudez" },
                    { 4, true, "Negativa" }
                });

            migrationBuilder.UpdateData(
                table: "rol",
                keyColumn: "rol_id",
                keyValue: 3,
                column: "descripcion",
                value: "Valida los datos capturados y los documentos de cada expediente.");

            migrationBuilder.InsertData(
                table: "segmento",
                columns: new[] { "segmento_id", "activo", "descripcion" },
                values: new object[,]
                {
                    { 4, true, "Incremento Viudez" },
                    { 1, true, "Otorgamiento Cesantia y Vejez" },
                    { 2, true, "Incremento Cesantia y Vejez" },
                    { 3, true, "Otorgamiento Viudez" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "comprobante",
                keyColumn: "comprobante_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "comprobante",
                keyColumn: "comprobante_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "comprobante",
                keyColumn: "comprobante_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "comprobante",
                keyColumn: "comprobante_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "comprobante",
                keyColumn: "comprobante_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "comprobante",
                keyColumn: "comprobante_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "documento",
                keyColumn: "documento_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "documento",
                keyColumn: "documento_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "documento",
                keyColumn: "documento_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "documento",
                keyColumn: "documento_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "documento",
                keyColumn: "documento_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "documento",
                keyColumn: "documento_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "documento",
                keyColumn: "documento_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "resolucion",
                keyColumn: "resolucion_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "resolucion",
                keyColumn: "resolucion_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "resolucion",
                keyColumn: "resolucion_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "resolucion",
                keyColumn: "resolucion_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "segmento",
                keyColumn: "segmento_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "segmento",
                keyColumn: "segmento_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "segmento",
                keyColumn: "segmento_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "segmento",
                keyColumn: "segmento_id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "rol",
                keyColumn: "rol_id",
                keyValue: 3,
                column: "descripcion",
                value: "");
        }
    }
}
