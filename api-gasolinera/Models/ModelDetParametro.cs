using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_gasolinera.Models
{
    public class ModelDetParametro
    {
        public string id { get; set; }
        public string idParametro { get; set; }
        public string nombre { get; set; }
        public string valor { get; set; }
        public string estado { get; set; }
        public string usuarioCreacion { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string aplicacionCreacion { get; set; }
        public string usuarioActualizacion { get; set; }
        public DateTime fechaActualizacion { get; set; }
        public string aplicacionActualizacion { get; set; }
    }
}