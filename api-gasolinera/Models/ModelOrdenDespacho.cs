using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_gasolinera.Models
{
    public class ModelOrdenDespacho
    {
        public string id { get; set; }
        public string fuente { get; set; }
        public string concepto { get; set; }
        public string tipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public string codigoLocalidad { get; set; }
        public decimal cantidadQuintales { get; set; }
        public string estado { get; set; }
        public string usuarioCreacion { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string aplicacionCreacion { get; set; }
        public string usuarioActualizacion { get; set; }
        public DateTime fechaActualizacion { get; set; }
        public string aplicacionActualizacion { get; set; }
        public DateTime fechaSincronización { get; set; }
    }
}