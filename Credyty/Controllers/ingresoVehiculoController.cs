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
using System.Web.Http.Cors;

namespace Credyty.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers:"*",methods:"*")]
    public class ingresoVehiculoController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/ingresoVehiculo
        public IQueryable<ingresoVehiculo> GetingresoVehiculo()
        {
            return db.ingresoVehiculo;
        }

        // GET: api/ingresoVehiculo/5
        [ResponseType(typeof(ingresoVehiculo))]
        public IHttpActionResult GetingresoVehiculo(int id)
        {
            ingresoVehiculo ingresoVehiculo = db.ingresoVehiculo.Find(id);
            if (ingresoVehiculo == null)
            {
                return NotFound();
            }

            return Ok(ingresoVehiculo);
        }

        //Metodo que retorna tabla de ingresoVehiculo pero solamente los que estan en estado sinPAgo
        //GET : api/ConsultarTodosSinPago 
        [HttpGet]
        [Route("api/ConsultarTodosSinPago")]
        public IHttpActionResult GETValidarVeHiculoSinPago() {

            var ingresosVehiculo = db.ingresoVehiculo.Where(i => i.EstadoPago == "SinPago").ToList();

            if (ingresosVehiculo.Count == 0)
            {
                return NotFound();
            }

            return Ok(ingresosVehiculo);

        }

        // PUT: api/ingresoVehiculo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutingresoVehiculo(int id, ingresoVehiculo ingresoVehiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ingresoVehiculo.idVehiculo)
            {
                return BadRequest();
            }

            db.Entry(ingresoVehiculo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ingresoVehiculoExists(id))
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

        // POST: api/ingresoVehiculo
        [ResponseType(typeof(ingresoVehiculo))]
        public IHttpActionResult PostingresoVehiculo(ingresoVehiculo ingresoVehiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ingresoVehiculo.Add(ingresoVehiculo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ingresoVehiculo.idVehiculo }, ingresoVehiculo);
        }

        // DELETE: api/ingresoVehiculo/5
        [ResponseType(typeof(ingresoVehiculo))]
        public IHttpActionResult DeleteingresoVehiculo(int id)
        {
            ingresoVehiculo ingresoVehiculo = db.ingresoVehiculo.Find(id);
            if (ingresoVehiculo == null)
            {
                return NotFound();
            }

            db.ingresoVehiculo.Remove(ingresoVehiculo);
            db.SaveChanges();

            return Ok(ingresoVehiculo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ingresoVehiculoExists(int id)
        {
            return db.ingresoVehiculo.Count(e => e.idVehiculo == id) > 0;
        }






    }
}