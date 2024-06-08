using Microsoft.EntityFrameworkCore;
using Proyecto_examen.Models;//importacion de otro namespace
using Proyecto_Prueba.Context;
using System;
using System.Data.Common;
using System.Reflection;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args); // Add services to the container.

builder.Services.AddControllers(); // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<DatabaseDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Data Source=.\\Data\\SQlLiteDatabase.db"));
});

var app = builder.Build(); // Configure the HTTP request pipeline.



/*
using (var scope = app.Services.CreateScope()) //ejecuta toda la linea de codigo y crea la base de datos ->Migracion
{
    var dataContext = scope.ServiceProvider.GetRequiredService<DatabaseDbContext>();
    dataContext.Database.Migrate(); 
}
*/
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

namespace Proyecto_test.Models
{
    class GestionPersonas
    {

        static async Task Main(String[] args)
        {
            using (var db = new DatabaseDbContext())
            {
                await db.Database.EnsureCreatedAsync();

                var Persona1 = new Persona()
                {
                    RutPersona = "19326168-K",
                    PrimerNombre = "Esteban",
                    PrimerApellido = "Pizarro",
                    SegundoApellido = "Arancibia",
                    DireccionPersona = "Ricardo de Ferrari 105",
                    TelefonoPersona = "56956255712",
                    CorreoPersona = "esteban.pizarro.arancibia@gmail.com"
                };
                var Persona2 = new Persona()
                {
                    RutPersona = "19973751-1",
                    PrimerNombre = "Fernanda",
                    PrimerApellido = "Rivera",
                    SegundoApellido = "Acevedo",
                    DireccionPersona = "Ricardo de Ferrari 105",
                    TelefonoPersona = "56956255712",
                    CorreoPersona = "fer.rivera.acevedo@gmail.com"
                };
                db.Personas.Add(Persona1);
                db.Personas.Add(Persona2);

                await db.SaveChangesAsync();
            }



        }

        }
    }
    
