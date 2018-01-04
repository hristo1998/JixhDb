using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JixhDb.API.Services;
using JixhDb.Models.ViewModels.Movies;

namespace JixhDb.API.Controllers
{
    [RoutePrefix("api")]
    public class SearchController : ApiController
    {

        private readonly SearchSearvice _service;

        public SearchController()
        {
            this._service = new SearchSearvice();
        }

        [HttpGet, Route("{search}")]
        public IHttpActionResult Get(string search)
        {
            IEnumerable<MovieSearchViewModel> vms = this._service.GetAll(4, search);
            return this.Ok(vms);
        }
    }
}
