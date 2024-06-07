using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_examen.Models
{
    public class Persona //Modelo base de datos 
    {
        public int ID { get; set; }
        public string RutPersona { get; set; }
        public string PrimerNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string? DireccionPersona { get; set; }
        public string? TelefonoPersona { get; set; }
        public string? CorreoPersona { get; set; }
    }

}
