using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CumbriaMD.Domain;
using FluentNHibernate.Mapping;

namespace CumbriaMD.Infrastructure.Mappings
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id);

            Map(x => x.Name)
                .Length(100)
                .Not.Nullable();

            Map(x => x.Code)
                .Not.Nullable();

            Map(x => x.Description)
                .Length(1500)
                .Not.Nullable();

            Map(x => x.Price)
                .Not.Nullable();

            Map(x => x.IsDiscounted)
                .Not.Nullable();

            Map(x => x.IsInStock)
                .Not.Nullable();

            HasManyToMany(x => x.Categories)
                .Table("CategoriesProducts")
                .Cascade.All();

            References(x => x.Brand);
                

            Map(x => x.AddedAt)
                .Not.Nullable();

            Map(x => x.UpdatedAt)
                .Not.Nullable();


        }
    }
}
