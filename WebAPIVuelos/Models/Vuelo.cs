using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIVuelos.Models
{
    public class Vuelo
    {
        internal object IdVuelo;

        public int Idvuelo { get; set; }
        public string Numvuelo { get; set; }
        public string Codaerolinea { get; set; }
        public string Ciudadorigen { get; set; }
        public string Ciudaddestino { get; set; }
        public DateTime Horasalida  { get; set; }
        public DateTime Horallegada { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}