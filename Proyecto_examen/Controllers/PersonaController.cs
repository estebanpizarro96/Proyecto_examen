using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_examen.Models;
using Proyecto_Prueba.Context;

namespace Proyecto_examen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private DatabaseDbContext _dbContext;

        public PersonaController(DatabaseDbContext context)
        {
            _dbContext = context;
        }
        [HttpGet]
        public IEnumerable<Persona> Get() => _dbContext.Personas.ToList();

    }
}
