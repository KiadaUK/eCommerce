using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Installer;
using CumbriaMD.Domain;
using CumbriaMD.Infrastructure.ViewModels.DisplayAttributes;
using CumbriaMD.Web.AutoMapper;
using CumbriaMD.Web.Windsor;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace CumbriaMD.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer _windsorContainer;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            log4net.Config.XmlConfigurator.Configure(); 
            BundleConfig.RegisterBundles(BundleTable.Bundles);
                 
            //Initialize Custom Display Attributes
            ModelMetadataProviders.Current = new MetadataProvider();

            //Initialize AutoMapper
            AutomapperConfiguration.Configure();


            //Bootstrap Windsor
            BootstrapContainer();
        }


        protected void Application_End()
        {
            _windsorContainer.Dispose();
        }

        private static void BootstrapContainer()
        {
            _windsorContainer = new WindsorContainer()
                .Install(FromAssembly.This());
            var controllerFactory = new WindsorControllerFactory(_windsorContainer.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}