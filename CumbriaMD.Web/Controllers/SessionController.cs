using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.Core.Logging;
using CumbriaMD.Infrastructure.AppServices;
using CumbriaMD.Web.Filters;
using NHibernate;

namespace CumbriaMD.Web.Controllers
{
    public class SessionController : Controller
    {
        public ILogger Logger { get; set; }

        public SessionController()
        {
            
        }

        public SessionController(ILogger logger)
        {
            this.Logger = logger;
        }

        public HttpSessionStateBase HttpSession
        {
            get { return base.Session; }
        }

        public new ISession Session { get; set; }
    }       
   
}
