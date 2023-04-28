using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Credyty.Models;

namespace Credyty.Controllers
{
    public class salidaVehiculoController : ApiController
    {
        private Model2 db = new Model2();
        private MiContexto con = new MiContexto();
        
        // GET: api/salidaVehiculo
        public IQueryable<salidaVehiculo> GetsalidaVehiculo()
        {
            return db.salidaVehiculo;
        }

        // GET: api/salidaVehiculo/5
        [ResponseType(typeof(salidaVehiculo))]
        public IHttpActionResult GetsalidaVehiculo(int id)
        {
            salidaVehiculo salidaVehiculo = db.salidaVehiculo.Find(id);
            if (salidaVehiculo == null)
            {
                return NotFound();
            }

            return Ok(salidaVehiculo);
        }

        // PUT: api/salidaVehiculo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutsalidaVehiculo(int id, salidaVehiculo salidaVehiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != salidaVehiculo.idSalidaVEhiculo)
            {
                return BadRequest();
            }

            db.Entry(salidaVehiculo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!salidaVehiculoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        //metodo que retorna la insercion de tabla salidaVehiculo adicionalmente 
        //genera actualizacion del estado en la tabla ingresoVehiculo lo deja en estado Pago
        // POST: api/salidaVehiculo
        [ResponseType(typeof(salidaVehiculo))]
        public IHttpActionResult PostsalidaVehiculo([FromBody] SalidaIngresoVehiculo data)
        {
            salidaVehiculo salidaVehiculo = data.salidaVehiculo;
            ingresoVehiculo ingresoVehiculo = data.ingresoVehiculo;
            ingresoVehiculoController ingre = new ingresoVehiculoController();
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.salidaVehiculo.Add(salidaVehiculo);
            db.SaveChanges();
         

            ingre.PutingresoVehiculo(salidaVehiculo.idIngresoVehiculo, ingresoVehiculo);

            return CreatedAtRoute("DefaultApi", new { id = salidaVehiculo.idSalidaVEhiculo }, salidaVehiculo);


        }

        // DELETE: api/salidaVehiculo/5
        [ResponseType(typeof(salidaVehiculo))]
        public IHttpActionResult DeletesalidaVehiculo(int id)
        {
            salidaVehiculo salidaVehiculo = db.salidaVehiculo.Find(id);
            if (salidaVehiculo == null)
            {
                return NotFound();
            }

            db.salidaVehiculo.Remove(salidaVehiculo);
            db.SaveChanges();

            return Ok(salidaVehiculo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool salidaVehiculoExists(int id)
        {
            return db.salidaVehiculo.Count(e => e.idSalidaVEhiculo == id) > 0;
        }

        [HttpPost]
        [Route("api/ConsultarValorPagar")]
        public int ConsultarValor(consultarValorApagar consultarValorApagar) {

            int valorApagar = 0;
            int valorFinalApagar = 0;
            int descuento;

            switch (consultarValorApagar.TipodeVehiculo) {

                case "carro":
                    valorApagar = 110;

                    break;
                case "moto":
                    valorApagar = 50;
                    break;
                case "bici":
                    valorApagar = 10;
                    break;
            }

            if (!string.IsNullOrEmpty(consultarValorApagar.CodigoFactura))
            {
                descuento = valorApagar * 30 / 100;
                valorFinalApagar = valorApagar - descuento;
            }
            else {
                valorFinalApagar = valorApagar;


            }
            return valorFinalApagar;
        }

        // POST: api/ConsultarRango
        [HttpPost]
        [Route("api/ConsultarRango")]

        public List<ModeloSP> getconsultar(FiltroCarga FiltroCarga) {
            try
            {
              List<ModeloSP> SP = con.ObtenerVehiculosPorRangoHorario(FiltroCarga.horaIngreso, FiltroCarga.horaSalida);
              return SP;
             
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}