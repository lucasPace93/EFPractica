﻿// <auto-generated />
using System;
using EFPractica;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFPractica.Migrations
{
    [DbContext(typeof(TareasContext))]
    partial class TareasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EFPractica.models.Categoria", b =>
                {
                    b.Property<Guid>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Peso")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoriaId = new Guid("5e054d99-fab9-4e75-8547-15f9e577b651"),
                            Nombre = "Actividades pendientes",
                            Peso = 20
                        },
                        new
                        {
                            CategoriaId = new Guid("a814c2cc-00fa-44f8-9071-9a8b8c30174d"),
                            Nombre = "Actividades personales",
                            Peso = 30
                        });
                });

            modelBuilder.Entity("EFPractica.models.Tareas", b =>
                {
                    b.Property<Guid>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrioridadTarea")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("TareaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Tarea", (string)null);

                    b.HasData(
                        new
                        {
                            TareaId = new Guid("177e77c2-afb0-4bea-8103-2aeb9f9a8b60"),
                            CategoriaId = new Guid("5e054d99-fab9-4e75-8547-15f9e577b651"),
                            Descripcion = "armar un api",
                            PrioridadTarea = 1,
                            Titulo = "Estudiar Api Rest"
                        },
                        new
                        {
                            TareaId = new Guid("dd3d55f0-9d03-4bf2-9b8c-954852b00bba"),
                            CategoriaId = new Guid("a814c2cc-00fa-44f8-9071-9a8b8c30174d"),
                            Descripcion = "La concha de tu madre edenor",
                            PrioridadTarea = 2,
                            Titulo = "Pagar la factura de luz "
                        });
                });

            modelBuilder.Entity("EFPractica.models.Tareas", b =>
                {
                    b.HasOne("EFPractica.models.Categoria", "Categoria")
                        .WithMany("TareaPorCategoria")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("EFPractica.models.Categoria", b =>
                {
                    b.Navigation("TareaPorCategoria");
                });
#pragma warning restore 612, 618
        }
    }
}
