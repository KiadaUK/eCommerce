using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CumbriaMD.Web.Controllers;
using NHibernate;
using NHibernate.Cfg;

namespace CumbriaMD.Web.Filters
{
    public class NHibernateActionFilter : ActionFilterAttribute
    {
        private static ISessionFactory _sessionFactory;

        public NHibernateActionFilter(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sessionController = filterContext.Controller as SessionController;

            if (sessionController == null)
                return;

            sessionController.Session = _sessionFactory.OpenSession();
            sessionController.Session.BeginTransaction();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var sessionController = filterContext.Controller as SessionController;

            if (sessionController == null)
                return;

            using (var session = sessionController.Session)
            {
                if (session == null)
                    return;

                if (!session.Transaction.IsActive)
                    return;

                if (filterContext.Exception != null)
                    session.Transaction.Rollback();
                else
                    session.Transaction.Commit();
            }
        }
    }
}