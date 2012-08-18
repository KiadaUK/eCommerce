using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.Core.Logging;
using CumbriaMD.Domain;


namespace CumbriaMD.Web.Controllers
{
    public class HomeController : SessionController
    {
        
        public ActionResult Index()
        {

            
            return View();
        }

    }
}
