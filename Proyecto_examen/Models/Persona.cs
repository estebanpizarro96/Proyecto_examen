using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_examen.Models
{
    
        public class Persona //Modelo base de datos 
        {
            public int Id { get; set; }
            public string RutPersona { get; set; }
            public string PrimerNombre { get; set; }
            public string PrimerApellido { get; set; }
            public string SegundoApellido { get; set; }
            public string? DireccionPersona { get; set; }
            public string? TelefonoPersona { get; set; }
            public string? CorreoPersona { get; set; }
        }

        public class PersonaDTO
        {
            public string RutPersonaDTO { get; set; }
            public string PrimerNombreDTO { get; set; }
            public string PrimerApellidoDTO {  get; set; }
            public string SegundoApellidoDTO {  get; set; }
            public string? DireccionPersonaDTO { get; set; }
            public string? TelefonoPersonaDTO { get; set; }
            public string? CorreoPersonaDTO { get; set; }


        }

}

