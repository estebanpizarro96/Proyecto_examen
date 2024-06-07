﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyecto_Prueba.Context;

#nullable disable

namespace Proyecto_examen.Migrations
{
    [DbContext(typeof(DatabaseDbContext))]
    [Migration("20240607210742_InitDB")]
    partial class InitDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("Proyecto_examen.Models.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CorreoPersona")
                        .HasColumnType("TEXT");

                    b.Property<string>("DireccionPersona")
                        .HasColumnType("TEXT");

                    b.Property<string>("PrimerApellido")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PrimerNombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RutPersona")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SegundoApellido")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TelefonoPersona")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Personas", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}