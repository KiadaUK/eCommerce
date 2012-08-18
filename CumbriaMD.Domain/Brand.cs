using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eDetectors.Domain;

namespace CumbriaMD.Domain
{
    public class Brand : EntityBase
    {
        public virtual string Name { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual Image Image { get; set; }
        public virtual Product DefaultProduct { get; set; }
        public virtual IList<Product> Products { get; set; }
    }
}
