using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using CumbriaMD.Web.AutoMapper;
using NUnit.Framework;


namespace CumbriaMD.Tests.AutoMapper
{
    [TestFixture]
    public class AutoMapperConfigTests
    {
        [Test]
        public void Should_map_dtos()
        {
            AutomapperConfiguration.Configure();
            Mapper.AssertConfigurationIsValid();
        }
    }
}
