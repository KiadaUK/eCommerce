using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CumbriaMD.Domain;
using FluentNHibernate.Mapping;

namespace CumbriaMD.Infrastructure.Mappings
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Id(x => x.Id);

            Map(x => x.Name)
                .Not.Nullable()
                .Length(50);

            Map(x => x.IsActive)
                .Not.Nullable();

            Map(x => x.OrderInList);

            References(x => x.Parent)
                .Column("ParentCategory");

            HasManyToMany(x => x.Products)
                .Table("CategoriesProducts")
                .Inverse()
                .Cascade.All();

            HasMany(x => x.Subcategories)
                .Cascade.AllDeleteOrphan();

        }
    }
}
