using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_gasolinera.Models
{
    public class ResponseSincronizacionIN
    {
        public object lActivo { get; set; }
        public object lDespacho { get; set; }
        public object lEmpleado { get; set; }
        public object lOrdenes { get; set; }
    }
}