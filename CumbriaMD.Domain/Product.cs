using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CumbriaMD.Domain
{

    public class Product : EntityBase
    {

        public virtual string Name { get; set; }
        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
        public virtual decimal Price { get; set; }
        public virtual bool IsDiscounted { get; set; }
        public virtual bool IsInStock { get; set; }
    //  public virtual IList<Image> Images { get; set; }
        public virtual IList<Category> Categories { get; protected set; }
        public virtual Brand Brand { get; set; }
        public virtual DateTime? AddedAt { get; set; }
        public virtual DateTime? UpdatedAt { get; set; }
    }
}
