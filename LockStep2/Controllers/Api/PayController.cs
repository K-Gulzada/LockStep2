using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace LockStep2.Controllers
{
    public class PayController : ApiController
    {
        public IHttpActionResult Get(string paymentId, int bookId, decimal sum, string email)
        {
            return Ok();
        }
    }
}

//autofac dependency injection