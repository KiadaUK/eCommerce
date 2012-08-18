using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CumbriaMD.Domain;
using FluentNHibernate.Mapping;

namespace CumbriaMD.Infrastructure.Mappings
{
    public class BrandMap : ClassMap<Brand>
    {
        public BrandMap()
        {
            Id(x => x.Id);

            Map(x => x.Name)
                .Not.Nullable()
                .Length(50);

            Map(x => x.IsActive)
                .Not.Nullable();

            References(x => x.DefaultProduct);

            References(x => x.Image)
                .Not.Nullable();

            HasMany(x => x.Products);

        }
    }
}
