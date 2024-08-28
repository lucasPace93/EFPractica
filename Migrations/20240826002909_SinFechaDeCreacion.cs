using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFPractica.Migrations
{
    /// <inheritdoc />
    public partial class SinFechaDeCreacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("5e054d99-fab9-4e75-8547-15f9e577b651"), null, "Actividades pendientes", 20 },
                    { new Guid("a814c2cc-00fa-44f8-9071-9a8b8c30174d"), null, "Actividades personales", 30 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("177e77c2-afb0-4bea-8103-2aeb9f9a8b60"), new Guid("5e054d99-fab9-4e75-8547-15f9e577b651"), "armar un api", new DateTime(2024, 8, 25, 21, 29, 8, 235, DateTimeKind.Local).AddTicks(899), 1, "Estudiar Api Rest" },
                    { new Guid("dd3d55f0-9d03-4bf2-9b8c-954852b00bba"), new Guid("a814c2cc-00fa-44f8-9071-9a8b8c30174d"), "La concha de tu madre edenor", new DateTime(2024, 8, 25, 21, 29, 8, 235, DateTimeKind.Local).AddTicks(913), 2, "Pagar la factura de luz " }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("177e77c2-afb0-4bea-8103-2aeb9f9a8b60"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("dd3d55f0-9d03-4bf2-9b8c-954852b00bba"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("5e054d99-fab9-4e75-8547-15f9e577b651"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("a814c2cc-00fa-44f8-9071-9a8b8c30174d"));
        }
    }
}
