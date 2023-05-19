using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_gasolinera.Models
{
    public class ModelActivo
    {
        public int codigoActivo { get; set; }
        public string numeroPlaca { get; set; }
        public string tipoVehiculo { get; set; }
        public string unidadNegocio { get; set; }
        public string estado { get; set; }
        public string usuarioCreacion { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string aplicacionCreacion { get; set; }
        public string usuarioActualizacion { get; set; }
        public DateTime fechaActualizacion { get; set; }
        public string aplicacionActualizacion { get; set; }
        public DateTime fechaSincronizacion { get; set; }
    }
}