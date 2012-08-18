using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Core.Internal;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using CumbriaMD.Domain;
using CumbriaMD.Infrastructure.Mappings;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace CumbriaMD.Web.Windsor.Facilities
{
    public class PersistenceFacility : AbstractFacility
    {
        protected override void Init()
        {
            var config = BuildDatabaseConfiguration();
            
            Kernel.Register(
                Component.For<ISessionFactory>()
                    .UsingFactoryMethod(_ => config.BuildSessionFactory()),
                Component.For<ISession>()
                    .UsingFactoryMethod(k => k.Resolve<ISessionFactory>().OpenSession())
                    .LifestylePerWebRequest());
        }

        private FluentConfiguration BuildDatabaseConfiguration()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                              .ConnectionString(
                              @"Data Source=localhost\SQLEXPRESS;Initial Catalog=eDetectorDb;Integrated Security=true")
                                  .UseOuterJoin()
                              .ShowSql())
                .Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<BrandMap>())
                .ExposeConfiguration(ConfigurePersistence)
                .ExposeConfiguration(BuildSchema);
        }

        protected virtual void ConfigurePersistence(Configuration config)
        {
            SchemaMetadataUpdater.QuoteTableAndColumns(config);
        }

        protected virtual bool IsDomainEntity(Type t)
        {
            return typeof(EntityBase).IsAssignableFrom(t);
        }

        protected virtual AutoPersistenceModel CreateMappingModel()
        {
            var m = AutoMap.Assembly(typeof(EntityBase).Assembly)
            .Where(IsDomainEntity)
            .OverrideAll(ShouldIgnoreProperty)
            .IgnoreBase<EntityBase>();

            return m;
        }

        private void ShouldIgnoreProperty(IPropertyIgnorer property)
        {
            property.IgnoreProperties(p => p.MemberInfo.HasAttribute<DoNotMapAttribute>());
        }

        private void BuildSchema(Configuration configuration)
        {
            new SchemaExport(configuration)
           .Create(false, false);
        }
    }
}