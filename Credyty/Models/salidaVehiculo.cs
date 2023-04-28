namespace Credyty.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("salidaVehiculo")]
    public partial class salidaVehiculo
    {
        [Key]
        public int idSalidaVEhiculo { get; set; }

        public DateTime horaSalida { get; set; }

        [StringLength(150)]
        public string numeroFactura { get; set; }

        [Required]
        [StringLength(150)]
        public string valorPagado { get; set; }

        public int idIngresoVehiculo { get; set; }
    }
}
