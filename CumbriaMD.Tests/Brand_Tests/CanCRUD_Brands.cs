using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CumbriaMD.Domain;
using CumbriaMD.Web.Windsor.Facilities;
using CumbriaMD.Web.Windsor.Installers;
using NHibernate;
using NUnit.Framework;
using CumbriaMD.Web.Windsor;

namespace CumbriaMD.Tests.Brand_Tests
{
    [TestFixture]
    public class CanCRUD_Brands
    {

        [Test]
        public void Can_insert_a_brand_into_the_database()
        {
            decimal layoutWidth = 500;
            int imageWidth = 875;
            decimal imageHeight = 403;
            decimal multiplier = (imageWidth / layoutWidth);
            imageWidth = (int)decimal.Round(imageWidth/multiplier);         
            var newHeight = (int)decimal.Round(imageHeight / multiplier);

            Console.Write("Width: " + imageWidth.ToString() + " | Height: " + newHeight + " | Multiplier: " + multiplier);
        }


    }
}
