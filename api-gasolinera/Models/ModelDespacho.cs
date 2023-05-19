using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_gasolinera.Models
{
    public class ModelDespacho
    {
        public string idDespacho { get; set; }
        public string descripcion { get; set; }
        public string codigoActivo { get; set; }
        public string numeroPlaca { get; set; }
        public string descVehiculo { get; set; }
        public string cuentaContable { get; set; }
        public decimal valorOdometro { get; set; }
        public decimal valorHoras { get; set; }
        public string idOrdenDespacho { get; set; }
        public string codigoEmpleado { get; set; }
        public decimal galonaje { get; set; }
        public string ingesoManual { get; set; }
        public string idManguera { get; set; }
        public string idTanque { get; set; }
        public string estado { get; set; }
        public string cadenaQR { get; set; }
        public string usuarioCreacion { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string aplicacionCreacion { get; set; }
        public string usuarioActualizacion { get; set; }
        public DateTime fechaActualizacion { get; set; }
        public string aplicacionActualizacion { get; set; }
        public DateTime fechaSincronizacion { get; set; }
    }
}