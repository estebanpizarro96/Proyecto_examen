using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_examen.Models;
using Proyecto_Prueba.Context;

namespace Proyecto_examen.Controllers
{
    [Route("api/[controller]")] //direccion del controlador

    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly DatabaseDbContext _dbContext;

        public PersonaController(DatabaseDbContext dbContext) //inyeccion de dependencias
        {
            _dbContext = dbContext; 
        }

        [HttpGet]
        public async Task<ActionResult<List<Persona>>> ObtenerPersonas() //listar personas en la base de datos
        {
            var personas = await _dbContext.Personas.ToListAsync();

            return Ok(personas);
        }

        
        [HttpGet("{rut}")]
        public async Task<ActionResult<Persona>> GetPersona(string rut) //obtener por ID
        {
            
            var persona = await _dbContext.Personas.FindAsync(rut);

            if(persona == null) 
                return NotFound("Persona no encontrada");

            return Ok(persona);
        }

        [HttpPost]

        public async Task<ActionResult<string>> AñadirPersona([FromBody] PersonaPostDTO personaPost) //Añadir personas
        {
            if(personaPost.RutPersonaDTO.Length > 10)
            {
                throw new Exception("Rut demasiado largo, ingrese nuevamente");
            }    

            var nuevaPersona = new Persona 
            {
                RutPersona = personaPost.RutPersonaDTO,
                PrimerNombre = personaPost.PrimerNombreDTO,
                PrimerApellido = personaPost.PrimerApellidoDTO,
                SegundoApellido = personaPost.SegundoApellidoDTO,
                DireccionPersona = personaPost.DireccionPersonaDTO,
                TelefonoPersona = personaPost.TelefonoPersonaDTO,
                CorreoPersona = personaPost.CorreoPersona,

            };

            await _dbContext.Personas.AddAsync(nuevaPersona); 
            await _dbContext.SaveChangesAsync();

            return Ok("Usuario creado");
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
