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
using ABS.Models;

namespace ABS.Controllers
{
    public class CitiesController : ApiController
    {
        private ABS2021Entities_City db = new ABS2021Entities_City();

        // GET: api/bncGeoCities
        public IQueryable<bncGeoCity> GetbncGeoCities()
        {
            return db.bncGeoCities;
        }

        // GET: api/bncGeoCities/5
        [ResponseType(typeof(bncGeoCity))]
        public IHttpActionResult GetbncGeoCity(int id)
        {
            bncGeoCity bncGeoCity = db.bncGeoCities.Find(id);
            if (bncGeoCity == null)
            {
                return NotFound();
            }

            return Ok(bncGeoCity);
        }

      
     
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool bncGeoCityExists(int id)
        {
            return db.bncGeoCities.Count(e => e.CityID == id) > 0;
        }
    }
}