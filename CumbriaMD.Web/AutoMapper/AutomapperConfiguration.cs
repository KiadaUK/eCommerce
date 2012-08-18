using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
namespace CumbriaMD.Web.AutoMapper
{
    public class AutomapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x => x.AddProfile<ViewModelProfile>());

        }
    }
    
}