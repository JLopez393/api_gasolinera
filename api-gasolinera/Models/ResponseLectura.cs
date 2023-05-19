using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_gasolinera.Models
{
    public class ResponseLectura
    {
        public int idVenta { get; set; }
        public string caraVenta { get; set; }
        public string pistolaVenta { get; set; }
        public float montoVenta { get; set; }
        public float galonajeVenta { get; set; }
    }
}