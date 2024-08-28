using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFPractica.Migrations
{
    /// <inheritdoc />
    public partial class SinFechaCreacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Tarea");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Tarea",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("177e77c2-afb0-4bea-8103-2aeb9f9a8b60"),
                column: "FechaCreacion",
                value: new DateTime(2024, 8, 25, 21, 29, 8, 235, DateTimeKind.Local).AddTicks(899));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("dd3d55f0-9d03-4bf2-9b8c-954852b00bba"),
                column: "FechaCreacion",
                value: new DateTime(2024, 8, 25, 21, 29, 8, 235, DateTimeKind.Local).AddTicks(913));
        }
    }
}
