using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AstAppWebApi.Controllers
{
    [RoutePrefix("api/PoolApi")]
    [Authorize]
    public class PoolApiController : ApiController
    {
        public IHttpActionResult GetPools()
        {
            return Ok();
        }

    }
}
