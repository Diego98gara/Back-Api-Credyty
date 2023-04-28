using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Credyty.Models
{
    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model2")
        {
        }

        public virtual DbSet<salidaVehiculo> salidaVehiculo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<salidaVehiculo>()
                .Property(e => e.numeroFactura)
                .IsUnicode(false);

            modelBuilder.Entity<salidaVehiculo>()
                .Property(e => e.valorPagado)
                .IsUnicode(false);
        }
    }
}
