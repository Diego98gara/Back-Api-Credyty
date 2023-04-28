using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Credyty.Models
{
    public class MiContexto : DbContext
    {
        public MiContexto()
           : base("name=ingresoVehiculo")
        {
            Database.SetInitializer<MiContexto>(null);
        }

        public virtual DbSet<ModeloSP> ingresoVehiculo { get; set; }

        public List<ModeloSP> ObtenerVehiculosPorRangoHorario(DateTime horaInicio, DateTime horaFin)
        {

            string query = "EXEC sp_getVehiculosByRangoHorario @horaInicio, @horaFin";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@horaInicio", horaInicio),
            new SqlParameter("@horaFin", horaFin),
            };

            return Database.SqlQuery<ModeloSP>(query, parameters).ToList();
        }

    }
}