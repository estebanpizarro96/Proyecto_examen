using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_examen.Models;
using Proyecto_Prueba.Context;
using Proyecto_test.Models;

namespace Proyecto_examen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly DatabaseDbContext _dbContext;

        public PersonaController(DatabaseDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task<ActionResult<List<Persona>>> ObtenerPersonas() //listar personas en la base de datos
        {
            var personas = await _dbContext.Personas.ToListAsync();

            return Ok(personas);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> GetPersona(int id) //obtener por ID
        {
            var persona = await _dbContext.Personas.FindAsync(id);

            if(persona is null) 
                return BadRequest("Persona no encontrada");

            return Ok(persona);
        }

        [HttpPost]

        public async Task<ActionResult<List<Persona>>> AñadirPersona([FromBody]Persona persona) //Añadir personas

        {
             _dbContext.Personas.Add(persona); 
            await _dbContext.SaveChangesAsync();

            return Ok(await ObtenerPersonas());
        }

        [HttpPut]
        public async Task<ActionResult<List<Persona>>> UpdatePersona(Persona updatePersona) //update personas

        {
            var dbpersona = await _dbContext.Personas.FindAsync(updatePersona.Id);
            if (dbpersona is null)
                return NotFound("Persona no encontrada");

            dbpersona.RutPersona = updatePersona.RutPersona;
            dbpersona.PrimerNombre = updatePersona.PrimerNombre;
            dbpersona.PrimerApellido = updatePersona.PrimerApellido;
            dbpersona.SegundoApellido = updatePersona.SegundoApellido;
            dbpersona.DireccionPersona = updatePersona.DireccionPersona;
            dbpersona.TelefonoPersona = updatePersona.TelefonoPersona;
            dbpersona.CorreoPersona = updatePersona.CorreoPersona;
        
            return Ok(await _dbContext.Personas.ToListAsync());
        }
    }
}
