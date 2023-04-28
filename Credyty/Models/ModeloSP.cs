using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Credyty.Models
{
    public class ModeloSP
    {
        [Key]
        public int idVehiculo { get; set; }
        public string tipoVehiculo { get; set; }
        public string placa { get; set; }
        public System.DateTime horaIngreso { get; set; }
        public System.DateTime horaSalida { get; set; }
        public string numeroFactura { get; set; }
        public string valorPagado { get; set; }
    }
}