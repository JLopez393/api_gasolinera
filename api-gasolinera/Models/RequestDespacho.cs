using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_gasolinera.Models
{
    public class RequestDespacho
    {
        public string Id { get; set; }
        public string idDespacho { get; set; }
        public string descripcion { get; set; }
        public string codigoActivo { get; set; }
        public string numeroPlaca { get; set; }
        public string descVehiculo { get; set; }
        public string cuentaContable { get; set; }
        public float valorOdometro { get; set; }
        public float valorHoras { get; set; }
        public string idOrdenDespacho { get; set; }
        public string codigoEmpleado { get; set; }
        public float galonaje { get; set; }
        public string ingresoManual { get; set; }
        public string idManguera { get; set; }
        public string idTanque { get; set; }
        public string estado { get; set; }
        public string cadenaQR { get; set; }
        public string usuarioCreacion { get; set; }
        public string aplicacionCreacion { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string usuarioModificacion { get; set; }
        public string aplicacionModificacion { get; set; }
        public DateTime fechaModificacion { get; set; }
        public DateTime fechaSincronizacion { get; set; }
    }
}