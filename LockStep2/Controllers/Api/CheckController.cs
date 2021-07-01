using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace LockStep2.Controllers
{
    public class CheckController : ApiController
    {
        // GET: Check
        public IHttpActionResult Check()
        {
            return Ok();
        }
    }
}