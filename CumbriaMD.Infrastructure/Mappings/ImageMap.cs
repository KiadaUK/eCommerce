using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using eDetectors.Domain;

namespace CumbriaMD.Infrastructure.Mappings
{
    public class ImageMap : ClassMap<Image>
    {
        public ImageMap()
        {
            Id(x => x.Id)
                .Not.Nullable();

            Map(x => x.FileName)
                .Length(100)
                .Not.Nullable();

            Map(x => x.FileSize)
                .Not.Nullable();

            Map(x => x.FileType)
                .Not.Nullable();

            Map(x => x.Caption);

            Map(x => x.Width)
                .Not.Nullable();

            Map(x => x.Height)
                .Not.Nullable();

            Map(x => x.AddedAt)
                .Not.Nullable();

            Map(x => x.UpdatedAt)
                .Not.Nullable();

            Map(x => x.Uri)
                .Not.Nullable();


        }
    }
}
