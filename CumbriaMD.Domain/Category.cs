using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CumbriaMD.Domain
{
    public class Category : EntityBase
    {
        public virtual string Name { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual int OrderInList { get; set; }
       //public virtual Image DefaultImage { get; set; }
        public virtual Category Parent { get; set; }
        public virtual IList<Product> Products { get; protected set; }
        public virtual IList<Category> Subcategories { get; set; }

    }
}
