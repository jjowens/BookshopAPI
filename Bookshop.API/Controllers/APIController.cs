using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
//using System.Web.Mvc;

namespace Bookshop.API.Controllers
{
    public class APIController : ApiController
    {
        [HttpGet]
        public string Hi()
        {
            return string.Format("HI there, it's {0}", DateTime.Now.ToShortTimeString()); 
        }




    }
}