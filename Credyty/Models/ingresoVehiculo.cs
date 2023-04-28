namespace Credyty.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ingresoVehiculo")]
    public partial class ingresoVehiculo
    {
        [Key]
        public int idVehiculo { get; set; }

        [Required]
        [StringLength(150)]
        public string tipoVehiculo { get; set; }

      
        [StringLength(150)]
        public string placa { get; set; }

        public DateTime horaIngreso { get; set; }

        public string EstadoPago { get; set; }
    }
}
