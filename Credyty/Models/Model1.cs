using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Credyty.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=ingresoVehiculo")
        {
        }

        public virtual DbSet<ingresoVehiculo> ingresoVehiculo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ingresoVehiculo>()
                .Property(e => e.tipoVehiculo)
                .IsUnicode(false);

            modelBuilder.Entity<ingresoVehiculo>()
                .Property(e => e.placa)
                .IsUnicode(false);
        }
    }
}
