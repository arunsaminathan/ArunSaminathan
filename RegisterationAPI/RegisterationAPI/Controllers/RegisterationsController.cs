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
using RegisterationAPI.Models;

namespace RegisterationAPI.Controllers
{
    public class RegisterationsController : ApiController
    {
        private SamsungSDSEntities db = new SamsungSDSEntities();

       
        // POST: api/Registerations
        [HttpPost]
        //[Route("api/Registeration")]
        [ResponseType(typeof(Registeration))]
        public HttpResponseMessage PostRegisteration(Registeration registeration)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,ModelState);
            }
            try
            {
                db.Registerations.Add(registeration);
                db.SaveChanges();

                return new HttpResponseMessage(HttpStatusCode.OK);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,ex);
            }

            //return CreatedAtRoute("DefaultApi", new { id = registeration.RegisterationId }, registeration);
        }

        // DELETE: api/Registerations/5
        [ResponseType(typeof(Registeration))]
        public IHttpActionResult DeleteRegisteration(int id)
        {
            Registeration registeration = db.Registerations.Find(id);
            if (registeration == null)
            {
                return NotFound();
            }

            db.Registerations.Remove(registeration);
            db.SaveChanges();

            return Ok(registeration);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RegisterationExists(int id)
        {
            return db.Registerations.Count(e => e.RegisterationId == id) > 0;
        }
    }
}