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
        public string PrimerNombre { get; set; } = string.Empty;
        public string PrimerApellido { get; set; } = string.Empty;
        public string SegundoApellido { get; set; } = string.Empty;
        public string? DireccionPersona { get; set; } = string.Empty;
        public string? TelefonoPersona { get; set; } = string.Empty;
        public string? CorreoPersona { get; set; } = string.Empty;
    }

}
