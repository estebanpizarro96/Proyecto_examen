using Microsoft.EntityFrameworkCore;
using Proyecto_examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection; //clase dentro de system para ser leidos ej: nombre de metodos y proyectos.
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Prueba.Context
{

    public class DatabaseDbContext : DbContext //Contexto de la base de datos
    {
        private static string database = "dbSqlite.db";
        public DbSet<Persona> Personas { get; set; } //representación de la colección de la base de datos

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //sobre carga de configuración, para sobreescribir 
        {
            optionsBuilder.UseSqlite(connectionString: "Filename=" + database, sqliteOptionsAction: op =>
            {
                op.MigrationsAssembly
                    (
                        Assembly.GetExecutingAssembly().FullName
                    );
            });

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) //Función para modelar la base de datos
        {
            modelBuilder.Entity<Persona>().ToTable("Personas"); //create table
            modelBuilder.Entity<Persona>(entity => //identificar como quiero que se llame / expresiones lambda / alter table
            {
                entity.HasKey(e => e.RutPersona); //la clase persona tendrá una ID - //lambda es una función privada que te permite acceder al objeto o a la funcion
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}