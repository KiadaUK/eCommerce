using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CumbriaMD.Web.Windsor
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DoNotMapAttribute : Attribute
    {

    }
}