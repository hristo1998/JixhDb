using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JixhDb.API.Services;

namespace JixhDb.Web.Controllers
{
    [RoutePrefix("api/search")]
    public class SearchController : ApiController
    {
        private readonly SearchSearvice _service;


        public SearchController()
        {
            this._service = new SearchSearvice();
        }

        // GET: api/Search
        [HttpGet, Route("{search}")]
        public IHttpActionResult Get(string search)
        {
            var vm = this._service.GetAll(3, search);
            if (vm == null)
            {
                return this.NotFound();
            }
            else
            {
                return this.Ok(vm);
            }
            
        }
    }
}
