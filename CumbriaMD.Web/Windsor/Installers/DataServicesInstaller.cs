using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CumbriaMD.Infrastructure.DataServices;

namespace CumbriaMD.Web.Windsor.Installers
{
    public class DataServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ICategoryDataService>().ImplementedBy<CategoryDataServices>().LifestyleTransient());
        }
    }
}